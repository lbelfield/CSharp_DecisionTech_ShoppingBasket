using DecisionTechShoppingBasket.Interfaces;

namespace DecisionTechShoppingBasket
{
    public class Customer : ICustomer
    {
        private readonly IShoppingBasket _shoppingBasket;

        public Customer(IShoppingBasket shoppingBasket)
        {
            _shoppingBasket = shoppingBasket;
        }
    }
}
