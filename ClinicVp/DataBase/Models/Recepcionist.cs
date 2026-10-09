using ClinicVp.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("recepcionist")]
    public class Recepcionist : People
    {

        [Column("admission_date")]
        public DateTime AdmissionDate { get; set; }

        [Column("salary")]
        public decimal Salary { get; set; }

        [Column("status")]
        public EStatusEmployee Status { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("must_change_password")]
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
