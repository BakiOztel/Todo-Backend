using App.Application.Common.Interfaces;
using App.Application.Dtos.blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkblogController : ControllerBase
    {

        private readonly IBlog _blog;
        public WorkblogController(IBlog blog)
        {
            _blog = blog;
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateBlogReguest model)
        {
            var data = await _blog.Create(model);
            return Ok(data);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var data = await _blog.GetAll();
            return Ok(data);
        }


    }
}
