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
            return Context.Equip.Find(key);
        }

        public void Delete(Equip entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Create(Equip entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        public void Update(Equip updatedEntity)
        {
            Context.Entry(updatedEntity).State = EntityState.Modified;  
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
