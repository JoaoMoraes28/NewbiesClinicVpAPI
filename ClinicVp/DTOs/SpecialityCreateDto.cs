namespace ClinicVp.DTOs
{
    public class SpecialityCreateDto
    {

        public string SpecialityName { get; set; }

        public SpecialityCreateDto(string specialityName)
        {
            SpecialityName = specialityName;
        }

    }
}
