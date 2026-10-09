using ClinicVp.DataBase.Models.Enums;

namespace ClinicVp.DataBase.DTOs
{
    public class PatientCreateUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public string? Professional { get; set; }
        public EGender Gender { get; set; }
        public ECivilState CivilState { get; set; }
        public EBloodType? BloodType { get; set; }
        public decimal? Weight { get; set; }
        public int? Height { get; set; }
        public DateTime BornDate { get; set; }
        public string? PhoneEmergency { get; set; }
        public string? Notes { get; set; }
    }

    public class PatientResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Professional { get; set; }
        public DateTime BornDate { get; set; }
        public bool Active { get; set; }
    }
}