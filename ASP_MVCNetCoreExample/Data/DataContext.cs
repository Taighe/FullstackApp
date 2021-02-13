using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP_MVCNetCoreExample.Models;

namespace ASP_MVCNetCoreExample.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<MovieModel> Movies { get; set; }
    }
}
