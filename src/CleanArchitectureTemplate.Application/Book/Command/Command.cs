using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain;
using MediatR;

namespace CleanArchitectureTemplate.Application.Command
{
    public class UpdateBookStockCommand : IRequest
    {
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
    }

    public class AddBookCommand : IRequest
    {
        public Book Book { get; set; }

        public AddBookCommand(Book book)
        {
            Book = book;
        }
    }

    public class UpdateBookPriceCommand : IRequest
    {
        public Guid BookId { get; set; }
        public decimal NewPrice { get; set; }
    }

}
