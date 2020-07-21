using FiTCARD.Establishments.Repository.Categorias;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FiTCARD.Establishments.Test.Repository.Categorias
{
    public class CategoriasRepositoryTest
    {
        private readonly ICategoriasRepository _categoriasRepository;

        public CategoriasRepositoryTest(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        [Fact]
        public void GetCategorias()
        {
           _categoriasRepository.GetList();
            Assert.True(_categoriasRepository != null);
        }
    }
}