using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoN.Model.Interfaces;
using LoN.Model.Models;

namespace LoN.Model.Repositories
{
    public class DummyCategoryRepository : IGenericRepository<Category>
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

        IEnumerable<Category> IGenericRepository<Category>.GetAll()
        {
            throw new NotImplementedException();
        }

        Category IGenericRepository<Category>.GetOne(int key)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int originalKey, Category updatedEntity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
