using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LoN.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoN.View.ViewModel
{
    public class EquipViewModel : ViewModelBase
    {
        private int _id;
        private string _name;
        private int _price;
        private int _str;
        private int _int;
        private int _agi;
        private int _catId;

        public EquipViewModel(Equip e) 
        {
            this._id = e.EquipId;
            this._name = e.EquipName;
            this._price = e.Price;
            this._str = e.Strength;
            this._int = e.Intelligence;
            this._agi = e.Agillity;
            this._catId = e.CategoryId;
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

        public int CategoryId 
        {
            get { return this._catId; }
            set { this._catId = value; RaisePropertyChanged(); }
        }

        public Equip ToEntity()
        {
            return new Equip { EquipId = EquipId, EquipName = EquipName, Price = Price, Strength = Strength, Intelligence = Intelligence, Agillity = Agillity, CategoryId = CategoryId };
        }
    }
}
