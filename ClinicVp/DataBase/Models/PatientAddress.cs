using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("patient_address")]
    public class PatientAddress
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("patient_id")]
        [Required(ErrorMessage = "O ID do paciente é obrigatório.")]
        public int PatientId { get; set; }

        [Column("uf_id")]
        [Required(ErrorMessage = "O ID da UF é obrigatório.")]
        public int UfId { get; set; }

        [Column("city")]
        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(150, ErrorMessage = "A cidade não pode ultrapassar 150 caracteres.")]
        public string City { get; set; } = string.Empty;

        [Column("district")]
        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(150, ErrorMessage = "O bairro não pode ultrapassar 150 caracteres.")]
        public string District { get; set; } = string.Empty;

        [Column("street")]
        [Required(ErrorMessage = "A rua é obrigatória.")]
        [StringLength(150, ErrorMessage = "A rua não pode ultrapassar 150 caracteres.")]
        public string Street { get; set; } = string.Empty;

        [Column("number")]
        [Required(ErrorMessage = "O número é obrigatório.")]
        [StringLength(10, ErrorMessage = "O número não pode ultrapassar 10 caracteres.")]
        public string Number { get; set; } = string.Empty;

        [Column("cep")]
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve ter exatamente 8 caracteres.")]
        public string Cep { get; set; } = string.Empty;

        // [ForeignKey("PatientId")]
        // public virtual Patient? Patient { get; set; }

        // [ForeignKey("UfId")]
        // public virtual Uf? Uf { get; set; }

        public PatientAddress(
            int patientId, int ufId, string city, 
            string district, string street, string number, string cep)
        {
            PatientId = patientId;
            UfId = ufId;
            City = city;
            District = district;
            Street = street;
            Number = number;
            Cep = cep;
        }
    }
}