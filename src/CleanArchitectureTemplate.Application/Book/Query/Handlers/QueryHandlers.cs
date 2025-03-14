using MediatR;
using CleanArchitectureTemplate.Shared.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Application.Query;
using CleanArchitectureTemplate.Domain;

namespace CleanArchitectureTemplate.Application.Queries
{
    // Query Handler for getting book stock level
    public class GetBookStockQueryHandler : IRequestHandler<GetBookStockQuery, int>
    {
        private readonly IRepository _repository;

        public GetBookStockQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(GetBookStockQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the book from the repository
            var book = await _repository.GetByIdAsync<Book, Guid>(request.BookId, cancellationToken);
            if (book == null)
            {
                throw new Exception("Book not found");
            }

            // Return the current stock level
            return book.Stock;
        }
    }
}
