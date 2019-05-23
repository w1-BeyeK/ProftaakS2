using System.Collections.Generic;
using Webapp.Models.Data;

namespace Webapp.Interfaces
{
    /// <summary>
    /// CRUD Repository:
    /// C Create
    /// R Read
    /// U Update
    /// D Delete
    /// </summary>
    /// 
    public interface IUniversalGenerics<T> where T : Entity
    {
        List<T> GetAll();
        T GetById(long id);

        long Insert(T obj);
        bool Update(T obj);
        bool Delete(T obj);
    }
}