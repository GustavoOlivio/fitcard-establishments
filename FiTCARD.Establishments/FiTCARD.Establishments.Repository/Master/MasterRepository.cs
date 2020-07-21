using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FiTCARD.Establishments.Repository.Master
{
    public class MasterRepository : IMasterRepository
    {
        public IConfiguration _configuration;

        public MasterRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string GetConnection()
        {
            return _configuration.GetSection("StringConnections").GetSection("ConnectionStringEstablishments").Value;
        }

        public IEnumerable<T> QueryList<T>(string stringConnection, string query, Object parameters = null)
        {
            using (var con = new SqlConnection(stringConnection))
            {
                try
                {
                    var retorno = con.Query<T>(query, parameters).ToList();

                    return retorno;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}