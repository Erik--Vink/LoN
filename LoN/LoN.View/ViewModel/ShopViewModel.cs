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
        private NinjaViewModel _selectedNinjaViewModel;
        private IGenericRepository<Category> _categoryRepository;
        private IGenericRepository<Equip> _equipRepository;
        private IGenericRepository<Ninja> _ninjaRepository;
        private IGenericRepository<NinjaEquip> _ninjaEquipRepository;

        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        public ObservableCollection<EquipViewModel> Equipment { get; set; }
        public ObservableCollection<EquipViewModel> AvailableEquipment { get; set; }
        public ObservableCollection<EquipViewModel> NinjaEquips { get; set; }
        public ObservableCollection<NinjaViewModel> AllNinjas { get; set; }
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

        public NinjaViewModel SelectedNinjaViewModel
        {
            get { return _selectedNinjaViewModel; }
            set
            {
                _selectedNinjaViewModel = value;
                RaisePropertyChanged();
                RaisePropertyChanged(() => IsLoadableSelected);
            }
        }

        public ShopViewModel() 
        {
            _categoryRepository = new CategoryRepository();
            _equipRepository = new EquipRepository();
            _ninjaRepository = new NinjaRepository();
            _ninjaEquipRepository = new NinjaEquipRepository();

            Categories = new ObservableCollection<CategoryViewModel>(_categoryRepository.GetAll().Select(c => new CategoryViewModel(c)));
            Equipment = new ObservableCollection<EquipViewModel>(_equipRepository.GetAll().Select(e => new EquipViewModel(e)));
            AllNinjas = new ObservableCollection<NinjaViewModel>(_ninjaRepository.GetAll().Select(n => new NinjaViewModel(n)));
            NinjaViewModel = new NinjaViewModel();

            BuyEquip = new RelayCommand(AddSelectedEquipToNinja);
            NewNinja = new RelayCommand(SaveNewNinja);
            SaveNinja = new RelayCommand(SaveCurrentNinja);
            LoadNinja = new RelayCommand(LoadCurrentNinja);
        }

        #region Commands

        public ICommand BuyEquip { get; set; }
        public void AddSelectedEquipToNinja()
        {
            //Check if the budget is high enough, if false a message will be shown
            if (NinjaViewModel.BugetIsHighEnough(SelectedEquip.ToEntity()))
            {
                //Check if the ninja already has equips
                if (NinjaViewModel.Equips != null)
                {
                    var oldCategoryEquip = NinjaViewModel.Equips
                    .Where(src => src.CategoryId.Equals(SelectedEquip.CategoryId))
                    .FirstOrDefault();
                    //Check if the selected equip was not added yet
                    if (oldCategoryEquip != null)
                    {
                        //Remove the previously added equip with the same category             
                        NinjaViewModel.RemoveEquipment(oldCategoryEquip);
                    }
                }
                NinjaViewModel.AddEquipment(SelectedEquip.ToEntity());
                ReloadEquipment();
                RaisePropertyChanged(() => NinjaViewModel);
            }
        }
        public ICommand SaveNinja { get; set; }
        public void SaveCurrentNinja()
        {
            //if (_hasNewNinja)
            //{
            //    _ninjaRepository.Create(null);
            //}
            //else
            //{
            //    _ninjaRepository.Update(null);
            //}
            AllNinjas = new ObservableCollection<NinjaViewModel>(_ninjaRepository.GetAll().Select(n => new NinjaViewModel(n)));
            RaisePropertyChanged(() => AllNinjas);
        }

        public ICommand NewNinja { get; set; }
        public void SaveNewNinja()
        {
            //Add new Ninja
            var id = _ninjaRepository.Create(this.NinjaViewModel.ToEntity()).NinjaId;

            //Add NinjaEquips
            foreach (Equip equip in this.NinjaViewModel.Equips)
            {
                NinjaEquip newEquip = new NinjaEquip();
                newEquip.EquipId = equip.EquipId;
                newEquip.NinjaId = id;
                _ninjaEquipRepository.Create(newEquip);               
            }

            this.NinjaViewModel = new NinjaViewModel();
            AllNinjas = new ObservableCollection<NinjaViewModel>(_ninjaRepository.GetAll().Select(n => new NinjaViewModel(n)));
            RaisePropertyChanged(() => this.NinjaViewModel);
            RaisePropertyChanged(() => AllNinjas);
        }

        public ICommand LoadNinja { get; set; }
        public void LoadCurrentNinja()
        {           
            this.NinjaViewModel = SelectedNinjaViewModel;
            RaisePropertyChanged(() => this.NinjaViewModel);

        }

        #endregion

        #region Methods

        #region Booleans

        public bool IsEquipSelected
        {
            get { return _selectedEquip != null; }
        }

        public bool IsLoadableSelected
        {
            get { return SelectedNinjaViewModel != null; }
        }

        public bool IsCreateEnabled
        {
            get { return NinjaViewModel.NinjaId == 0; }
        }
        public bool IsUpdateEnabled
        {
            get { return NinjaViewModel.NinjaId != 0; }
        }

        #endregion
        public void ReloadEquipment()
        {
            foreach (Equip equip in NinjaViewModel.Equips)
            {
                if (_categoryRepository.GetOne(equip.CategoryId).CategoryName == "Head")
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

        public ObservableCollection<EquipViewModel> ReloadAvailableEquipment()
        {
            return (_selectedCategory != null)
                ? new ObservableCollection<EquipViewModel>(
                    Equipment
                        .Where(src => src.CategoryId.Equals(_selectedCategory.CategoryId)))
                : new ObservableCollection<EquipViewModel>();
        }

        #endregion
    }
}
