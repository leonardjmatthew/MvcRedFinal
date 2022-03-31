using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRedFinal.Model
{
    public class MovieCreate
    {
        [MaxLength(5000)]
        public string Description { get; set; }
    }
}
