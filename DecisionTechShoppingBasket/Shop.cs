using System;
using DecisionTechShoppingBasket.Interfaces;

namespace DecisionTechShoppingBasket
{
    public class Shop : IShop
    {
        private readonly IStock _stock;
        private readonly ICustomer _customer;

        public Shop(ICustomer customer, IStock stock)
        {
            _stock = stock;
            _customer = customer;
        }

        public void PlaceCustomerOrder()
        {
            var products = _stock.GetAvailableProducts();
            foreach (var product in products)
            {
                var quantity = _customer.GetQuantity(product);
                _customer.AddToBasket(product, quantity);
            }
            Console.Read();
        }
    }
}
