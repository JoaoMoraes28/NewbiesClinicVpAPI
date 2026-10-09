using ClinicVp.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{

    public class People
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("gender")]
        public EGender Gender { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("photo")]
        public string Photo { get; set; }


        public People(string name, string cpf, string email, EGender gender, string phone, string photo)
        {

            Name = name;
            Cpf = cpf;
            Email = email;
            Gender = gender;
            Phone = phone;
            Photo = photo;

        }

    }
}
