using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRedFinal.Model
{
    public class ManagerEdit
    {
        [Required]
        [MaxLength(256)]
        public int ManagerId { get; set; }
        public string Name { get; set; }
    }
}
