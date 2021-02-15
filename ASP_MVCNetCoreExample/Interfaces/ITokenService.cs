using ASP_MVCNetCoreExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(UserModel user);
    }
}
