using ex2.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using TasksApi.Services.Logger;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ex2.Services.Logger
{
    public class DbLogger : ILoggerService
    {
        private readonly TasksContext _dbContext;
        public DbLogger(TasksContext context)
        {
            _dbContext = context;
        }
        public void Log(string message)
        {
            try
            {
                MessageDB m = new MessageDB();
                m.Description = message;
                m.Date = DateTime.Now;
                _dbContext.MessageDB.Add(m);
                _dbContext.SaveChanges();
                Console.WriteLine("Message logged successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine($"failed to log message: {e.Message}");

            }
        }
    }
}
