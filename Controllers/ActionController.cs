using ActionConstraints.Constraints;
using Microsoft.AspNetCore.Mvc;

namespace ActionConstraints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        [HttpGet, HeaderConstraint("MyHeader", "A")]
        public string GetStringA()
        {
            return "A";
        }

        [HttpGet, HeaderConstraint("MyHeader", "B")]
        public string GetStringB()
        {
            return "B";
        }

    }
}
