using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Shared.Interfaces;
using CleanArchitectureTemplate.Domain;
using Microsoft.Extensions.Logging;
using CleanArchitectureTemplate.Application.Query;

namespace CleanArchitectureTemplate.Application.Command.Handlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand>
    {
        private readonly IRepository _repository;
        private readonly ILogger<AddBookCommandHandler> _logger;

        public AddBookCommandHandler(IRepository repository, ILogger<AddBookCommandHandler> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync<Book, Guid>(request.Book, cancellationToken);
            _logger.LogInformation("Book with ID {BookId} added successfully.", request.Book.Id);
        }
    }

    public class UpdateBookStockCommandHandler : IRequestHandler<UpdateBookStockCommand>
    {
        private readonly IMediator _mediator;
        private readonly IRepository _repository;
        private readonly ILogger<UpdateBookStockCommandHandler> _logger;

        public UpdateBookStockCommandHandler(IMediator mediator, IRepository repository, ILogger<UpdateBookStockCommandHandler> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(UpdateBookStockCommand request, CancellationToken cancellationToken)
        {
            // Use the query to get the book
            var book = await _mediator.Send(new GetBookByIdQuery(request.BookId), cancellationToken);
            if (book == null)
            {
                _logger.LogWarning("Book with ID {BookId} not found.", request.BookId);
                throw new KeyNotFoundException($"Book with ID {request.BookId} not found.");
            }

            book.AddStock(request.Quantity);
            await _repository.UpdateAsync<Book, Guid>(book, cancellationToken);
            _logger.LogInformation("Updated stock for book ID {BookId} by {Quantity}.", request.BookId, request.Quantity);
        }
    }

    public class SellBookStockCommandHandler : IRequestHandler<SellBookStockCommand>
    {
        private readonly IMediator _mediator;
        private readonly IRepository _repository;
        private readonly ILogger<SellBookStockCommandHandler> _logger;

        public SellBookStockCommandHandler(IMediator mediator, IRepository repository, ILogger<SellBookStockCommandHandler> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(SellBookStockCommand request, CancellationToken cancellationToken)
        {
            // Use the query to get the book
            var book = await _mediator.Send(new GetBookByIdQuery(request.BookId), cancellationToken);
            if (book == null)
            {
                _logger.LogWarning("Book with ID {BookId} not found.", request.BookId);
                throw new KeyNotFoundException($"Book with ID {request.BookId} not found.");
            }

            book.SellBook(request.Quantity);
            await _repository.UpdateAsync<Book, Guid>(book, cancellationToken);
            _logger.LogInformation("Sold {Quantity} units of book ID {BookId}.", request.Quantity, request.BookId);
        }
    }

    public class UpdateBookPriceCommandHandler : IRequestHandler<UpdateBookPriceCommand>
    {
        private readonly IMediator _mediator;
        private readonly IRepository _repository;
        private readonly ILogger<UpdateBookPriceCommandHandler> _logger;

        public UpdateBookPriceCommandHandler(IMediator mediator, IRepository repository, ILogger<UpdateBookPriceCommandHandler> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(UpdateBookPriceCommand request, CancellationToken cancellationToken)
        {
            // Use the query to get the book
            var book = await _mediator.Send(new GetBookByIdQuery(request.BookId), cancellationToken);
            if (book == null)
            {
                _logger.LogWarning("Book with ID {BookId} not found.", request.BookId);
                throw new KeyNotFoundException($"Book with ID {request.BookId} not found.");
            }

            book.ChangePrice(request.NewPrice);
            await _repository.UpdateAsync<Book, Guid>(book, cancellationToken);
            _logger.LogInformation("Updated price for book ID {BookId} to {NewPrice}.", request.BookId, request.NewPrice);
        }
    }
}