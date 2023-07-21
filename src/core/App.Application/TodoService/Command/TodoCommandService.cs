using App.Application.TodoService.Interfaces;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using App.Data.Context;
using System.Threading.Tasks;
using System.Threading;

namespace App.Application.TodoService.Command
{
    public class TodoCommandService : ITodo
    {
        
        private readonly AppDataContext _context;
        public TodoCommandService(AppDataContext context)
        {
            _context = context;
        }
        public async Task<string> AddTodo(Todo todo)
        {
            await _context.Todo.AddAsync(todo);
            await _context.SaveChangesAsync();
            return "succes";
            
        }

        public async Task<string> DeleteTodo(int id)
        {
            var data = await _context.Todo.FindAsync(id);
            _context.Todo.Remove(data);
            await _context.SaveChangesAsync();
            return "succes";
        }

        public async Task<List<Todo>> GetAllTodo()
        {
            return await _context.Todo.ToListAsync();
        }

        public async Task<string> UpdateTodo(Todo todo,int id)
        {
            var data =await _context.Todo.FindAsync(id);
            data.Text = todo.Text;
            await _context.SaveChangesAsync();
            //2. Method
            // delete old value and create new one
            //_context.Todo.Remove(data);
            //await _context.Todo.AddAsync(todo);

            return "succes";
        }
    }
}
