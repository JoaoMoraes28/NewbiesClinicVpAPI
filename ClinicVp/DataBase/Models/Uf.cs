using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("uf")]
    public class Uf
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "A sigla é obrigatória.")]
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres.")]
        public string Name { get; set; }

        [Column("abbreviation")]
        [Required(ErrorMessage = "A sigla é obrigatória.")]
        [StringLength(2, ErrorMessage = "Máximo de 2 caracteres.")]
        public string Abbreviation { get; set; }

        public Uf(string name, string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
        }

    }
}
