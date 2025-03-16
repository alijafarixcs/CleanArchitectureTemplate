using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CleanArchitectureTemplate.Domain;
namespace CleanArchitectureTemplate.Application.Query
{
    public class GetBookStockQuery : IRequest<int>
    {
        public Guid BookId { get; set; }
    }
    public class GetBookByIdQuery : IRequest<Book>
    {
        public Guid BookId { get; }

        public GetBookByIdQuery(Guid bookId)
        {
            BookId = bookId;
        }
    }


}
