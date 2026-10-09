using NpgsqlTypes;

namespace ClinicVp.DataBase.Models.Enums
{
    public enum ECivilState
    {
        [PgName("SINGLE")]
        SINGLE,
        [PgName("MARRIED")]
        MARRIED,
        [PgName("DIVORCIED")]
        DIVORCIED,
        [PgName("WIDOWED")]
        WIDOWED,
        [PgName("SEPARATED")]
        SEPARATED

    }
}
