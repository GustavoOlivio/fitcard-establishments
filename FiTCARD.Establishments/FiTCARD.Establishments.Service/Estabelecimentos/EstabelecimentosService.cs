using FiTCARD.Establishments.Model.Estabelecimentos;
using FiTCARD.Establishments.Repository.Categorias;
using FiTCARD.Establishments.Repository.Estabelecimentos;
using FiTCARD.Establishments.Service.Util;
using System;
using System.Collections.Generic;

namespace FiTCARD.Establishments.Service.Estabelecimentos
{
    public class EstabelecimentosService : IEstabelecimentosService
    {
        private readonly IEstabelecimentosRepository repository;
        private readonly ICategoriasRepository categoriasRepository;
        public EstabelecimentosService(IEstabelecimentosRepository repository, ICategoriasRepository categoriasRepository)
        {
            this.repository = repository;
            this.categoriasRepository = categoriasRepository;
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
            ValidaCNPJ(obj.CNPJ);

            ValidaTelefoneObrigatorio(obj.CategoriaId, obj.Telefone);

            repository.Update(obj);
        }

        private void ValidaCNPJ(string CNPJ)
        {
            if (!ValidaDoc.Cnpj(CNPJ))
                throw new Exception("CNPJ Inválido!");
        }

        public int Insert(EstabelecimentosModel obj)
        {
            ValidaCNPJ(obj.CNPJ);

            ValidaTelefoneObrigatorio(obj.CategoriaId, obj.Telefone);

            var estabelecimentoId = repository.Insert(obj);

            if (estabelecimentoId > 0)
                return estabelecimentoId;
            else
                throw new Exception("Erro ao inserir o estabelecimento!");
        }

        private void ValidaTelefoneObrigatorio(int categoriaId, string telefone)
        {
            var ehObrigatorio = categoriasRepository.Get(categoriaId).TelefoneObrigatorio;

            if (ehObrigatorio && string.IsNullOrEmpty(telefone))
                throw new Exception("Campo telefone Obrigatório!");
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}