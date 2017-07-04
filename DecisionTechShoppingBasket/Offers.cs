using DecisionTechShoppingBasket.Interfaces;

namespace DecisionTechShoppingBasket
{
    public class Offers : IOffers
    {
        // this is potentially duplicated logic.
        // I could have another set of inheritance methods

        public double FourForThreeMilkDiscount(double milkCost, int milkCount)
        {
            double discountToApply = 0;

            while (milkCount >= 4)
            {
                // add a 100% Milk discount
                discountToApply += milkCost;

                milkCount -= 4;
            }

            return discountToApply;
        }

        public double BreadAndButterDiscount(double breadCost, int breadCount, int butterCount)
        {
            double discountToApply = 0;

            while (butterCount >= 2 && breadCount >= 1)
            {
                // add a 50% bread discount
                discountToApply += (breadCost / 2);

                breadCount -= 1;
                butterCount -= 2;
            }

            return discountToApply;
        }
    }
}
