namespace ClinicVp.DTOs.ResponsesDefault
{
    public class ResponseWriteEmployee
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ResponseWriteEmployee(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

    }
}
