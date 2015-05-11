using GalaSoft.MvvmLight;
using LoN.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.View.ViewModel
{
    public class ShopViewModel : ViewModelBase
    {
        private EquipViewModel _selectedEquip;
        private CategoryViewModel _selectedCategory;

        public ObservableCollection<EquipViewModel> Equipment { get; set; }
        public ObservableCollection<CategoryViewModel> Categories { get; set; }

        public EquipViewModel SelectedEquip 
        {
            get { return this._selectedEquip; }
            set { this._selectedEquip = value; RaisePropertyChanged(); }
        }

        public CategoryViewModel SelectedCategory
        { 
            get { return this._selectedCategory; } 
            set { this._selectedCategory = value; RaisePropertyChanged(); }
        }

        public ShopViewModel() 
        {
            Categories = new ObservableCollection<CategoryViewModel>((new DummyCategoryRepository()).GetAll().Select(c => new CategoryViewModel(c)));
            Equipment = new ObservableCollection<EquipViewModel>((new DummyEquipRepository()).GetAll().Select(e => new EquipViewModel(e)));
        }
    }
}
