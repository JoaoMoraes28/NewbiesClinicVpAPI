namespace ClinicVp.DTOs
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
