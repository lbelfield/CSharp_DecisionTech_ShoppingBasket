using System.Collections.Generic;
using System.Collections.ObjectModel;
using DecisionTechDataContracts;
using DecisionTechShoppingBasket.Interfaces;

namespace DecisionTechShoppingBasket
{
    public class Stock : IStock
    {
        public Collection<Product> GetAvailableProducts()
        {
            return new Collection<Product> { new Butter(), new Bread(), new Milk() };
        }
    }
}
