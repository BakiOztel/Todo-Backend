using App.Application.Common.Interfaces;
using App.Application.Dtos.User;
using App.Data.Context;
using App.Domain.Entities;
using App.Identity.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.DataProtection;

namespace App.Identity.Services
{
    public class UserService : IUserService
    {

        private readonly AppDataContext _context;
        private readonly AuthSettings _authSettings;

        private readonly IHash _hash;

        public UserService(IOptions<AuthSettings> appSettings,AppDataContext context,IHash hash)
        {
            _hash=hash;
            _authSettings = appSettings.Value;
            _context = context;
            
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {

            var user = _context.User.SingleOrDefault(u => u.Username == model.Username);
            if ( user == null)
            {
                return null;
            }
            else if (_hash.Decryption(user.Password) != model.Password)
            {
                return null;
            }
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string GenerateJwtToken(User user)
        {
   

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Username),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.Secret));

            var jwtToken = new JwtSecurityToken(
                claims:claims,
                issuer: "https://localhost",
                audience: "https://localhost",
                expires:DateTime.Now.AddHours(1),
                signingCredentials:new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
        }



    }
}
