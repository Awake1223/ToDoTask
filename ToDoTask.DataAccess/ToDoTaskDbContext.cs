
using Microsoft.EntityFrameworkCore;
using ToDoTask.DataAccess.Entities;

namespace ToDoTask.DataAccess
{
    public class ToDoTaskDBContext : DbContext
    {
        public ToDoTaskDBContext(DbContextOptions<ToDoTaskDBContext> options) 
            : base(options) 
        {

        }

        public DbSet<ToDoTaskEntity> ToDoTask {  get; set; }
    }
}
