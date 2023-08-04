using App.Application.Common.Interfaces;
using App.Application.Dtos.blog;
using App.Data.Context;
using App.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.WorkblogService.Command
{
    public class WorkblogCommandService : IBlog
    {
        private readonly AppDataContext _context;
        private readonly IMapper _mapper;
        public WorkblogCommandService(AppDataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<BlogResponse> Create(CreateBlogReguest model)
        {
            var user = await _context.User.FindAsync(model.UserId);
            var todo = await _context.Todo.FirstAsync(t => t.Text==model.TodoText);
            todo.isDone = true;
            if (user == null)
            {
                throw new Exception("none user");
            }
            else
            {
                if (todo == null)
                {
                    throw new Exception("none todo");
                }
            }


            var blog = new Workblog
            {
                text = model.text,
                UserId = model.UserId,
                Todo=todo,
            };
            await _context.Workblog.AddAsync(blog);
            await _context.SaveChangesAsync();
            var vmdata = _mapper.Map<BlogResponse>(blog);
            return vmdata;
        }

        public async Task<List<BlogResponse>> GetAll()
        {
            var data = await _context.Workblog.Include(l => l.Todo).ToListAsync();

            var vmdata = _mapper.Map<List<Workblog>, List<BlogResponse>>(data);

            return vmdata;
        }

        
    }
}
