using Microsoft.AspNetCore.Mvc;

namespace SampleWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HiHelloController : ControllerBase
    {
        // GET hihello/
        [HttpGet]
        public string Get()
        {
            return "type in url hi or hello";
        }

        // GET hihello/{string}
        [HttpGet("{id}")]
        public string Get(string id)
        {
            if (id == "hi")
            {
                return "hello";
            }
            else if (id == "hello")
            {
                return "hi";
            }
            else
            {
                return "error";
            }
        }
    }
}
