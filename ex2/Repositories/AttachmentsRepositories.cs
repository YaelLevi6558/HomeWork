﻿using ex2.Models;
using ex2.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ex2.Repositories
{
    public class AttachmentsRepository : IAttachmentsRepositories
    {
        private readonly string _cnn;
        public AttachmentsRepository(IConfiguration configuration)
        {
            _cnn = configuration.GetConnectionString("DefaultConnection");
        }
        public DataTable CreateAttachment(string attachmentName, string attachmentPath)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_cnn))
            {
                using (SqlCommand command = new SqlCommand("AddAttachment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@AttachmentName", attachmentName));
                    command.Parameters.Add(new SqlParameter("@attachmentPath", attachmentPath));
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public bool ProcessTransaction(Attachment attachment, Tasks task)
        {
            using (SqlConnection connection = new SqlConnection(_cnn))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command1 = new SqlCommand("INSERT INTO Tasks (Name, Priority, DueDate,Status, Id )  VALUES (@Name, @Priority, @DueDate, @Status, @Id)", connection, transaction))
                    {
                        command1.Parameters.AddWithValue("@Name", task.Name);
                        command1.Parameters.AddWithValue("@Priority", task.Priority);
                        command1.Parameters.AddWithValue("@DueDate", task.DueDate);
                        command1.Parameters.AddWithValue("@Status", task.Status);
                        command1.Parameters.AddWithValue("@Id", task.Id);
                        command1.ExecuteNonQuery();
                    }

                    using (SqlCommand command2 = new SqlCommand("INSERT INTO Attachments (Name, Path, Id) VALUES (@Name, @Path,@Id)", connection, transaction))
                    {
                        command2.Parameters.AddWithValue("@Name", attachment.Name);
                        command2.Parameters.AddWithValue("@Path", attachment.Path);
                        command2.Parameters.AddWithValue("@Id", attachment.Id);
                        command2.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    Console.WriteLine("Transaction committed.");
                    return true;
                }
                catch(Exception ex)
                {
                    // כאן נדפיס את פרטי השגיאה
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }


}

