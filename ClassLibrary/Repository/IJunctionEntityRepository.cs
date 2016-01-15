using System;
using System.Collections.Generic;

namespace ClassLibrary.Repository
{
    public interface IJunctionEntityRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void DeleteByCompoundId(int orderId, int productId);
        T GetByCompoundId(int orderId, int productId);
        List<T> GetAll();
        List<T> GetAllByFirstKeyId(int id);
        List<T> GetAllBySecondKeyId(int id);
    }
}
