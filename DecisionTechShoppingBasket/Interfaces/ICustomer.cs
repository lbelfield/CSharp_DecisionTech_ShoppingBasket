using DecisionTechDataContracts;

namespace DecisionTechShoppingBasket.Interfaces
{
    public interface ICustomer
    {
        void AddToBasket(Product product, int quantity);

        int GetQuantity(Product product);
    }
}
