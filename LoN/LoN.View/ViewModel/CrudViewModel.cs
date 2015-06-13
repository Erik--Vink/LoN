using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

        public CrudViewModel() 
        {
            Categories = new ObservableCollection<CategoryViewModel>((new DummyCategoryRepository()).GetAll().Select(c => new CategoryViewModel(c)));
            Equipment = new ObservableCollection<EquipViewModel>((new DummyEquipRepository()).GetAll().Select(e => new EquipViewModel(e)));

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
                Equip e = new Equip()
                {
                    Agillity = _selectedEquip.Agillity,
                    CategoryId = _selectedEquip.CategoryId,
                    Intelligence = _selectedEquip.Intelligence,
                    Strength = _selectedEquip.Strength,
                    Price = _selectedEquip.Price,
                    EquipName = _selectedEquip.EquipName
                };

                if (_selectedEquip.EquipId > 0)
                {

                }
                else 
                {

                }


                RaisePropertyChanged();
                RaisePropertyChanged(() => AvailableEquipment);
            }
            

            //I cannot save yet, because repos

            //if exists, update, else save

            
        }
        public void DeleteEquipVM()
        {
            if(_selectedEquip != null && _selectedEquip.EquipId != null)
            {
                Equip e = new Equip()
                {
                    Agillity = _selectedEquip.Agillity,
                    CategoryId = _selectedEquip.CategoryId,
                    Intelligence = _selectedEquip.Intelligence,
                    Strength = _selectedEquip.Strength,
                    Price = _selectedEquip.Price,
                    EquipName = _selectedEquip.EquipName
                };

                //repo remove

                RaisePropertyChanged();
                RaisePropertyChanged(() => AvailableEquipment);
            }
        }

        public void CreateEquipVM()
        {
            Equipment.Add(new EquipViewModel(new Equip() { CategoryId = _selectedCategory.CategoryId, EquipName = "new Item" }));

            //save it to the repo

            AvailableEquipment = ReloadAvailableEquipment();
            RaisePropertyChanged();
            RaisePropertyChanged(() => AvailableEquipment);
        }
    }
}
