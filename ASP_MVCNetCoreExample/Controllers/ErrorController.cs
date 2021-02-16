using ASP_MVCNetCoreExample.Data;
using ASP_MVCNetCoreExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Controllers
{
    public class ErrorController : BaseApiController
    {
        private DataContext m_context;
        public ErrorController(DataContext context)
        {
            m_context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }


        [HttpGet("not-found")]
        public ActionResult<string> GetNotFound()
        {
            var thing = m_context.Users.Find(-1);
            if (thing == null)
                return NotFound();

            return Ok(thing);
        }


        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = m_context.Users.Find(-1);
            var thingToReturn = thing.ToString();
            return thingToReturn;
        }


        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This is bad request");
        }
    }
}
