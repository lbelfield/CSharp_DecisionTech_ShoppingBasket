using System.Collections.ObjectModel;
using DecisionTechDataContracts;

namespace DecisionTechShoppingBasket.Interfaces
{
    public interface IShoppingBasket
    {
        Collection<ProductOrdered> ProductsOrdered { get; set; }

        double GrandTotal { get; set; }
    }
}
