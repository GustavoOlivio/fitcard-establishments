using System;
using System.Collections.Generic;

namespace FiTCARD.Establishments.Repository.Master
{
    public interface IMasterRepository
    {
        string GetConnection();
        IEnumerable<T> QueryList<T>(string query, Object parameters = null);
        T QueryGetById<T>(string query, int id);
        void QueryUpdate(string query, Object obj);
        int QueryInsert<T>(string query, Object obj);
        void QueryDelete(string query, int id);
    }
}