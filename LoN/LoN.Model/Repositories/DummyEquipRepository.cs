using LoN.Model.Interfaces;
using LoN.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.Model.Repositories
{
    public class DummyEquipRepository : IGenericRepository<Equip>
    {
        private List<Equip> myEquipList;

        public DummyEquipRepository() 
        {
            myEquipList = new List<Equip>
            {
                new Equip(){  EquipId = 0, EquipName="Bandana", Price = 10, Strength= 5, Intelligence = -2, Agillity = 5, CategoryId = 0},
                new Equip(){  EquipId = 1, EquipName="Crown", Price = 100, Strength= -5, Intelligence = 25, Agillity = 5, CategoryId = 0},
                new Equip(){  EquipId = 2, EquipName="Pauldrons", Price = 50, Strength= 25, Intelligence = -3, Agillity = 2, CategoryId = 1},
                new Equip(){  EquipId = 3, EquipName="Leather pads", Price = 40, Strength= 13, Intelligence = -10, Agillity = 10, CategoryId = 1},
                new Equip(){  EquipId = 4, EquipName="Iron chest", Price = 50, Strength= 25, Intelligence = -10, Agillity = 10, CategoryId = 2},
                new Equip(){  EquipId = 5, EquipName="Steel chest", Price = 50, Strength= 30, Intelligence = -10, Agillity = 15, CategoryId = 2},
                new Equip(){  EquipId = 6, EquipName="Yellow belt", Price = 30, Strength= -5, Intelligence =  30, Agillity = 10, CategoryId = 3},
                new Equip(){  EquipId = 7, EquipName="Iron chest", Price = 20, Strength= 5, Intelligence = -3, Agillity = 25, CategoryId = 3},
                new Equip(){  EquipId = 8, EquipName="Fuzzy legs", Price = 50, Strength= -50, Intelligence = 40, Agillity = 10, CategoryId = 4},
                new Equip(){  EquipId = 9, EquipName="Fancy pants", Price = 5, Strength= 5, Intelligence = -5, Agillity = 30, CategoryId = 4},
                new Equip(){  EquipId = 10, EquipName="Swift boots", Price = 50, Strength= 25, Intelligence = -10, Agillity = 10, CategoryId = 5},
                new Equip(){  EquipId = 11, EquipName="Jerusalem nikes", Price = 1, Strength= 99, Intelligence = 99, Agillity = 99, CategoryId = 5}        
            };
        }

        public Context.AppContext Context
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Equip> GetAll()
        {
            return myEquipList;
        }

        public Equip GetOne(int key)
        {
            return myEquipList.Where(x => x.EquipId == key).ToList()[0];
        }

        public void Delete(Equip entity)
        {
            myEquipList.Remove(entity);
        }

        public Equip Create(Equip entity)
        {
            entity.EquipId = myEquipList.Max(x => (x.EquipId + 1));
            myEquipList.Add(entity);
            return entity;
        }

        public void Update(Equip updatedEntity)
        {      
            var toUpdate = myEquipList.Where(x => x.EquipId == updatedEntity.EquipId).ToArray()[0];
            toUpdate.Agillity = updatedEntity.Agillity;
            toUpdate.CategoryId = updatedEntity.CategoryId;
            toUpdate.EquipName = updatedEntity.EquipName;
            toUpdate.Intelligence = updatedEntity.Intelligence;
            toUpdate.Price = updatedEntity.Price;
            toUpdate.Strength = updatedEntity.Strength;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
