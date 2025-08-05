using ToDoTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ToDoTask.DataAccess.Entities;

namespace ToDoTask.DataAccess.Reposotories
{
    public class ToDoTaskReposotory : IToDoTaskReposotory
    {
        private readonly ToDoTaskDBContext _context;
        public ToDoTaskReposotory(ToDoTaskDBContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoTask.Domain.Models.Task>> Get()
        {
            var ToDoTaskEntity = await _context.ToDoTask.AsNoTracking().ToListAsync();

            var Tasks = ToDoTaskEntity.Select(b => ToDoTask.Domain.Models.Task.Create(b.Id, b.Description, b.Name, b.IsComplited, b.DateCreated).Task).ToList();

            return Tasks;
        }

        public async Task<Guid> Create(ToDoTask.Domain.Models.Task task)
        {
            var taskEntity = new ToDoTaskEntity
            {
                Id = task.Id,
                Description = task.Description,
                Name = task.Name,
            };
            await _context.ToDoTask.AddAsync(taskEntity);
            await _context.SaveChangesAsync();

            return taskEntity.Id;
        }

        public async Task<Guid> Update(Guid Id, string Name, string Description, bool IsComplited, DateTime DateCreated)
        {
            await _context.ToDoTask
                .Where(b => b.Id == Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => Name)
                .SetProperty(b => b.Description, b => Description)
                .SetProperty(b => b.IsComplited, b => IsComplited));
            return Id;
        }

        public async Task<Guid> Delete(Guid Id)
        {
            await _context.ToDoTask
                .Where(b => b.Id == Id)
                .ExecuteDeleteAsync();

            return Id;
        }
    }
}
