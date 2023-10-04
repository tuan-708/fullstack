namespace api.Model
{
    public class ResponseObject
    {
        public ResponseObject(String status, string message, object data, int length = 0) {
            Status = status;
            Message = message;
            Data = data;
            Length = length;
        }

        public string Status { get; set; }
        public string Message { get; set; }
        public object Data {  get; set; }
        public int Length { get; set; }
    }
}
