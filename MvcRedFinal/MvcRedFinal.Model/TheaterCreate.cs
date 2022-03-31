using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRedFinal.Model
{
    public class TheaterCreate
    {
        [MaxLength(5000)]
        public int TheaterId { get; set; }
        public string Name { get; set; }
    }
}
