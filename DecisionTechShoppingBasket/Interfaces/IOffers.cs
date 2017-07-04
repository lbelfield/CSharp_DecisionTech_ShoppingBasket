namespace DecisionTechShoppingBasket.Interfaces
{
    public interface IOffers
    {
        double FourForThreeMilkDiscount(double milkCost, int milkCount);

        double BreadAndButterDiscount(double breadCost, int breadCount, int butterCount);
    }
}
