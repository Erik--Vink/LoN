using LoN.Model.Repositories;
using LoN.Model.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoN.Model.Models;

namespace LoN.Model.Utility
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGenericRepository<Category>>().To<CategoryRepository>();
            Bind<IGenericRepository<Equip>>().To<EquipRepository>();           
            Bind<IGenericRepository<Ninja>>().To<NinjaRepository>();
            Bind<IGenericRepository<NinjaEquip>>().To<NinjaEquipRepository>();        
        }
    }
}
