using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("contract_type")]
    public class ContractType
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("contract")]
        public string Contract { get; set; }

        public ContractType(string contract)
        {
            Contract = contract;
        }

    }
}
