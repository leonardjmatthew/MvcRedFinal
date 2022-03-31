using MvcRedFinal.Data;
using MvcRedFinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRedFinal.Service
{
    public class TheaterService
    {
        public bool CreateTheater(TheaterCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newTheater = new Theater()
                {
                    Name = model.Name
                };

                ctx.Theaters.Add(newTheater);
                return ctx.SaveChanges() == 1;
            }
        }
        public TheaterDetail GetTheaterDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var theater = ctx.Theaters.Single(t => t.Id == id);
                return new TheaterDetail
                {
                    TheaterId = theater.Id,
                    Name = theater.Name
                };
            }
        }
        public IEnumerable<TheaterListItem> GetTheaterList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Theaters.Select(t => new TheaterListItem
                {
                    TheaterId = t.Id,
                    Name = t.Name
                });

                return query.ToArray();
            }
        }

        public IEnumerable<Theater> GetTheaters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Theaters.ToList();
            }
        }

        public bool UpdateTheater(TheaterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var theater = ctx.Theaters.Single(t => t.Id == model.TheaterId);
                theater.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
