using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("speciality")]
    public class Speciality
    {
        [Key]
        [Column("id")]
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public int Id { get; set; }

        [Column("speciality_name")]
        [Required(ErrorMessage = "A especialidade é obrigatória.")]
        [StringLength(50, ErrorMessage = "A especialidade não pode ultrapassar 50 caracteres.")]
        public string SpecialityName { get; set; }

        public Speciality(string specialityName)
        {
            SpecialityName = specialityName;
        }

    }
}
