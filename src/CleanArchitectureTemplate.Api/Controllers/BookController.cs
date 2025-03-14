using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitectureTemplate.Application.Command;
using CleanArchitectureTemplate.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Endpoint to add a book
        [HttpPost("add")]
        public async Task<IActionResult> AddBook([FromBody] AddBookCommand command, CancellationToken cancellationToken)
        {
            if (command?.Book == null)
            {
                return BadRequest("Book data is required.");
            }

            await _mediator.Send(command, cancellationToken);

            return Ok("Book added successfully.");
        }

        // Endpoint to update book stock
        [HttpPut("update-stock")]
        public async Task<IActionResult> UpdateBookStock([FromBody] UpdateBookStockCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return BadRequest("Invalid command data.");
            }

            await _mediator.Send(command, cancellationToken);

            return Ok("Book stock updated successfully.");
        }

        // Endpoint to update book price
        [HttpPut("update-price")]
        public async Task<IActionResult> UpdateBookPrice([FromBody] UpdateBookPriceCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return BadRequest("Invalid command data.");
            }

            await _mediator.Send(command, cancellationToken);

            return Ok("Book price updated successfully.");
        }
    }
}
