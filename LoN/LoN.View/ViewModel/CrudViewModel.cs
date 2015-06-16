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
    public class CrudViewModel : ViewModelBase
    {
        private EquipViewModel _selectedEquip;
        private CategoryViewModel _selectedCategory;
        private IGenericRepository<Category> _categoryRepository;
        private IGenericRepository<Equip> _equipRepository;

        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        public ObservableCollection<EquipViewModel> Equipment { get; set; }
        public ObservableCollection<EquipViewModel> AvailableEquipment { get; set; }
        public ICommand Update { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Create { get; set; }

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
                RaisePropertyChanged(() => IsCategorySelected);
            }
        }

        public bool IsCategorySelected
        {
            get { return _selectedCategory != null; }
        }
        public bool IsEquipSelected
        {
            get { return _selectedEquip != null; }
        }

        public void RefreshData()
        {
            Categories = new ObservableCollection<CategoryViewModel>(_categoryRepository.GetAll().Select(c => new CategoryViewModel(c)));
            Equipment = new ObservableCollection<EquipViewModel>(_equipRepository.GetAll().Select(e => new EquipViewModel(e)));
            AvailableEquipment = ReloadAvailableEquipment();
        }

        public CrudViewModel(IGenericRepository<Category> categoryRepository, IGenericRepository<Equip> equipRepository) 
        {
            _categoryRepository = categoryRepository;
            _equipRepository = equipRepository;
            RefreshData();

            Update = new RelayCommand(UpdateEquipVM);
            Delete = new RelayCommand(DeleteEquipVM);
            Create = new RelayCommand(CreateEquipVM);
        }

        public ObservableCollection<EquipViewModel> ReloadAvailableEquipment()
        {
            return (_selectedCategory != null)
                ? new ObservableCollection<EquipViewModel>(
                    Equipment
                        .Where(src => src.CategoryId.Equals(_selectedCategory.CategoryId)))
                : new ObservableCollection<EquipViewModel>();
        }
        
        public void UpdateEquipVM()
        {

            if (_selectedEquip != null) 
            {
                Equip e = _selectedEquip.ToEntity();

                _equipRepository.Update(e);
                RefreshData();

                RaisePropertyChanged();
                RaisePropertyChanged(() => AvailableEquipment);
            }
        }

        public void DeleteEquipVM()
        {
            if(_selectedEquip != null)
            {
                Equip e = _selectedEquip.ToEntity();

                _equipRepository.Delete(e);
                RefreshData();

                RaisePropertyChanged();
                RaisePropertyChanged(() => AvailableEquipment);
            }
        }

        public void CreateEquipVM()
        {
            Equip e = new Equip() { CategoryId = _selectedCategory.CategoryId, EquipName = "new Item", Agillity=0, Intelligence=0, Price=0, Strength=0};
            _equipRepository.Create(e);
            RefreshData();

            RaisePropertyChanged();
            RaisePropertyChanged(() => AvailableEquipment);
        }
    }
}
