namespace ClinicVp.DTOs.Auth
{
    public class ResponseLogin
    {

        public bool Authorized { get; set; }

        public ResponseLogin(bool authorized)
        {
            Authorized = authorized;
        }

    }
}
