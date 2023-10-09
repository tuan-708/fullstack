using System.Net;

namespace DemoAutoMigration.Common
{
    public class ResponseBody<T>
    {
        public HttpStatusCode statusCode { get; set; }
        public T? data { get; set; }
        public string? message { get; set; }
    }
}
