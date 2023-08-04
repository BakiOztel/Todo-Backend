using App.Application.Dtos.User;
using App.Application.Common.Interfaces;
using App.Data.Context;
using App.Domain.Entities;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Application.Common.Helpers;

namespace App.Application.UserService.Commond
{
    public class UserCommandService : IUser
    {
        private readonly AppDataContext _context;
        private readonly IHash _hash;


        public UserCommandService(AppDataContext context, IHash hash)
        {
            _context = context;
            _hash = hash;

        }

        public async Task<string> CreateUser(CreateUserRequest request)
        {

            User user = new User() {
                Username = request.Username,
                Password = _hash.Encryption(request.Password)
            };

            try
            {
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                return "ok";
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message.ToString());
            }

        }

    }
}
