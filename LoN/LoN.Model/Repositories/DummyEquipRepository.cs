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
            throw new NotImplementedException();
        }

        public Equip GetOne(int key)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public void Create(Equip entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int originalKey, Equip updatedEntity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
