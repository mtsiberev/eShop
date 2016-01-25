using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public interface IRepository<T>
    {
        int Add(T entity);
        void Delete(int id);
        void Update(T entity);
        List<T> GetAll();
        T GetById(int id);
    }
}
