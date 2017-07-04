using System;
using DecisionTechShoppingBasket.Interfaces;

namespace DecisionTechShoppingBasket
{
    public class Shop : IShop
    {
        private readonly IStock _stock;
        private readonly ICustomer _customer;
        private readonly IOrder _order;

        public Shop(ICustomer customer, IStock stock, IOrder order)
        {
            _stock = stock;
            _customer = customer;
            _order = order;
        }

        public double PlaceCustomerOrder()
        {
            var products = _stock.GetAvailableProducts();
            foreach (var product in products)
            {
                var quantity = _customer.GetQuantity(product);
                _customer.AddToBasket(product, quantity);
            }

            _order.ApplyDiscounts(_customer.ShoppingBasket);

            return _order.TotalWithDiscounts;
        }
    }
}
