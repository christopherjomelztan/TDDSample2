using System.Net;

namespace TDDSample.PoCo
{
    public class WebServiceResponse<T>
    {
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
