using System.Net;
using TDDSample.PoCo;

namespace TDDSample
{
    public class MyService
    {
        private IWebServiceClient _webServiceClientWrapper;
        private IDbManager _dbManager;

        public MyService(IDbManager dbManager,IWebServiceClient webServiceClientWrapper)
        {
            _dbManager = dbManager;
            _webServiceClientWrapper = webServiceClientWrapper;
        }

        public void Save(Item i)
        {
            _dbManager.SaveToDb(i);
        }

        public T GetFromWebService<T>(WebServiceRequest request) where T: class, new()
        {
            var response = _webServiceClientWrapper.Get<T>(request);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }

            throw new WebException(response.StatusCode);
        }
    }
}
