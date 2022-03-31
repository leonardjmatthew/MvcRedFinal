using MvcRedFinal.Data;
using MvcRedFinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRedFinal.Service
{
    public class ManagerService
    {
        public bool CreateManager(ManagerCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newManager = new Manager()
                {
                    Name = model.Name
                };

                ctx.Managers.Add(newManager);
                return ctx.SaveChanges() == 1;
            }
        }
        public ManagerDetail GetManagerDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var manager = ctx.Managers.Single(m => m.Id == id);
                return new ManagerDetail
                {
                    ManagerId = manager.Id,
                    Name = manager.Name
                };
            }
        }
        public IEnumerable<ManagerListItem> GetManagerList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Managers.Select(m => new ManagerListItem
                {
                    ManagerId = m.Id,
                    Name = m.Name
                });

                return query.ToArray();
            }
        }

        public bool UpdateManager(ManagerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var manager = ctx.Managers.Single(c => c.Id == model.ManagerId);
                manager.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
