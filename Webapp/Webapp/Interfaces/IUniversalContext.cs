using System.Collections.Generic;
using Webapp.Models.Data;

namespace Webapp.Interfaces
{
    public interface IUniversalContext<T> where T : Entity
    {
        List<T> GetAll();
        T GetById(long id);

        long Insert(T obj);
        bool Update(T obj);
        bool Delete(T obj);
    }
}