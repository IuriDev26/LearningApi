using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers {
    [Route("api/v{version:apiVersion}/teste")]
    [Route("api/teste")]
    [ApiController]
    [ApiVersion(2.0)]
    public class TesteV2Controller : ControllerBase {

        [HttpGet]
        public string Get() {

            return "API V2.0";

        }

    }
}
