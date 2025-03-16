using CleanArchitectureTemplate.Domain;
using CleanArchitectureTemplate.Shared.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Query.Handlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IRepository _repository;

        public GetBookByIdQueryHandler(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync<Book, Guid>(request.BookId, cancellationToken);
        }
    }
}
