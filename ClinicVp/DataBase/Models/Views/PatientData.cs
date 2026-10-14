using ClinicVp.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models.Views
{
    public class PatientData
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("professional")]
        public string? Professional { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("gender")]
        public EGender Gender { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("civil_state")]
        public ECivilState CivilState { get; set; }

        [Column("photo")]
        public string? Photo { get; set; }

        [Column("blood_type")]
        public EBloodType BloodType { get; set; }

        [Column("weight")]
        public decimal? Weight { get; set; }

        [Column("height")]
        public int? Height { get; set; }

        [Column("born_date")]
        public DateOnly BornDate { get; set; }

        [Column("phone_emergency")]
        public string? PhoneEmergency { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }

        [Column("record_date")]
        public DateOnly RecordDate { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("medical_record_id")]
        public int MedicalRecordId { get; set; }

        [Column("uf_address")]
        public string UfAddress { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("district")]
        public string District { get; set; }

        [Column("street")]
        public string Street { get; set; }

        [Column("number")]
        public string Number { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        public PatientData(
            int id, string name, string? professional, string cpf, EGender gender, string phone,
            string email, ECivilState civilState, string? photo, EBloodType bloodType, decimal? weight,
            int? height, DateOnly bornDate, string? phoneEmergency, string? notes,
            DateOnly recordDate, bool active, int medicalRecordId, string ufAddress,
            string city, string district, string street, string number, string cep)
        {
            Id = id;
            Name = name;
            Professional = professional;
            Cpf = cpf;
            Gender = gender;
            Phone = phone;
            Email = email;
            CivilState = civilState;
            Photo = photo;
            BloodType = bloodType;
            Weight = weight;
            Height = height;
            BornDate = bornDate;
            PhoneEmergency = phoneEmergency;
            Notes = notes;
            RecordDate = recordDate;
            Active = active;
            MedicalRecordId = medicalRecordId;
            UfAddress = ufAddress;
            City = city;
            District = district;
            Street = street;
            Number = number;
            Cep = cep;
        }
    }
}