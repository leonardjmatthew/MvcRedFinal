using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRedFinal.Model
{
    public class MovieDetail
    {
        public int MovieId { get; set; }
        public string Description { get; set; }
        public int ManagerId { get; set; }
        public int TheaterId { get; set; }
    }
}
