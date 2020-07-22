using FiTCARD.Establishments.Model.Categorias;
using FiTCARD.Establishments.Repository.Categorias;
using System;
using System.Collections.Generic;

namespace FiTCARD.Establishments.Service.Categorias
{
    public class CategoriasService : ICategoriasService
    {
        private readonly ICategoriasRepository repository;

        public CategoriasService(ICategoriasRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<CategoriasModel> GetList()
        {
            var _categorias = repository.GetList();

            return _categorias;
        }

        public CategoriasModel Get(int id)
        {
            var categoria = repository.Get(id);

            if (categoria != null)
                return categoria;
            else
                throw new Exception("Categoria não encontrada!");
        }

        public void Update(CategoriasModel obj)
        {
            repository.Update(obj);
        }

        public int Insert(CategoriasModel categoria)
        {
            var categoriaId = repository.Insert(categoria);

            if (categoriaId > 0)
                return categoriaId;
            else
                throw new Exception("Erro ao inserir a categoria!");
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}