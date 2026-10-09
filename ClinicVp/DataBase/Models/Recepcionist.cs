using ClinicVp.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("recepcionist")]
    public class Recepcionist : People
    {

        public DateTime AdmissionDate { get; set; }

        public decimal Salary { get; set; }

        public EStatusEmployee Status { get; set; }

        public string Password { get; set; }

        public bool MustChangePassword { get; set; }

        public Recepcionist(string name, string cpf, string email, EGender gender, string phone,
            string photo, DateTime admissionDate, decimal salary, EStatusEmployee status,
            string password, bool mustChangePassword)
            : base(name, cpf, email, gender, phone, photo)
        {

            AdmissionDate = admissionDate;
            Salary = salary;
            Status = status;
            Password = password;
            MustChangePassword = mustChangePassword;

        }

    }
}
