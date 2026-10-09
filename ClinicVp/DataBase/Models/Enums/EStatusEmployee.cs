using NpgsqlTypes;

namespace ClinicVp.DataBase.Models.Enums
{
    public enum EStatusEmployee
    {
        [PgName("ACTIVE")]
        ACTIVE,
        [PgName("DESACTIVE")]
        DESACTIVE,
        [PgName("VACATION")]
        VACATION,
        [PgName("AWAY")]
        AWAY

    }
}
