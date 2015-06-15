using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.Model.Models
{
    public class NinjaEquip
    {
        [Key,
        Column(Order = 0)]
        public int NinjaId { get; set; }

        [Key, ForeignKey("Equip"),
        Column(Order = 1)]
        public int EquipId { get; set; }
     
        [ForeignKey("NinjaId")]
        public virtual Ninja Ninja { get; set; }   
        public virtual Equip Equip { get; set; }
      
    }
}
