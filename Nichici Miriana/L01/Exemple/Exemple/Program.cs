using Exemple.Domain;
using System;
using System.Collections.Generic;
using static Exemple.Domain.Cart;

namespace Exemple
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listofProducts = ReadlistofProducts().ToArray();
            UnvalidatedCart unvalidatedProducts = new(listofProducts);
            ICart result = ValidateCart(unvalidatedProducts);
            result.Match(
                whenUnvalidatedCart: unvalidatedResult => unvalidatedProducts,
                whenPayedCart: PayedResult => PayedResult,
                whenEmptyCart: emptyResult => emptyResult,
                whenValidatedCart: validatedResult => payCart(validatedResult)
            );

            Console.WriteLine("Hello World!");
        }

        private static List<UnvalidatedShoppingCart> ReadlistofProducts()
        {
            List <UnvalidatedShoppingCart> listofProducts = new();
            do
            {
                //read registration number and quantity and create a list of greads
                var registrationNumber = ReadValue("Registration Number: ");
                if (string.IsNullOrEmpty(registrationNumber))
                {
                    break;
                }

                var quantity = ReadValue("quantity: ");
                if (string.IsNullOrEmpty(quantity))
                {
                    break;
                }

                listofProducts.Add(new (registrationNumber, quantity));
            } while (true);
            return listofProducts;
        }

        private static ICart ValidateCart(UnvalidatedCart unvalidatedProducts) =>
            random.Next(100) > 50 ?
            new EmptyCart(new List<UnvalidatedShoppingCart>(), "Random errror")
            : new ValidatedCart(new List<ValidatedShoppingCart>());

        private static ICart payCart(ValidatedCart validCart) =>
            new PayedCart(new List<ValidatedShoppingCart>(), DateTime.Now);

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
