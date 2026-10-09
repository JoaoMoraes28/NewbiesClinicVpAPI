using ClinicVp.DataBase.Models.Enums;

namespace ClinicVp.DataBase.DTOs
{
    public class DoctorCreateUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public string Crm { get; set; } = string.Empty;
        public int CrmUfId { get; set; }
        public string Password { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public EGender Gender { get; set; }

        public EStatusEmployee Status { get; set;}
    }

    public class DoctorResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Crm { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool Active { get; set; }
    }
}