using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record ValidatedShoppingCart(RegistrationNumber RegistrationNumber, quantity quantity);
}
