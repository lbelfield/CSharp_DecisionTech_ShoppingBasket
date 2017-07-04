using System.Collections.ObjectModel;
using DecisionTechDataContracts;

namespace DecisionTechShoppingBasket.Interfaces
{
    public interface IStock
    {
        Collection<Product> GetAvailableProducts();
    }
}
