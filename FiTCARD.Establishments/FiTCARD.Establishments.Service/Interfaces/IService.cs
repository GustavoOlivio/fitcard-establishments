using System.Collections.Generic;

namespace FiTCARD.Establishments.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetList();
        int Insert();
        void Update(T obj);
        void Delete(T obj);
    }
}