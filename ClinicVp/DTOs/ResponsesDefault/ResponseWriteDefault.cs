namespace ClinicVp.DTOs.ResponsesDefault
{
    public class ResponseWriteDefault
    {

        public int Id { get; set; }

        public string Message { get; set; }

        public ResponseWriteDefault(int id, string message)
        {
            Id = id;
            Message = message;
        }

    }
}
