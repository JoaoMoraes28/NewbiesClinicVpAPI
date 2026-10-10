using ClinicVp.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{

    public class People
    {
        [Key]
        [Column("id")]
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public int Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(11, ErrorMessage = "O nome não pode ultrapassar 255 caracteres.")]
        public string Name { get; set; }

        [Column("cpf")]
        [Required(ErrorMessage = "O cpf é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF não pode ultrapassar 11 caracteres.")]
        public string Cpf { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "O email é obrigatório.")]
        [StringLength(11, ErrorMessage = "O email não pode ultrapassar 255 caracteres.")]
        public string Email { get; set; }

        [Column("gender")]
        [Required(ErrorMessage = "O gênero é obrigatório.")]
        public EGender Gender { get; set; }

        [Column("phone")]
        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(11, ErrorMessage = "O telefone não pode ultrapassar 11 caracteres.")]
        public string Phone { get; set; }

        [Column("photo")]
        [StringLength(11, ErrorMessage = "A foto não pode ultrapassar 255 caracteres.")]
        public string? Photo { get; set; }


        public People(string name, string cpf, string email, EGender gender, string phone, string? photo)
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
