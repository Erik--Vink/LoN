using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.Model.Models
{
    public class Ninja
    {
        [Key]
        public int NinjaId { get; set; }

        public double Budget { get; set; }

        public virtual ICollection<NinjaEquip> Equips { get; set; }
      
    }
}
