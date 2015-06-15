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
            using (var Context = new AppContext())
            {
                return Context.Ninja.ToList();
            }
        }

        public Ninja GetOne(int key)
        {
            using (var Context = new AppContext())
            {
                return Context.Ninja.Find(key);
            }
        }

        public void Delete(Ninja entity)
        {
            using (var Context = new AppContext())
            {
                Context.Entry(entity).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public Ninja Create(Ninja entity)
        {
            using (var Context = new AppContext())
            {
                Context.Entry(entity).State = EntityState.Added;
                Context.SaveChanges();
                Context.Entry(entity).GetDatabaseValues();
                return entity;
            }        
        }

        public void Update(Ninja updatedEntity)
        {
            using (var Context = new AppContext())
            {
                Context.Entry(updatedEntity).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public void Save()
        {
            using (var Context = new AppContext())
            {
                Context.SaveChanges();
            }
        }
    }
}
