using ClinicVp.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("doctor")]
    public class Doctor : People
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("admission_date")]
        public DateTime AdmissionDate { get; set; } = DateTime.UtcNow;

        [Column("crm")]
        [Required(ErrorMessage = "O CRM é obrigatório.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "O CRM deve ter exatamente 10 caracteres.")]
        public string Crm { get; set; }

        [Column("crm_uf_id")]
        [Required(ErrorMessage = "O ID da UF do CRM é obrigatório.")]
        public int CrmUfId { get; set; }

        [Column("bio")]
        [StringLength(500, ErrorMessage = "A biografia não pode ultrapassar 500 caracteres.")]
        public string? Bio { get; set; }

        [Column("password")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Password { get; set; } = string.Empty;

        [Column("must_change_password")]
        public bool MustChangePassword { get; set; } = true;

        [Column("status")]
        [Required(ErrorMessage = "O status é obrigatório.")]
        public EStatusEmployee Status { get; set; }

        // [ForeignKey("CrmUfId")]
        // public virtual Uf? CrmUf { get; set; }

        public Doctor(
            string name, string cpf, string email, EGender gender,
            string phone, string photo, DateTime admissionDate,
            string crm, int crmUfId, string password,
            EStatusEmployee status, string? bio = null)
            : base(name, cpf, email, gender, phone, photo)
        {
            AdmissionDate = admissionDate;
            Crm = crm;
            CrmUfId = crmUfId;
            Password = password;
            Status = status;
            Bio = bio;
        }
    }
}