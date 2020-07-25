using FiTCARD.Establishments.Model.Categorias;
using FiTCARD.Establishments.Repository.Categorias;
using FiTCARD.Establishments.Service.Categorias;
using Moq;
using System;
using Xunit;

namespace FiTCARD.Establishments.Test.Repository.Categorias
{
    public class CategoriasRepositoryTest
    {
        [Fact]
        public void DeveBuscarCategorias()
        {
            var categoria = new CategoriasModel
            {
                Nome = "Hotel",
                TelefoneObrigatorio = false,
                DataCadastro = DateTime.Now
            };

            var categoriaMock = new Mock<ICategoriasRepository>();

            var categoriasGetList = new CategoriasService(categoriaMock.Object);

            categoriasGetList.GetList();

            categoriaMock.Verify(r => r.GetList());
        }
    }
}