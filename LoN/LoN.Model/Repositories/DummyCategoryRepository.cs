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
            List<Category> categories = new List<Category>
            {
                new Category(){ CategoryId = 0, CategoryName = "Head"},
                new Category(){ CategoryId = 1, CategoryName = "Shoulders" },
                new Category(){ CategoryId = 2, CategoryName = "Chest" },
                new Category(){ CategoryId = 3, CategoryName = "Belt" },
                new Category(){ CategoryId = 4, CategoryName = "Legs" },
                new Category(){ CategoryId = 5, CategoryName = "Boots" }
            };

            return categories;
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
