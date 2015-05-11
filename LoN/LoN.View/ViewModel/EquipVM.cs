using GalaSoft.MvvmLight;
using LoN.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.View.ViewModel
{
    public class EquipVM : ViewModelBase
    {
        private int _id;
        private string _name;
        private int _price;
        private int _str;
        private int _int;
        private int _agi;
        private CategoryVM _cat;

        public EquipVM(Equip e) 
        {
            this._id = e.EquipId;
            this._name = e.EquipName;
            this._price = e.Price;
            this._str = e.Strength;
            this._int = e.Intelligence;
            this._agi = e.Agillity;
            this._cat = new CategoryVM(e.Category);
        }

        public int EquipId 
        {
            get { return this._id; }
            set { this._id = value; RaisePropertyChanged(); }
        }

        public string EquipName
        {
            get { return this._name; }
            set { this._name = value; RaisePropertyChanged(); }
        }

        public int Price
        {
            get { return this._price; }
            set { this._price = value; RaisePropertyChanged(); }
        }

        public int Strength
        {
            get { return this._str; }
            set { this._str = value; RaisePropertyChanged(); }
        }

        public int Intelligence
        {
            get { return this._int; }
            set { this._int = value; RaisePropertyChanged(); }
        }

        public int Agillity
        {
            get { return this._agi; }
            set { this._agi = value; RaisePropertyChanged(); }
        }

        public CategoryVM Category 
        {
            get { return this._cat; }
            set { this._cat = value; RaisePropertyChanged(); }
        }
    }
}
