using System;
using System.Collections.Generic;

namespace ClassLibrary.Repository
{
    public interface IJunctionEntityRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void DeleteByCompoundId(int id1, int id2);
        T GetByCompoundId(int id1, int id2);
        List<T> GetAll();
        List<T> GetAllByFirstKeyId(int id);
        List<T> GetAllBySecondKeyId(int id);
    }
}
