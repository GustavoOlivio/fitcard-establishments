using System;
using System.Collections.Generic;

namespace FiTCARD.Establishments.Repository.Master
{
    public interface IMasterRepository
    {
        string GetConnection();
        IEnumerable<T> QueryList<T>(string stringConnection, string query, Object parameters = null);
    }
}