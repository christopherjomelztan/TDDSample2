using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDSample.PoCo;

namespace TDDSample
{
    public class WebServiceClientWrapper : IWebServiceClient
    {
        public WebServiceResponse<T> Get<T>(WebServiceRequest request) where T : class, new()
        {
            return WebServiceClient.Get<T>(request);
        }
    }
}
