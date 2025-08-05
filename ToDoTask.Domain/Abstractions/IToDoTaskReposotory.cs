
namespace ToDoTask.DataAccess.Reposotories
{
    public interface IToDoTaskReposotory
    {
        Task<Guid> Create(Domain.Models.Task task);
        Task<Guid> Delete(Guid Id);
        Task<List<Domain.Models.Task>> Get();
        Task<Guid> Update(Guid Id, string Name, string Description, bool IsComplited, DateTime DateCreated);
    }
}