using System.Collections.Generic;
using DecisionTechDataContracts;

namespace DecisionTechShoppingBasket.Interfaces
{
    public interface IStock
    {
        List<Product> GetAvailableProducts();
    }
}
