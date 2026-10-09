using NpgsqlTypes;

namespace ClinicVp.DataBase.Models.Enums
{
    public enum EGender
    {
        [PgName("MALE")]
        MALE,
        [PgName("FEMALE")]
        FEMALE

    }
}
