using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers {
    [Route("api/v{version:apiVersion}/teste")]
    [ApiController]
    [ApiVersion(1.0)]
    public class TesteV1Controller : ControllerBase {

        [HttpGet]
        public string Get() {

            return "API V1.0";
        }

    }
}
