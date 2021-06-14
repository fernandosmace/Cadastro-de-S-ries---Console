

using System;
using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T GetSerie(Guid id);
        void Insert(T entity);
        void Delete(Guid id);
        void Update(Guid id, T entity);
        Guid NextId();

    }
}