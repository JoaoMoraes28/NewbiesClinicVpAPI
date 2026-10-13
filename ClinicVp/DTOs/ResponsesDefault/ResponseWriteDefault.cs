namespace ClinicVp.DTOs.ResponsesDefault
{
    public class ResponseWriteDefault
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ResponseWriteDefault(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

    }
}
