using FiTCARD.Establishments.Model.Estabelecimentos;
using FiTCARD.Establishments.Repository.Estabelecimentos;
using System;
using System.Collections.Generic;

namespace FiTCARD.Establishments.Service.Estabelecimentos
{
    public class EstabelecimentosService : IEstabelecimentosService
    {
        private readonly IEstabelecimentosRepository repository;
        public EstabelecimentosService(IEstabelecimentosRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<EstabelecimentosModel> GetList()
        {
            var _estabelecimentos = repository.GetList();

            return _estabelecimentos;
        }

        public EstabelecimentosModel Get(int id)
        {
            var estabelecimento = repository.Get(id);

            if (estabelecimento != null)
                return estabelecimento;
            else
                throw new Exception("Estabelecimento não encotrado!");
        }

        public void Update(EstabelecimentosModel obj)
        {
            repository.Update(obj);
        }

        public int Insert(EstabelecimentosModel obj)
        {
            var estabelecimentoId = repository.Insert(obj);

            if (estabelecimentoId > 0)
                return estabelecimentoId;
            else
                throw new Exception("Erro ao inserir o estabelecimento!");
        }
            
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}