using ClinicVp.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("recepcionist")]
    public class Recepcionist : People
    {

        [Column("admission_date")]
        [Required(ErrorMessage = "A data data de admissão é obrigatória.")]
        public DateOnly AdmissionDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Column("salary")]
        [Required(ErrorMessage = "O salário é obrigatório.")]
        public decimal Salary { get; set; }

        [Column("status")]
        [Required(ErrorMessage = "O status é obrigatório.")]
        public EStatusEmployee Status { get; set; }

        [Column("password")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(255, ErrorMessage = "A senha não pode ultrapassar os 255 caracteres.")]
        public string Password { get; set; }

        [Column("must_change_password")]
        [Required(ErrorMessage = "O valor referente a trocas de senha é obrigatório.")]
        public bool MustChangePassword { get; set; }
        public Recepcionist(string name, string cpf, string email, EGender gender, string phone,
            string photo, decimal salary, EStatusEmployee status,
            string password)
            : base(name, cpf, email, gender, phone, photo)
        {

            Salary = salary;
            Status = status;
            Password = password;

        }

    }
}
