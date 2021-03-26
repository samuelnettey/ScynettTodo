using Microsoft.AspNetCore.Mvc;

namespace ScynettTodo.Api.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
