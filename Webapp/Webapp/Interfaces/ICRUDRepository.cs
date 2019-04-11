using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Interfaces
{
    /// <summary>
    /// CRUD Repository:
    /// C Create
    /// R Read
    /// U Update
    /// D Delete
    /// </summary>
    public interface ICRUDRepository<T>
    {
        List<T> GetAll();
        T GetById(long id);

        long Insert(T obj);
        bool Update(T obj);
        bool Delete(T obj);
    }
}
