using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiTCARD.Establishments.Model.Estabelecimentos
{
    [Table("Estabelecimentos")]
    public class EstabelecimentosModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("RazaoSocial")]
        public string RazaoSocial { get; set; }

        [Column("NomeFantasia")]
        public string NomeFantasia { get; set; }

        [Required]
        [Column("CNPJ")]
        public string CNPJ { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Endereco")]
        public string Endereco { get; set; }

        [Column("Cidade")]
        public string Cidade { get; set; }

        [Column("Estado")]
        public string Estado { get; set; }

        [Column("Telefone")]
        public string Telefone { get; set; }

        [Required]
        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [Column("CategoriaId")]
        public int CategoriaId { get; set; }

        [Required]
        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("BancoAgencia")]
        public string BancoAgencia { get; set; }

        [Column("BancoConta")]
        public string BancoConta { get; set; }
    }
}