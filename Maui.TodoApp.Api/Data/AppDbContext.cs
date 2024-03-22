using Maui.TodoApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Maui.TodoApp.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<ToDo> ToDos => Set<ToDo>();

    }
}
