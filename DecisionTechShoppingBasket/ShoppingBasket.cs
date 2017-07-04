using System.Collections.ObjectModel;
using DecisionTechDataContracts;
using DecisionTechShoppingBasket.Interfaces;

namespace DecisionTechShoppingBasket
{
    public class ShoppingBasket : IShoppingBasket
    {
        public ShoppingBasket()
        {
            ProductsOrdered = new Collection<ProductOrdered>();
            GrandTotal = 0;
        }

        public Collection<ProductOrdered> ProductsOrdered { get; set; }

        public double GrandTotal { get; set; }
    }
}
