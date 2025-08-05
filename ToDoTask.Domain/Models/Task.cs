namespace ToDoTask.Domain.Models
{ 
    public class Task
    {
        public const int MAX_NAME_LENGTH = 250;

        private Task(Guid Id, string Name, string Description, bool IsComplited, DateTime DateCreated)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.IsComplited = IsComplited; // Исправлено: IsComlited вместо IsComplited
            this.DateCreated = DateCreated;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool IsComplited { get; private set; }
        public DateTime DateCreated { get; private set; }

        public static (Task Task, string Error) Create(Guid Id, string Name, string Description, bool IsComplited, DateTime DateCreated)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(Name) || Name.Length > MAX_NAME_LENGTH)
            {
                error = "Имя должно заполнено и быть меньше 250 символов";
            }

            var Task = new Task(Id, Name, Description, IsComplited, DateCreated);

            return (Task, error);
        }
    }
}
