using Microsoft.EntityFrameworkCore;

namespace KovalevsheroWebAPI.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> TodoItems { get; set; }
    }
}