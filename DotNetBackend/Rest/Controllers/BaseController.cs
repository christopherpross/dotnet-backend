using Microsoft.AspNetCore.Mvc;

namespace Rest.Controllers
{
    /// <summary>
    /// Base controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase { }
}