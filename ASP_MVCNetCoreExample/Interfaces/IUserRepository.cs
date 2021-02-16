using ASP_MVCNetCoreExample.Dtos;
using ASP_MVCNetCoreExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Interfaces
{
    public interface IUserRepository
    {
        public void Update(MemberDto user);
        public Task<bool> SaveAllAsync();
        public Task<IEnumerable<MemberDto>> GetUsersAsync();
        public Task<MemberDto> GetUserByUsernameAsync(string username);
    }
}
