using LoN.Model.Repositories;
using LoN.Model.Utility;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.Model.Ninject
{
    public class NinjectServiceLocator
    {
        private static NinjectServiceLocator _ninjectServiceLocator;
        private readonly IKernel _kernel;

        public NinjectServiceLocator()
        {
            _kernel = new StandardKernel(new DomainModule());
        }

        public static NinjectServiceLocator Instance
        {
            get { return _ninjectServiceLocator ?? (_ninjectServiceLocator = new NinjectServiceLocator()); }
        }

        public EquipRepository equipRepository
        {
            get { return _kernel.Get<EquipRepository>(); }
        }

        public CategoryRepository categoryRepository
        {
            get { return _kernel.Get<CategoryRepository>(); }
        }

        public NinjaRepository ninjaRepository
        {
            get { return _kernel.Get<NinjaRepository>(); }
        }

        public NinjaEquipRepository ninjaEquipRepository
        {
            get { return _kernel.Get<NinjaEquipRepository>(); }
        }
      
    }
}
