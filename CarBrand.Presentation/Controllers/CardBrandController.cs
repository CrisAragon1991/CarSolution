using CarBrand.Domain.Agregate;
using CardBrand.Application.Commands;
using CardBrand.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBrand.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardBrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardBrandController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCarBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCarBrandCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetCarBrandQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var query = new GetCarBrandByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var command = new DeleteCarBrandCommand { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
    }
}