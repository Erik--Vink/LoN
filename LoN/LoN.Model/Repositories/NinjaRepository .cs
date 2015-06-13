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
    public class NinjaRepository : IGenericRepository<Ninja>
    {

        public AppContext Context { get; set; }

        public IEnumerable<Ninja> GetAll()
        {
            return Context.Ninja.AsEnumerable();
        }

        public Ninja GetOne(int key)
        {
            return Context.Ninja.Find(key);
        }

        public void Delete(Ninja entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Create(Ninja entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        public void Update(Ninja updatedEntity)
        {
            Context.Entry(updatedEntity).State = EntityState.Modified;  
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
