using App.Application.Dtos.User;
using App.Domain.Entities;

namespace App.Application.Common.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
