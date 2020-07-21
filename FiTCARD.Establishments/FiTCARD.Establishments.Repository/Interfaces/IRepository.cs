using System.Collections.Generic;

namespace FiTCARD.Establishments.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetList();
        int Insert();
        void Update(T obj);
        void Delete(T obj);
    }
}