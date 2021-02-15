using ASP_MVCNetCoreExample.Data;
using ASP_MVCNetCoreExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Controllers
{
    public class UsersController : BaseApiController
    {
        private DataContext m_context;
        public UsersController(DataContext context)
        {
            m_context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            return await m_context.Users.ToListAsync();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            return await m_context.Users.FindAsync(id);
        }
    }
}
