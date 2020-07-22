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
        private readonly IConfiguration _configuration;

        public MasterRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string GetConnection()
        {
            return _configuration.GetSection("StringConnections").GetSection("ConnectionStringEstablishments").Value;
        }

        public IEnumerable<T> QueryList<T>(string query, Object parameters = null)
        {
            using (var con = new SqlConnection(GetConnection()))
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

        public T QueryGetById<T>(string query, int id)
        {
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    var retorno = con.QueryFirstOrDefault<T>(query, new { id });

                    return retorno;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void QueryUpdate(string query, object obj)
        {
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Execute(query, obj);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public int QueryInsert<T>(string query, object obj)
        {
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    var retorno = con.Query<int>(query, obj).FirstOrDefault();

                    return retorno;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void QueryDelete(string query, int id)
        {
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Execute(query, new { id });
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}