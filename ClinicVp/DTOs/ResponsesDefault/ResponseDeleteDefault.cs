namespace ClinicVp.DTOs.ResponsesDefault
{
    public class ResponseDeleteDefault
    {

        public int Id { get; set; }

        public string Table { get; set; }

        public string Message { get; set; }


        public ResponseDeleteDefault(int id, string table, string message)
        {
            Id = id;
            Table = table;
            Message = message;
        }
    }
}
