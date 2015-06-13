using LoN.Model.Interfaces;
using LoN.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.Model.Repositories
{
    public class DummyNinjaRepository : IGenericRepository<Ninja>
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

        public IEnumerable<Ninja> GetAll()
        {
            throw new NotImplementedException();
        }

        public Ninja GetOne(int key)
        {
            throw new NotImplementedException();
        }

        public void Delete(Ninja entity)
        {
            throw new NotImplementedException();
        }

        public void Create(Ninja entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Ninja updatedEntity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
