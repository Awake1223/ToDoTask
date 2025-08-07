using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.DataAccess.Reposotories;
using ToDoTask.Domain.Models;

namespace ToDoTask.Application.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private IToDoTaskReposotory _toDoTaskReposotory;

        public ToDoTaskService(IToDoTaskReposotory toDoTaskReposotory)
        {
            _toDoTaskReposotory = toDoTaskReposotory;
        }

        public async Task<List<ToDoTask.Domain.Models.Task>> GetAllTasks()
        {
            return await _toDoTaskReposotory.Get();
        }

        public async Task<Guid> CreateTask(ToDoTask.Domain.Models.Task task)
        {
            return await _toDoTaskReposotory.Create(task);
        }

        public async Task<Guid> UpdateTask(Guid Id, string Name, string Description, bool IsComplited, DateTime DateCreated)
        {
            return await _toDoTaskReposotory.Update(Id, Name, Description, IsComplited, DateCreated);
        }

        public async Task<Guid> DeleteTask(Guid Id)
        {
            return await _toDoTaskReposotory.Delete(Id);
        }
    }
}
