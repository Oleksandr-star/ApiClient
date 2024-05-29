using System.Net;

namespace MyApiClient
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public List<T> Data { get; set; }
    }

    public class Definition
    {
        public string PartOfSpeech { get; set; }
        public string Text { get; set; }
    }

}
