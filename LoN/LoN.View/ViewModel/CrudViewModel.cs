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
    class CrudViewModel : ViewModelBase
    {
        private EquipViewModel _selectedEquip;
        private CategoryViewModel _selectedCategory;
        private ICommand _saveChanges;

        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        public ObservableCollection<EquipViewModel> Equipment { get; set; }
        public ObservableCollection<EquipViewModel> AvailableEquipment { get; set; }

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

        public CrudViewModel() 
        {
            Categories = new ObservableCollection<CategoryViewModel>((new DummyCategoryRepository()).GetAll().Select(c => new CategoryViewModel(c)));
            Equipment = new ObservableCollection<EquipViewModel>((new DummyEquipRepository()).GetAll().Select(e => new EquipViewModel(e)));

            _saveChanges = new RelayCommand(SaveEquipVM);
        }

        public ObservableCollection<EquipViewModel> ReloadAvailableEquipment()
        {
            return (_selectedCategory != null)
                ? new ObservableCollection<EquipViewModel>(
                    Equipment
                        .Where(src => src.CategoryId.Equals(_selectedCategory.CategoryId)))
                : new ObservableCollection<EquipViewModel>();
        }

        public void SaveEquipVM()
        {
            Equip e = new Equip() { Agillity = _selectedEquip.Agillity,
                                    CategoryId = _selectedEquip.CategoryId,
                                    Intelligence = _selectedEquip.Intelligence,
                                    Strength = _selectedEquip.Strength,
                                    Price = _selectedEquip.Price,
                                    EquipName = _selectedEquip.EquipName
            };

            //I cannot save yet, because repos

            RaisePropertyChanged();
            RaisePropertyChanged(() => AvailableEquipment);
        }
    }
}
