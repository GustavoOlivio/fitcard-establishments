using System;

namespace FiTCARD.Establishments.Model.Estabelecimentos
{
    public class EstabelecimentosModel
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
        public bool Ativo { get; set; }
        public string BancoAgencia { get; set; }
        public string BancoConta { get; set; }
    }
}