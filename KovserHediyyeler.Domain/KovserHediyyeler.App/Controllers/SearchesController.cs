using KovserHediyyeler.Application.Features.Queries.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KovserHediyyeler.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchesController : ControllerBase
    {
        readonly IMediator _mediator;

        public SearchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchAsync([FromQuery] SearchQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Products);
        }
    }
}
