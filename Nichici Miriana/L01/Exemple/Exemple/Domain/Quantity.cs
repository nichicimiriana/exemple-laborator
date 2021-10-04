using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record quantity
    {
        public decimal Value { get; }

        public quantity(decimal value)
        {
            if (value > 0 && value <= 100)
            {
                Value = value;
            }
            else
            {
                throw new InvalidquantityException($"{value:0.##} is an invalid quantity value.");
            }
        }

        public quantity Round()
        {
            var roundedValue = Math.Round(Value);
            return new quantity(roundedValue);
        }

        public override string ToString()
        {
            return $"{Value:0.##}";
        }
    }
}
