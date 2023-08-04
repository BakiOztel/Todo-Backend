using App.Application.Dtos.blog;
using App.Application.Dtos.Todo;
using App.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Todo, TodoResponse>();
            CreateMap<Workblog, BlogResponse>();
        }
    }
}
