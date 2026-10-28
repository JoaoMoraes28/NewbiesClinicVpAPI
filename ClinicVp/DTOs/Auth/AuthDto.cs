namespace ClinicVp.DTOs.Auth
{
    public class AuthDto
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }

        public AuthDto(int id, string email, string pass)
        {
            Id = id;
            Email = email;
            Pass = pass;
        }

    }
}
