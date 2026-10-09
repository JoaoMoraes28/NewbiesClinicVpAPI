using NpgsqlTypes;

namespace ClinicVp.DataBase.Models.Enums
{
    public enum EBloodType
    {

        [PgName("A_POSITIVE")]
        A_POSITIVE,
        [PgName("A_NEGATIVE")]
        A_NEGATIVE,
        [PgName("O_POSITIVE")]
        O_POSITIVE,
        [PgName("O_NEGATIVE")]
        O_NEGATIVE,
        [PgName("AB_POSITIVE")]
        AB_POSITIVE,
        [PgName("AB_NEGATIVE")]
        AB_NEGATIVE,
        [PgName("B_POSITIVE")]
        B_POSITIVE,
        [PgName("B_NEGATIVE")]
        B_NEGATIVE

    }
}
