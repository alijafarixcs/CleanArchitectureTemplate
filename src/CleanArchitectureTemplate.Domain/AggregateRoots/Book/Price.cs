using System;

namespace CleanArchitectureTemplate.Shared
{
    public record Price
    {
        public decimal Value { get; init; }

        public Price(decimal value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid price value!");

            Value = value;
        }

        public static implicit operator Price(decimal value) => new Price(value);
        public static implicit operator decimal(Price price) => price.Value;
    }
}
