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

            IShop shop = new Shop(customer, stock);
            
            shop.PlaceCustomerOrder();
        }
    }
}
