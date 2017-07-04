using System.Collections.Generic;
using DecisionTechDataContracts;
using DecisionTechShoppingBasket.Interfaces;

namespace DecisionTechShoppingBasket
{
    public class Stock : IStock
    {
        public List<Product> GetAvailableProducts()
        {
            return new List<Product> { new Butter(), new Bread(), new Milk() };
        }
    }
}
