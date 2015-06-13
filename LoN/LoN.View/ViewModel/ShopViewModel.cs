using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LoN.Model.Interfaces;
using LoN.Model.Models;
using LoN.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoN.View.ViewModel
{
    public class ShopViewModel : ViewModelBase
    {
        private EquipViewModel _selectedEquip;
        private CategoryViewModel _selectedCategory;
        private IGenericRepository<Category> _categoryRepository;
        private IGenericRepository<Equip> _equipRepository;
        private IGenericRepository<Ninja> _ninjaRepository;

        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        public ObservableCollection<EquipViewModel> Equipment { get; set; }
        public ObservableCollection<EquipViewModel> AvailableEquipment { get; set; }
        public ObservableCollection<EquipViewModel> NinjaEquips { get; set; }

        public NinjaViewModel NinjaViewModel { get; set; }
  

        public EquipViewModel SelectedEquip 
        {
            get { return this._selectedEquip; }
            set
            { 
                this._selectedEquip = value;
                RaisePropertyChanged();
                RaisePropertyChanged(() => IsEquipSelected);
            }
        }

        public CategoryViewModel SelectedCategory
        { 
            get { return this._selectedCategory; } 
            set 
            { 
                this._selectedCategory = value;
                SelectedEquip = null;
                AvailableEquipment = ReloadAvailableEquipment();
                RaisePropertyChanged();
                RaisePropertyChanged(() => AvailableEquipment);
            }
        }

        public bool IsEquipSelected
        {
            get { return _selectedEquip != null; }
        }

        public ShopViewModel() 
        {
            Categories = new ObservableCollection<CategoryViewModel>((new CategoryRepository()).GetAll().Select(c => new CategoryViewModel(c)));
            Equipment = new ObservableCollection<EquipViewModel>((new EquipRepository()).GetAll().Select(e => new EquipViewModel(e)));
            NinjaViewModel = new NinjaViewModel();

            _categoryRepository = new CategoryRepository();
            _equipRepository = new EquipRepository();
            _ninjaRepository = new NinjaRepository();

            BuyEquip = new RelayCommand(AddSelectedEquipToNinja);
        }

      

        public ObservableCollection<EquipViewModel> ReloadAvailableEquipment()
        {
            return (_selectedCategory != null)
                ? new ObservableCollection<EquipViewModel>(
                    Equipment
                        .Where(src => src.CategoryId.Equals(_selectedCategory.CategoryId)))
                : new ObservableCollection<EquipViewModel>();
        }

        public ICommand BuyEquip { get; set; }

        public void AddSelectedEquipToNinja()
        {
            //Check if an equip of the same category already is added(or the current equip)
            //- If true, delete the equip
            //Add the current selected Equip
            if (NinjaViewModel.Equips != null)
            {
                var oldCategoryEquip = NinjaViewModel.Equips
                .Where(src => src.CategoryId.Equals(SelectedEquip.CategoryId))
                .FirstOrDefault();
                if (oldCategoryEquip != null)
                {
                    //Remove the early added equip with the same category             
                    NinjaViewModel.RemoveEquipment(oldCategoryEquip);
                }
               
            }
            NinjaViewModel.AddEquipment(SelectedEquip.ToEntity());
            ReloadEquipment();
            RaisePropertyChanged(() => NinjaViewModel);
        }

        public void ReloadEquipment()
        {
            foreach (Equip equip in NinjaViewModel.Equips)
            {
                if ( _categoryRepository.GetOne(equip.CategoryId).CategoryName == "Head")
                {
                    NinjaViewModel.CategoryHead = equip;
                }
                else if (_categoryRepository.GetOne(equip.CategoryId).CategoryName == "Shoulders")
                {
                    NinjaViewModel.CategoryShoulders = equip;
                }
                else if (_categoryRepository.GetOne(equip.CategoryId).CategoryName == "Chest")
                {
                    NinjaViewModel.CategoryChest = equip;
                }
                else if (_categoryRepository.GetOne(equip.CategoryId).CategoryName == "Belt")
                {
                    NinjaViewModel.CategoryBelt = equip;
                }
                else if (_categoryRepository.GetOne(equip.CategoryId).CategoryName == "Legs")
                {
                    NinjaViewModel.CategoryLegs = equip;
                }
                else if (_categoryRepository.GetOne(equip.CategoryId).CategoryName == "Boots")
                {
                    NinjaViewModel.CategoryBoots = equip;
                }
                
            }
        }

    }
}
