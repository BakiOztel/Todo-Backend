using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Domain.Entities;

namespace App.Application.TodoService.Interfaces
{
    public interface ITodo
    {
        Task<List<Todo>> GetAllTodo();

        Task<string> AddTodo(Todo todo);

        Task<string> UpdateTodo(Todo todo,int id);

        Task<string> DeleteTodo(int id);

    }
}
