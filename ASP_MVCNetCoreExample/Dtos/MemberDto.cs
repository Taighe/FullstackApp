using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<MovieRefDto> Favourites { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
