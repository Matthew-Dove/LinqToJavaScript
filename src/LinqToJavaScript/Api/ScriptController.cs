using LinqToJavaScript.Services;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace LinqToJavaScript.Api
{
    public class ScriptController : ApiController
    {
        private readonly DynamicService _dynamicService = null;

        public ScriptController()
        {
            _dynamicService = new DynamicService();
        }

        [HttpGet]
        public HttpResponseMessage Math()
        {
            var sum = _dynamicService.CreateFunction<int, int, int>((a, b) => a + b);
            var divide = _dynamicService.CreateFunction<float, float, float>((x, y) => x / y);

            var script = _dynamicService.CreateScript(() => sum, () => divide);

            return CreateResponse(script);
        }

        private HttpResponseMessage CreateResponse(string body)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(body, Encoding.UTF8, "application/json");
            return response;
        }
    }
}
