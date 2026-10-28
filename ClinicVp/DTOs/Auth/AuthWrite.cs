namespace ClinicVp.DTOs.Auth
{
    public class AuthWrite
    {

        public string Email { get; set; }
        public string Pass { get; set; }

        public AuthWrite(string email, string pass)
        {
            Email = email;
            Pass = pass;
        }

    }
}
