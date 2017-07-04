using System;
using DecisionTechDataContracts;
using DecisionTechShoppingBasket.Interfaces;

namespace DecisionTechShoppingBasket
{
    public class Customer : ICustomer
    {
        private readonly IShoppingBasket _shoppingBasket;

        public Customer(IShoppingBasket shoppingBasket)
        {
            _shoppingBasket = shoppingBasket;
        }

        public void AddToBasket(Product product, int quantity)
        {
            _shoppingBasket.ProductsOrdered.Add(new ProductOrdered { Product = product, Quantity = quantity });
            _shoppingBasket.GrandTotal += (product.Cost * quantity);
            Console.WriteLine(_shoppingBasket.GrandTotal);
        }

        public int GetQuantity(Product product)
        {
            Console.WriteLine("How much {0} would you like?", product.Name);
            var input = Console.ReadLine();

            int quantity;

            int.TryParse(input, out quantity);

            return quantity;
        }
    }
}
