using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.View.ViewModel
{
    public class ShopVM : ViewModelBase
    {
        private EquipVM _selectedEquip;
        private CategoryVM _selectedCategory;

        public ObservableCollection<EquipVM> Equipment { get; set; }
        public ObservableCollection<CategoryVM> Categories { get; set; }

        public EquipVM SelectedEquip 
        {
            get { return this._selectedEquip; }
            set { this._selectedEquip = value; RaisePropertyChanged(); }
        }

        public CategoryVM SelectedCategory
        { 
            get { return this._selectedCategory; } 
            set { this._selectedCategory = value; RaisePropertyChanged(); }
        }
    }
}
