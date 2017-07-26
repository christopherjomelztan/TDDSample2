using NUnit.Framework;
using Moq;
using TDDSample.PoCo;
using System.Net;

namespace TDDSample.Tests
{
    [TestFixture]
    public class MyServiceTests
    {
        [Test]
        public void Save_SavesItemToDb()
        {
            var item = new Item();
            Mock<IDbManager> mockDbManager = new Mock<IDbManager>();
            var myService = new MyService(mockDbManager.Object, null);
            myService.Save(item);

            // assert/verify that item was saved to db (DbManager.SaveToDb(item) called).
            mockDbManager.Verify(x => x.SaveToDb(item), Times.Once);
        }

        [Test]
        public void GetFromWebService_ReturnsResponseData()
        {
            var responseObject = new object();
            var request = new WebServiceRequest { Uri = "http://www.example.com" };
            Mock<IWebServiceClient> mockWebServiceClientWrapper = new Mock<IWebServiceClient>();
            mockWebServiceClientWrapper.Setup(x => x.Get<object>(request)).Returns(new WebServiceResponse<object> { Data = responseObject, StatusCode = HttpStatusCode.OK });
            var myService = new MyService(null,mockWebServiceClientWrapper.Object);
            var data = myService.GetFromWebService<object>(request);

            Assert.That(data, Is.EqualTo(responseObject));
            // assert that data is received from web service client (data same as responseObject)
        }

        [Test]
        public void GetFromWebService_ThrowWebExceptionIfBadRequest()
        {
            var request = new WebServiceRequest { Uri = "BadRequest" };
            Mock<IWebServiceClient> mockWebServiceClientWrapper = new Mock<IWebServiceClient>();
            mockWebServiceClientWrapper.Setup(x => x.Get<object>(request)).Returns(new WebServiceResponse<object> { Data = null, StatusCode = HttpStatusCode.BadRequest });
            var myService = new MyService(null, mockWebServiceClientWrapper.Object);


            Assert.That(() => myService.GetFromWebService<object>(request), Throws.InstanceOf<WebException>().With.Property("StatusCode").EqualTo(HttpStatusCode.BadRequest));
            //var data = myService.GetFromWebService<object>(request);
            //Assert.That(data.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            // assert that GetFromWebService(request) throws exception with BadRequest status code
        }
    }
}
