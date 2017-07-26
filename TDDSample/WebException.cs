using System;
using System.Net;

namespace TDDSample
{
    public class WebException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public WebException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
