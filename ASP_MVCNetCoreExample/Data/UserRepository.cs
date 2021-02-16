using ASP_MVCNetCoreExample.Dtos;
using ASP_MVCNetCoreExample.Interfaces;
using ASP_MVCNetCoreExample.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Data
{
    public class UserRepository : IUserRepository
    {
        private DataContext m_context;
        private readonly IMapper m_mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            m_context = context;
            m_mapper = mapper;
        }
        public async Task<MemberDto> GetUserByUsernameAsync(string username)
        {
            return await m_context.Users.Where(user => user.UserName == username).ProjectTo<MemberDto>(m_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetUsersAsync()
        {
            return await m_context.Users.ProjectTo<MemberDto>(m_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await m_context.SaveChangesAsync() > 0;
        }

        public void Update(MemberDto user)
        {
            m_context.Entry(user).State = EntityState.Modified;
        }
    }
}
