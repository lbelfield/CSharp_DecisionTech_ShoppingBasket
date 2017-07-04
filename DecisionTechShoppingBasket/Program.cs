using System;
using DecisionTechShoppingBasket.Interfaces;

namespace DecisionTechShoppingBasket
{
    public class Program
    {
        static void Main(string[] args)
        {
            IStock stock = new Stock();
            
            var products = stock.GetAvailableProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);                
            }
            Console.Read();
        }
    }
}
