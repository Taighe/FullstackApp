using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ASP_MVCNetExample.Data;
using ASP_MVCNetExample.Models;

namespace ASP_MVCNetExample.Controllers
{
    public class MovieModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/JoggingRecords
        public IQueryable<MovieModel> GetMovieModels() => db.MovieModels;

        // GET: api/JoggingRecords/5
        [ResponseType(typeof(MovieModel))]
        public async Task<IHttpActionResult> GetMovieModel(int id)
        {
            MovieModel movie = await db.MovieModels.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}