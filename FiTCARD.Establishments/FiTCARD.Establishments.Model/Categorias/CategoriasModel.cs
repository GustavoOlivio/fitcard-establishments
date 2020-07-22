using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiTCARD.Establishments.Model.Categorias
{
    [Table("Categorias")]
    public class CategoriasModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required]
        [Column("TelefoneObrigatorio")]
        public bool TelefoneObrigatorio { get; set; }

        [Required]
        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }
        
        [Required]
        [Column("Ativo")]
        public bool Ativo { get; set; }
    }
}