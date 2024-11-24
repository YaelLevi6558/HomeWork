using Lesson3.Model;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lesson3.Repositories
{
    public class TasksDbContext: DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options)
        {

        }

        public DbSet<Tasks> Tasks { get; set; }

    }
}
