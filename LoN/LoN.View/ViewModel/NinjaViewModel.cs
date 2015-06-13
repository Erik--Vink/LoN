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
        public NinjaViewModel() { _ninja = new Ninja(); _ninja.Budget = 500; }
        public NinjaViewModel(Ninja ninja) { _ninja = ninja ?? new Ninja(); }

        // Field
        private readonly Ninja _ninja;
        private Equip _categoryHead;
        private Equip _categoryShoulders;
        private Equip _categoryChest;
        private Equip _categoryBelt;
        private Equip _categoryLegs;
        private Equip _categoryBoots;
        private int _ninjaStrength;
        private int _ninjaAgillity;
        private int _ninjaIntelligence;
        private int _gearvalue;

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

        public int NinjaStrength
        {
            get { return _ninjaStrength; }
            set
            {
                _ninjaStrength = value;
                RaisePropertyChanged();
            }
        }
        public int NinjaAgillity
        {
            get { return _ninjaAgillity; }
            set
            {
                _ninjaAgillity = value;
                RaisePropertyChanged();
            }
        }
        public int NinjaIntelligence
        {
            get { return _ninjaIntelligence; }
            set
            {
                _ninjaIntelligence = value;
                RaisePropertyChanged();
            }
        }

        public int GearValue
        {
            get { return _gearvalue; }
            set
            {
                _gearvalue = value;
                RaisePropertyChanged();
            }
        }

        public void AddEquipment(Equip equip)
        {
            _ninja.Budget       -= equip.Price;
            _gearvalue          += equip.Price;
            _ninjaStrength      += equip.Strength;
            _ninjaAgillity      += equip.Agillity;
            _ninjaIntelligence  += equip.Intelligence;
            Equips.Add(equip);
        }

        public void RemoveEquipment(Equip equip)
        {
            _ninja.Budget       += equip.Price;
            _gearvalue          -= equip.Price;
            _ninjaStrength      -= equip.Strength;
            _ninjaAgillity      -= equip.Agillity;
            _ninjaIntelligence  -= equip.Intelligence;
            Equips.Remove(equip);
        }

        public void ReloadEquipment()
        {
            foreach (Equip equip in Equips)
            {
                if (equip.CategoryId == 1)
                {
                    CategoryHead = equip;
                 
                }
                else if (equip.CategoryId == 2)
                {
                    CategoryShoulders = equip;
                }
                else if (equip.CategoryId == 3)
                {
                    CategoryChest = equip;

                }
                else if (equip.CategoryId == 4)
                {
                    CategoryBelt = equip;
                }
                else if (equip.CategoryId == 5)
                {
                    CategoryLegs = equip;
                }
                else if (equip.CategoryId == 6)
                {
                    CategoryBoots = equip;
                }

            }
        }

        // Method
        //public Afdeling ToEntity() { return new Afdeling { AfdelingNaam = AfdelingNaam, Omschrijving = Omschrijving }; }

    }
}
