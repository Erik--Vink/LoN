using GalaSoft.MvvmLight;
using LoN.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.View.ViewModel
{
    public class CategoryVM : ViewModelBase
    {
        private int _id;
        private string _name;

        public int CategoryId
        {
            get { return this._id; }
            set { this._id = value; RaisePropertyChanged(); }
        }
        public string CategoryName 
        {
            get { return this._name; }
            set { this._name = value; RaisePropertyChanged(); }
        }

        public CategoryVM(Category c) 
        {
            this.CategoryId = c.CategoryId;
            this.CategoryName = c.CategoryName;
        }
    }
}
