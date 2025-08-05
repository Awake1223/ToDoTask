
namespace ToDoTask.DataAccess.Entities
{
    public class ToDoTaskEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsComplited { get; set; }
        public DateTime DateCreated { get; set;  }
    }
}
