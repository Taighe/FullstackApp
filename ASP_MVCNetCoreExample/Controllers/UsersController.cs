using ASP_MVCNetCoreExample.Data;
using ASP_MVCNetCoreExample.Dtos;
using ASP_MVCNetCoreExample.Interfaces;
using ASP_MVCNetCoreExample.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private IUserRepository m_repository;
        private readonly IMapper m_mapper;

        public UsersController(IUserRepository repository, IMapper mapper)
        {
            m_repository = repository;
            m_mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            return Ok(await m_repository.GetUsersAsync());
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await m_repository.GetUserByUsernameAsync(username);
        }
    }
}
