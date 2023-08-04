using App.Application.Common.Interfaces;
using App.Application.Dtos.Todo;
using App.Domain.Entities;
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
    public class TodoController : ControllerBase
    {

        private readonly ITodo _todo;

        public TodoController(ITodo todo)
        {
            _todo = todo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _todo.GetAllTodo();
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoRequest todo)
        {
            var response = await _todo.AddTodo(todo);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
            var response = await _todo.DeleteTodo(id);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo([FromBody ] Todo todo,[FromRoute] int id)
        {
            var response = await _todo.UpdateTodo(todo, id);
            return Ok(response);
        }


        [HttpGet("Deneme")]
        public async Task<IActionResult> Deneme()
        {
            
            return Ok("çalıştı");
        }

    }
}
