﻿using MvcRedFinal.Data;
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
        public MovieDetail GetMovieDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var movie = ctx.Movies.Single(m => m.Id == id);
                return new MovieDetail
                {
                    MovieId = movie.Id,
                    Description = movie.Description,
                    ManagerId = movie.ManagerId,
                    TheaterId = movie.TheaterId,

                };
            }
        }
        public bool CreateMovie(MovieCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newMovie = new Movie()
                {
                    Description = model.Description,
                    ManagerId = model.ManagerId,
                    TheaterId = model.TheaterId
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
                    ManagerId = m.ManagerId,
                    TheaterId = m.TheaterId
                });

                return query.ToArray();
            }
        }

        public bool UpdateMovie(MovieEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var movie = ctx.Movies.Single(m => m.Id == model.MovieId);
                movie.Description = model.Description;
                movie.ManagerId = model.ManagerId;
                movie.TheaterId = model.TheaterId;


                return ctx.SaveChanges() == 1;
            }
        }
    }
}
