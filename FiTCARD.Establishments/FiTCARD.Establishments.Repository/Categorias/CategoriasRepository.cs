using FiTCARD.Establishments.Model.Categorias;
using FiTCARD.Establishments.Repository.Master;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace FiTCARD.Establishments.Repository.Categorias
{
    public class CategoriasRepository : MasterRepository, ICategoriasRepository
    {
        public CategoriasRepository(IConfiguration config) : base(config) { }

        public IEnumerable<CategoriasModel> GetList()
        {
            var query = "SELECT * FROM [dbo].[Categorias]";

            var _categorias = QueryList<CategoriasModel>(base.GetConnection(), query);

            return _categorias;
        }

        public void Delete(CategoriasModel obj)
        {
            throw new NotImplementedException();
        }

        public CategoriasModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert()
        {
            throw new NotImplementedException();
        }

        public void Update(CategoriasModel obj)
        {
            throw new NotImplementedException();
        }
    }
}