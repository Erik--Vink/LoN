using LoN.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoN.Model.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        AppContext Context { get; set; }
        IEnumerable<T> GetAll();
        T GetOne(int key);
        void Delete(T entity);
        T Create(T entity);
        void Update(T updatedEntity);
        void Save();
    }
}
