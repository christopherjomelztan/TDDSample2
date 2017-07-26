using System.Net;
using TDDSample.PoCo;

namespace TDDSample
{
    public static class WebServiceClient
    {
        public static WebServiceResponse<T> Get<T>(WebServiceRequest request) where T : class, new()
        {
            if (request.Uri == "BadRequest")
            {
                return new WebServiceResponse<T> { Data = null, StatusCode = HttpStatusCode.BadRequest };
            }

            return new WebServiceResponse<T> { Data = new T(), StatusCode = HttpStatusCode.OK };
        }
    }
}
