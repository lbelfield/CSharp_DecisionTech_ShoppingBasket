using System;
using DecisionTechDataContracts;
using DecisionTechShoppingBasket.Interfaces;

namespace DecisionTechShoppingBasket
{
    public class Customer : ICustomer
    {
        public IShoppingBasket ShoppingBasket { get; set; }

        public Customer(IShoppingBasket shoppingBasket)
        {
            ShoppingBasket = shoppingBasket;
        }

        public void AddToBasket(Product product, int quantity)
        {
            ShoppingBasket.ProductsOrdered.Add(new ProductOrdered { Product = product, Quantity = quantity });
            ShoppingBasket.GrandTotal += (product.Cost * quantity);
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
