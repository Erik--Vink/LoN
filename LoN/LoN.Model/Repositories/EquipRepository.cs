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
    public class EquipRepository : IGenericRepository<Equip>
    {

        public AppContext Context { get; set; }
        
        public IEnumerable<Equip> GetAll()
        {
            using (var Context = new AppContext())
            {
                return Context.Equip.ToList();
            }
        }

        public Equip GetOne(int key)
        {
            using (var Context = new AppContext())
            {
                return Context.Equip.Find(key);
            }
        }

        public void Delete(Equip entity)
        {
            using (var Context = new AppContext()) 
            {
                Context.Entry(entity).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public Equip Create(Equip entity)
        {
            using (var Context = new AppContext())
            {
                Context.Entry(entity).State = EntityState.Added;              
                Context.SaveChanges();
                Context.Entry(entity).GetDatabaseValues();
                return entity;
            }
        }

        public void Update(Equip updatedEntity)
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
