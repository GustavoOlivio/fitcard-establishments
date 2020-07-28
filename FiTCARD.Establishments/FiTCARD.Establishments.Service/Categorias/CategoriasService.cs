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

        public Dictionary<string, string> GetEstados()
        {
            var estados = new Dictionary<string, string>();

            estados.Add("AC", "Acre");
            estados.Add("AL", "Alagoas");
            estados.Add("AP", "Amapá");
            estados.Add("AM", "Amazonas");
            estados.Add("BA", "Bahia");
            estados.Add("CE", "Ceará");
            estados.Add("DF", "Distrito Federal");
            estados.Add("ES", "Espírito Santo");
            estados.Add("GO", "Goiás");
            estados.Add("MA", "Maranhão");
            estados.Add("MT", "Mato Grosso");
            estados.Add("MS", "Mato Grosso do Sul");
            estados.Add("MG", "Minas Gerais");
            estados.Add("PA", "Pará");
            estados.Add("PB", "Paraíba");
            estados.Add("PR", "Paraná");
            estados.Add("PE", "Pernambuco");
            estados.Add("PI", "Piauí");
            estados.Add("RJ", "Rio de Janeiro");
            estados.Add("RN", "Rio Grande do Norte");
            estados.Add("RS", "Rio Grande do Sul");
            estados.Add("RO", "Rondônia");
            estados.Add("RR", "Roraima");
            estados.Add("SC", "Santa Catarina");
            estados.Add("SP", "São Paulo");
            estados.Add("SE", "Sergipe");
            estados.Add("TO", "Tocantins");

            return estados;
        }
    }
}