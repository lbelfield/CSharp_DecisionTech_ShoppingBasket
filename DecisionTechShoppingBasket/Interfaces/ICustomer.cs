using DecisionTechDataContracts;

namespace DecisionTechShoppingBasket.Interfaces
{
    public interface ICustomer
    {
        IShoppingBasket ShoppingBasket { get; set; }

        void AddToBasket(Product product, int quantity);

        int GetQuantity(Product product);
    }
}
