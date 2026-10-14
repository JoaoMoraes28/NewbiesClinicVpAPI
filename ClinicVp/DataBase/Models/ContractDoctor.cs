using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("contract_doctor")]
    public class ContractDoctor
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("contract_type_id")]
        public int ContractTypeId { get; set; }

        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor? Doctor { get; set; }

        [ForeignKey("ContractTypeId")]
        public virtual ContractType? ContractType { get; set; }

        public ContractDoctor(int contractTypeId, int doctorId)
        {
            ContractTypeId = contractTypeId;
            DoctorId = doctorId;
        }

    }
}
