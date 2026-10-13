namespace ClinicVp.DTOs.ResponsesDefault
{
    public class ResponseDeleteDefault
    {

        public string Table { get; set; }

        public string Message { get; set; }


        public ResponseDeleteDefault(string table, string message)
        {
            Table = table;
            Message = message;
        }
    }
}
