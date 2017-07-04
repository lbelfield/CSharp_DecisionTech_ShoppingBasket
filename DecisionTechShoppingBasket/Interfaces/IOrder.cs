namespace DecisionTechShoppingBasket.Interfaces
{
    public interface IOrder
    {
        IOrder ApplyDiscounts(IShoppingBasket shoppingBasket);

        double TotalWithDiscounts { get; set; }
    }
}
