using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
            Categories = new ObservableCollection<CategoryViewModel>((new DummyCategoryRepository()).GetAll().Select(c => new CategoryViewModel(c)));
            Equipment = new ObservableCollection<EquipViewModel>((new DummyEquipRepository()).GetAll().Select(e => new EquipViewModel(e)));
            NinjaViewModel = new NinjaViewModel();
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

        //Collections

        // Lijst met alle equips van de huidige ninja
        //private readonly ObservableCollection<EquipViewModel> _rawNinjaEquips;
        //public ObservableCollection<EquipViewModel> NinjaEquips
        //{
        //    get { return _rawNinjaEquips; }
        //}

        //// Lijst met 'unieke' productmerken in het boodschappenlijstje en aantallen
        //public ObservableCollection<KeyValuePair<EquipViewModel, int>> FormattedBoodschappenLijst
        //{
        //    get
        //    {
        //        return new ObservableCollection<KeyValuePair<EquipViewModel, int>>(RawBoodschappenLijst
        //            .GroupBy(x => new { x.MerkNaam, x.ProductNaam, x.Prijs, x.Korting })
        //            .Select(grp => new KeyValuePair<MerkProductViewModel, int>(
        //                    new MerkProductViewModel
        //                    {
        //                        MerkNaam = grp.Key.MerkNaam,
        //                        ProductNaam = grp.Key.ProductNaam,
        //                        Prijs = grp.Key.Prijs,
        //                        CurrentKortingPercentage = new CouponViewModel { Korting = grp.Key.Korting }
        //                    },
        //                    grp.Count()
        //                )
        //            ));
        //    }
        //}

        public ICommand BuyEquip { get; set; }

        public void AddSelectedEquipToNinja()
        {
     
            //Check if an equip of the same category already is added(or the current equip)
            //- If true, delete the equip and refund the money
            //Add the current selected Equip
            if (NinjaViewModel.Equips != null)
            {
                var oldCategoryEquip = NinjaViewModel.Equips
                .Where(src => src.CategoryId.Equals(SelectedEquip.CategoryId))
                .FirstOrDefault();
                if (oldCategoryEquip != null)
                {
                    //Refund money and replace the early added equip with the same category             
                    NinjaViewModel.Equips.Remove(oldCategoryEquip);
                }
               
            }
            //NinjaViewModel.Equips.Add(SelectedEquip.ToEntity());
            NinjaViewModel.Equips.Add(SelectedEquip.ToEntity());
            NinjaViewModel.ReloadEquipment();
            RaisePropertyChanged(() => NinjaViewModel);

            // als item in rawboodschappenlijst zit && heeft al korting, haal korting op en voeg toe aan new merkproductviewmodel
            //RawBoodschappenLijst.Add(new MerkProductViewModel(SelectedMerkProduct.ToEntity()) { CurrentKortingPercentage = new CouponViewModel { Korting = korting } });
            //SelectedKeyValuePair = new KeyValuePair<MerkProductViewModel, int>();
            //RaisePropertyChanged(() => FormattedBoodschappenLijst);
            //RaisePropertyChanged(() => TotalPrijs);
        }

    }
}
