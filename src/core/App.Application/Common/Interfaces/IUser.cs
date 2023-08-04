using App.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interfaces
{
    public interface IUser
    {
        Task<string> CreateUser(CreateUserRequest request);
    
    }
}
