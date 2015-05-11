using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.Model.Models
{
    public class Equip
    {
        [Key]
        public int EquipId { get; set; }

        public string EquipName { get; set; }

        public double Price { get; set; }

        public int Strength { get; set; }

        public int Intelligence { get; set; }
        public int Agillity { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Ninja> Ninjas { get; set; }

        public Equip()
        {
            Ninjas = new HashSet<Ninja>();
        }
    }
}
