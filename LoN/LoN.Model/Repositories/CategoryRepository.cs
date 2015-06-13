using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoN.Model.Interfaces;
using LoN.Model.Models;
using LoN.Model.Context;
using System.Data.Entity;

namespace LoN.Model.Repositories
{
    public class CategoryRepository : IGenericRepository<Category>
    {

        public AppContext Context { get; set; }
        
        public IEnumerable<Category> GetAll()
        {
            using (var Context = new AppContext())
            {
                return Context.Category.ToList();
            }    
        }

        public Category GetOne(int key)
        {
            using (var Context = new AppContext())
            {
                return Context.Category.Find(key);
            }
        }

        public void Delete(Category entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Create(Category entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        public void Update(Category updatedEntity)
        {
            Context.Entry(updatedEntity).State = EntityState.Modified;  
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
