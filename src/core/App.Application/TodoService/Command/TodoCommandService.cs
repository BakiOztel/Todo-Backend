using App.Application.Common.Interfaces;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using App.Data.Context;
using System.Threading.Tasks;
using System.Threading;
using App.Application.Dtos.Todo;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace App.Application.TodoService.Command
{
    public class TodoCommandService : ITodo
    {
        
        private readonly AppDataContext _context;
        private readonly IMapper _mapper;
        public TodoCommandService(AppDataContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<string> AddTodo(CreateTodoRequest model)
        {
            Todo todo = new Todo
            {
                Text = model.Text,
            };
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

        public async Task<List<TodoResponse>> GetAllTodo()
        {

            var data = await _context.Todo.ToListAsync();
            var vmdata = _mapper.Map<List<Todo>,List<TodoResponse>>(data);
            return vmdata;
        }

        public async Task<string> UpdateTodo(Todo todo,int id)
        {
            var data =await _context.Todo.FindAsync(id);
            data.Text = todo.Text;
            await _context.SaveChangesAsync();


            return "succes";
        }
    }
}
