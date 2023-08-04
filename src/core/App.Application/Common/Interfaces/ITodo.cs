using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Dtos.Todo;
using App.Domain.Entities;

namespace App.Application.Common.Interfaces
{
    public interface ITodo
    {
        Task<List<TodoResponse>> GetAllTodo();

        Task<string> AddTodo(CreateTodoRequest todo);

        Task<string> UpdateTodo(Todo todo,int id);

        Task<string> DeleteTodo(int id);

    }
}
