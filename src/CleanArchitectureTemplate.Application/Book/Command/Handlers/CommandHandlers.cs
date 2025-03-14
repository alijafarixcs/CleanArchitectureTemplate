using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using CleanArchitectureTemplate.Shared.Interfaces;
using CleanArchitectureTemplate.Domain;

namespace CleanArchitectureTemplate.Application.Command.Handlers
{
    // Command Handler for adding a book
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand>
    {
        private readonly IRepository _repository;

        public AddBookCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            // Add the book to the repository

            await _repository.AddAsync<Book, Guid>(request.Book, cancellationToken);
        }
    }

    // Command Handler for updating book stock
    public class UpdateBookStockCommandHandler : IRequestHandler<UpdateBookStockCommand>
    {
        private readonly IRepository _repository;

        public UpdateBookStockCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBookStockCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the book from the repository
            var book = await _repository.GetByIdAsync<Book, Guid>(request.BookId, cancellationToken);
            if (book == null)
            {
                throw new Exception("Book not found");
            }

            // Update the stock level of the book
            // Assuming the stock update logic is handled in the domain model
            book.AddStock(request.Quantity);
            // Save changes to the repository
            await _repository.UpdateAsync<Book, Guid>(book, cancellationToken);
        }

    }
 public class SellBookStockCommandHandler : IRequestHandler<SellBookStockCommand>
    {
        private readonly IRepository _repository;

        public SellBookStockCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(SellBookStockCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the book from the repository
            var book = await _repository.GetByIdAsync<Book, Guid>(request.BookId, cancellationToken);
            if (book == null)
            {
                throw new Exception("Book not found");
            }

            // Update the stock level of the book
            // Assuming the stock update logic is handled in the domain model
            book.SellBook(request.Quantity);
            // Save changes to the repository
            await _repository.UpdateAsync<Book, Guid>(book, cancellationToken);
        }

    }
    // Command Handler for updating book price
    public class UpdateBookPriceCommandHandler : IRequestHandler<UpdateBookPriceCommand>
    {
        private readonly IRepository _repository;

        public UpdateBookPriceCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBookPriceCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the book from the repository
            var book = await _repository.GetByIdAsync<Book, Guid>(request.BookId, cancellationToken);
            if (book == null)
            {
                throw new Exception("Book not found");
            }

            // Update the book price
            book.ChangePrice(request.NewPrice);

            // Save changes to the repository
            await _repository.UpdateAsync<Book, Guid>(book, cancellationToken);
        }
    }
}
