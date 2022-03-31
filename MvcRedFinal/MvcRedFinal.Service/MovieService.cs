using MvcRedFinal.Data;
using MvcRedFinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRedFinal.Service
{
    public class MovieService
    {
        private readonly Guid _userId;

        public MovieService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMovie(MovieCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newMovie = new Movie()
                {
                    Description = model.Description,

                };

                ctx.Movies.Add(newMovie);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieListItem> GetMovieList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Movies.Select(m => new MovieListItem
                {
                    MovieId = m.Id,
                    Description = m.Description,
                });

                return query.ToArray();
            }
        }
    }
}
