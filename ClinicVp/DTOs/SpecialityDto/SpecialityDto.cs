namespace ClinicVp.DTOs.SpecialityDto
{
    public class SpecialityDto
    {

        public string SpecialityName { get; set; }

        public SpecialityDto(string specialityName)
        {
            SpecialityName = specialityName;
        }

    }
}
