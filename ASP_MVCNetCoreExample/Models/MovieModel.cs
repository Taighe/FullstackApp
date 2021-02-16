using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string ImageUrl { get; set; }
        public bool Favourite { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
