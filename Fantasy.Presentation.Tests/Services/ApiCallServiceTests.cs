
using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.ViewModels;
using Fantasy.Presentation.Services.Implementations;
using Moq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fantasy.Presentation.Tests.Services
{
    [TestFixture]
    public class ApiCallServiceTests
    {
        ContextHelper _helper = new ContextHelper();

        [Test]
        public async Task EspnRules_Returns_Rules_GivenSuccessfulCall()
        {
            EspnRulesRequestObject request = new();
            RulesESPNViewModel rules = new();
            Mock<HttpMessageHandler> handler = _helper.GetMockHandler();
            _helper.SetupMockHandler(handler, ContextHelper.Endpoint.espnRules, HttpMethod.Post, HttpStatusCode.OK, JsonSerializer.Serialize(rules));
            ApiCallService service = new ApiCallService(handler.Object);

            RulesESPNViewModel response = await service.EspnRules(request);

            Assert.AreEqual(JsonSerializer.Serialize(response), JsonSerializer.Serialize(rules));
        }
    }
}
