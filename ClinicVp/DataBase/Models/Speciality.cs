using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("speciality")]
    public class Speciality
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("speciality_name")]
        public string SpecialityName { get; set; }

        public Speciality(string specialityName)
        {
            SpecialityName = specialityName;
        }

    }
}
