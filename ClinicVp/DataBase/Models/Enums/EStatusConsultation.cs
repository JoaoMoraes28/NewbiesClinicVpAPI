using NpgsqlTypes;

namespace ClinicVp.DataBase.Models.Enums
{
    public enum EStatusConsultation
    {
        [PgName("SCHEDULED")]
        SCHEDULED,
        [PgName("WAITING")]
        WAITING,
        [PgName("IN_PROGRESS")]
        IN_PROGRESS,
        [PgName("COMPLETED")]
        COMPLETED,
        [PgName("CANCELED")]
        CANCELED
    }
}
