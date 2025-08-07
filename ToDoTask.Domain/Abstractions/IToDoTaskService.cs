





namespace ToDoTask.Application.Services
{
    public interface IToDoTaskService
    {
        Task<Guid> CreateTask(Domain.Models.Task task);
        Task<Guid> DeleteTask(Guid Id);
        Task<List<Domain.Models.Task>> GetAllTasks();
        Task<Guid> UpdateTask(Guid Id, string Name, string Description, bool IsComplited, DateTime DateCreated);
    }
}