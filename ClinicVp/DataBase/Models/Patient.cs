using ClinicVp.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("patient")]
    public class Patient : People
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("professional")]
        [StringLength(255, ErrorMessage = "A profissão não pode ultrapassar 255 caracteres.")]
        public string? Professional { get; set; }

        [Column("gender")]
        [Required(ErrorMessage = "O campo de selecionar gênero é obrigatório.")]
        public EGender GenderOption { get; set; }

        [Column("civil_state")]
        [Required(ErrorMessage = "O estado civil é obrigatório.")]
        public ECivilState CivilState { get; set; }

        [Column("blood_type")]
        public EBloodType? BloodType { get; set; }

        [Column("weight")]
        [Range(0, 999.9, ErrorMessage = "O peso deve ser um valor válido.")]
        public decimal? Weight { get; set; }

        [Column("height")]
        [Range(0, 300, ErrorMessage = "A altura deve ser em centímetros.")]
        public int? Height { get; set; }

        [Column("born_date")]
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime BornDate { get; set; }

        [Column("phone_emergency")]
        [StringLength(11, ErrorMessage = "O telefone de emergência deve ter no máximo 11 caracteres.")]
        public string? PhoneEmergency { get; set; }

        [Column("notes")]
        [StringLength(500, ErrorMessage = "As observações não podem ultrapassar 500 caracteres.")]
        public string? Notes { get; set; }

        [Column("record_date")]
        public DateTime RecordDate { get; set; } = DateTime.UtcNow;

        [Column("active")]
        [Required]
        public bool Active { get; set; } = true;

        public Patient(
            string name, string cpf, string email, EGender gender,
            string phone, string photo, ECivilState civilState, 
            DateTime bornDate, string? professional = null, 
            EBloodType? bloodType = null, decimal? weight = null, 
            int? height = null, string? phoneEmergency = null, string? notes = null)
            : base(name, cpf, email, gender, phone, photo)
        {
            CivilState = civilState;
            BornDate = bornDate;
            Professional = professional;
            BloodType = bloodType;
            Weight = weight;
            Height = height;
            PhoneEmergency = phoneEmergency;
            Notes = notes;
        }
    }
}