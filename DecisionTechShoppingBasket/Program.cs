using System;
using DecisionTechShoppingBasket.Interfaces;

namespace DecisionTechShoppingBasket
{
    public class Program
    {
        static void Main(string[] args)
        {
            IStock stock = new Stock();

            IShoppingBasket shoppingBasket = new ShoppingBasket();
            ICustomer customer = new Customer(shoppingBasket);

            IOffers offers = new Offers();
            IOrder order = new Order(offers);

            IShop shop = new Shop(customer, stock, order);

            var totalWithDiscounts = shop.PlaceCustomerOrder();

            Console.WriteLine("Total: " + totalWithDiscounts);
            Console.Read();
        }
    }
}
