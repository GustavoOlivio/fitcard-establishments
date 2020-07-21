using FiTCARD.Establishments.Model.Categorias;
using FiTCARD.Establishments.Repository.Categorias;
using System;
using System.Collections.Generic;

namespace FiTCARD.Establishments.Service.Categorias
{
    public class CategoriasService : ICategoriasService
    {
        private readonly ICategoriasRepository categoriasRepository;

        public CategoriasService(ICategoriasRepository categoriasRepository)
        {
            this.categoriasRepository = categoriasRepository;
        }

        public void Delete(CategoriasModel obj)
        {
            throw new NotImplementedException();
        }

        public CategoriasModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriasModel> GetList()
        {
            var _categorias = categoriasRepository.GetList();

            return _categorias;
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