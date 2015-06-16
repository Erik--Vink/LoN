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
        private List<Category> myCatList;

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

        public DummyCategoryRepository()
        {
            myCatList = new List<Category>
            {
                new Category(){ CategoryId = 0, CategoryName = "Head"},
                new Category(){ CategoryId = 1, CategoryName = "Shoulders" },
                new Category(){ CategoryId = 2, CategoryName = "Chest" },
                new Category(){ CategoryId = 3, CategoryName = "Belt" },
                new Category(){ CategoryId = 4, CategoryName = "Legs" },
                new Category(){ CategoryId = 5, CategoryName = "Boots" }
            };
        }

        public IEnumerable<Category> GetAll()
        {
            return myCatList;
        }

        public Category GetOne(int key)
        {
            return myCatList.Where(x => x.CategoryId == key).ToList()[0];
        }

        public void Delete(Category entity)
        {
            myCatList.Remove(entity);
        }

        public Category Create(Category entity)
        {
            entity.CategoryId = myCatList.Max(x => (x.CategoryId + 1));
            myCatList.Add(entity);
            return entity;
        }

        public void Update(Category updatedEntity)
        {
            var toUpdate = myCatList.Where(x => x.CategoryId == updatedEntity.CategoryId).ToList()[0];
            toUpdate = updatedEntity;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
