using App.Application.Dtos.blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interfaces
{
    public interface IBlog
    {
        Task<BlogResponse> Create(CreateBlogReguest model);

        Task<List<BlogResponse>> GetAll();


    }
}
