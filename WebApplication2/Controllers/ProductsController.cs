using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Features.Products.Commands;
using WebApplication2.Features.Products.Queries;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<List<GetProductsQueryResponse>> GetProducts()
        {
            return _mediator.Send(new GetProductsQuery());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{ProductId}")]
        public Task<GetProductQueryResponse> GetProductById([FromRoute] GetProductQuery query)
        {
            return _mediator.Send(query);
        }
    }
}
