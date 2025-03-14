using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitectureTemplate.Application.Query
{
    public class GetBookStockQuery : IRequest<int>
    {
        public Guid BookId { get; set; }
    }

}
