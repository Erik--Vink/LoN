/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:LoN.View"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using LoN.Model.Interfaces;
using LoN.Model.Models;
using LoN.Model.Ninject;
using Microsoft.Practices.ServiceLocation;

namespace LoN.View.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            var nsl = NinjectServiceLocator.Instance;
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            //NinjectService bindings
            SimpleIoc.Default.Register<IGenericRepository<Category>>(() => nsl.categoryRepository);
            SimpleIoc.Default.Register<IGenericRepository<Equip>>(() => nsl.equipRepository);
            SimpleIoc.Default.Register<IGenericRepository<Ninja>>(() => nsl.ninjaRepository);
            SimpleIoc.Default.Register<IGenericRepository<NinjaEquip>>(() => nsl.ninjaEquipRepository);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ShopViewModel>();
            SimpleIoc.Default.Register<CrudViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ShopViewModel Shop
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShopViewModel>();
            }
        }

        public CrudViewModel Crud
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CrudViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}