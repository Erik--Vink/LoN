using LoN.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.Model.Context
{
    public class AppContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Equip> Equip { get; set; }
        public DbSet<Ninja> Ninja { get; set; }

        public DbSet<NinjaEquip> NinjaEquip { get; set; }
        public AppContext()
            : base("AppContext") { }
    }
}
