using GalaSoft.MvvmLight;
using LoN.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.View.ViewModel
{
    public class NinjaViewModel : ViewModelBase
    {
        // Constructor
        public NinjaViewModel() { _ninja = new Ninja(); }
        public NinjaViewModel(Ninja ninja) { _ninja = ninja ?? new Ninja(); }

        // Field
        private readonly Ninja _ninja;
        private Equip _categoryHead;
        private Equip _categoryShoulders;
        private Equip _categoryChest;
        private Equip _categoryBelt;
        private Equip _categoryLegs;
        private Equip _categoryBoots;

        // Property
        public ICollection<Equip> Equips
        {
            get { return _ninja.Equips;}
            set
            {
                _ninja.Equips = value;
                ReloadEquipment();
                RaisePropertyChanged();
            }
        }

        public int NinjaId
        {
            get { return _ninja.NinjaId; }
            set
            {
                _ninja.NinjaId = value;
                RaisePropertyChanged();            
            }
        }

        public double Budget
        {
            get { return _ninja.Budget; }
            set
            {
                _ninja.Budget = value;
                RaisePropertyChanged();             
            }
        }

        public Equip CategoryHead
        {
            get { return _categoryHead; }
            set
            {
                _categoryHead = value;
                RaisePropertyChanged();               
            }
        }

        public Equip CategoryShoulders
        {
            get { return _categoryShoulders; }
            set
            {
                _categoryShoulders = value;
                RaisePropertyChanged();
            }
        }

        public Equip CategoryChest
        {
            get { return _categoryChest; }
            set
            {
                _categoryChest = value;
                RaisePropertyChanged();
            }
        }

        public Equip CategoryBelt
        {
            get { return _categoryBelt; }
            set
            {
                _categoryBelt = value;
                RaisePropertyChanged();
            }
        }

        public Equip CategoryLegs
        {
            get { return _categoryLegs; }
            set
            {
                _categoryLegs = value;
                RaisePropertyChanged();
            }
        }

        public Equip CategoryBoots
        {
            get { return _categoryBoots; }
            set
            {
                _categoryBoots = value;
                RaisePropertyChanged();
            }
        }

      

        public void ReloadEquipment()
        {
            foreach (Equip equip in Equips)
            {
                if (equip.CategoryId == 0)
                {
                    CategoryHead = equip;
                 
                }
                else if (equip.CategoryId == 1)
                {
                    CategoryShoulders = equip;
                }
                else if (equip.CategoryId == 2)
                {
                    CategoryChest = equip;

                }
                else if (equip.CategoryId == 3)
                {
                    CategoryBelt = equip;
                }
                else if (equip.CategoryId == 4)
                {
                    CategoryLegs = equip;
                }
                else if (equip.CategoryId == 5)
                {
                    CategoryBoots = equip;
                }

            }
        }

        // Method
        //public Afdeling ToEntity() { return new Afdeling { AfdelingNaam = AfdelingNaam, Omschrijving = Omschrijving }; }

    }
}
