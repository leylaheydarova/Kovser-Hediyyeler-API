using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //[HttpGet([Action])] - by this way the name of action will be viewed on swagger and will run all the http requests with tha same name for various actions
    }
}
