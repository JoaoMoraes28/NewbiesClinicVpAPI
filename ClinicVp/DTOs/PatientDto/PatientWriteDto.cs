using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DTOs.PatientAddressDto;
using ClinicVp.DTOs.PatientDto;

namespace ClinicVp.DTOs.PatientDto
{
    public class PatientWriteDto
    {

        public PatientBase Patient { get; set; }

        public PatientWriteAddressDto Address { get; set; }

        public PatientWriteDto(PatientBase patient, PatientWriteAddressDto address)
        {
            Patient = patient;
            Address = address;
        }

        public class PatientBase
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
            public DateOnly BornDate { get; set; }
            public string? PhoneEmergency { get; set; }
            public string? Notes { get; set; }

            public PatientBase(string name, string cpf, string email, string phone, string? photo, string? professional, EGender gender, ECivilState civilState, EBloodType? bloodType, decimal? weight, int? height, DateOnly bornDate, string? phoneEmergency, string? notes)
            {
                Name = name;
                Cpf = cpf;
                Email = email;
                Phone = phone;
                Photo = photo;
                Professional = professional;
                Gender = gender;
                CivilState = civilState;
                BloodType = bloodType;
                Weight = weight;
                Height = height;
                BornDate = bornDate;
                PhoneEmergency = phoneEmergency;
                Notes = notes;
            }

        }
    }
}
