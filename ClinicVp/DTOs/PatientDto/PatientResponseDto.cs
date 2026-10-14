using ClinicVp.DataBase.DTOs.PatientAddress;
using ClinicVp.DataBase.Models.Enums;


namespace ClinicVp.DTOs.PatientDto
{

    public class PatientResponseBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Professional { get; set; }
        public DateOnly BornDate { get; set; }
        public bool Active { get; set; }

        public PatientResponseBase(int id, string name, string cpf, string email, string phone, string? professional, DateOnly bornDate, bool active)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Email = email;
            Phone = phone;
            Professional = professional;
            BornDate = bornDate;
            Active = active;
        }
    }

    public class PatientResponseDto
    {
        public PatientResponseBase Patient { get; set; }
        public PatientAddressResponseDto Address { get; set; }
        public PatientResponseDto(PatientResponseBase patient, PatientAddressResponseDto address)
        {
            Patient = patient;
            Address = address;
        }
    }
}