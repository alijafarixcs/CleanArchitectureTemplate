using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Shared
{
    public record Price
    {
        public decimal Value { get; set; }
        public Price(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("invalid weight!");

            Value = value;
        
        }
        public static implicit operator Price(decimal value) { return new Price(value); }
        public static implicit operator decimal(Price value) { return value.Value; }

    }
}
