using ASP_MVCNetCoreExample.Data;
using ASP_MVCNetCoreExample.Dtos;
using ASP_MVCNetCoreExample.Interfaces;
using ASP_MVCNetCoreExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Controllers
{
    public class AccountController : BaseApiController
    {
        private DataContext m_context;
        private ITokenService m_tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            m_context = context;
            m_tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto dto)
        {
            if (await UserExists(dto.UserName))
                return BadRequest("Username is taken.");
            
            var user = new UserModel();
            using (var hmac = new HMACSHA512())
            {
                user.UserName = dto.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
                user.PasswordSalt = hmac.Key;
            }

            m_context.Users.Add(user);
            await m_context.SaveChangesAsync();
            return new UserDto {UserName = user.UserName, Token = m_tokenService.CreateToken(user) };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto dto)
        {
            var user = await m_context.Users.SingleOrDefaultAsync(u => u.UserName == dto.UserName);
            if (user == null)
                return Unauthorized("Invalid Username");

            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
                for(int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != user.PasswordHash[i])
                        return Unauthorized("Invalid Password.");
                }
            }

            return new UserDto { UserName = user.UserName, Token = m_tokenService.CreateToken(user) };
        }

        private async Task<bool> UserExists(string username)
        {
            return await m_context.Users.AnyAsync(user => user.UserName == username.ToLower());
        }
        
    }
}
