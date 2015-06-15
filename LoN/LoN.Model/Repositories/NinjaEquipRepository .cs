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
    public class NinjaEquipRepository : IGenericRepository<NinjaEquip>
    {

        public AppContext Context { get; set; }

        public IEnumerable<NinjaEquip> GetAll()
        {
            using (var Context = new AppContext())
            {
                return Context.NinjaEquip.ToList();
            }
        }

        public NinjaEquip GetOne(int key)
        {
            using (var Context = new AppContext())
            {
                return Context.NinjaEquip.Find(key);
            }
        }

        public void Delete(NinjaEquip entity)
        {
            using (var Context = new AppContext())
            {
                Context.Entry(entity).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public NinjaEquip Create(NinjaEquip entity)
        {
            using (var Context = new AppContext())
            {
                Context.Entry(entity).State = EntityState.Added;
                Context.SaveChanges();
            }
            return null;
        }

        public void Update(NinjaEquip updatedEntity)
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
