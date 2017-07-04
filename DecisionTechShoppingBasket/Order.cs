using System.Linq;
using DecisionTechDataContracts;
using DecisionTechShoppingBasket.Interfaces;

namespace DecisionTechShoppingBasket
{
    public class Order : IOrder
    {
        private readonly IOffers _offers;

        public Order(IOffers offers)
        {
            _offers = offers;
        }

        public double TotalWithDiscounts { get; set; }

        public IOrder ApplyDiscounts(IShoppingBasket shoppingBasket)
        {
            var milkCount = shoppingBasket.ProductsOrdered.Single(x => x.Product.Name == "Milk").Quantity;
            var breadCount = shoppingBasket.ProductsOrdered.Single(x => x.Product.Name == "Bread").Quantity;
            var butterCount = shoppingBasket.ProductsOrdered.Single(x => x.Product.Name == "Butter").Quantity;

            var milkCost = shoppingBasket.ProductsOrdered.Single(x => x.Product.Name == "Milk").Product.Cost;
            var breadCost = shoppingBasket.ProductsOrdered.Single(x => x.Product.Name == "Bread").Product.Cost;

            var milkDiscount = _offers.FourForThreeMilkDiscount(milkCost, milkCount);
            var breadAndButterDiscount = _offers.BreadAndButterDiscount(breadCost, breadCount, butterCount);

            this.TotalWithDiscounts = shoppingBasket.GrandTotal - milkDiscount - breadAndButterDiscount;

            return this;
        }
    }
}
