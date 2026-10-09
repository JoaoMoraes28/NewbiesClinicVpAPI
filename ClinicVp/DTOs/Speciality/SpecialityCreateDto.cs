namespace ClinicVp.DTOs.Speciality
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
