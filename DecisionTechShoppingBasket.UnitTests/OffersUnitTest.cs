using DecisionTechDataContracts;
using DecisionTechShoppingBasket.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionTechShoppingBasket.UnitTests
{
    [TestClass]
    public class OffersUnitTest
    {
        private IOffers _mockOffers;
        private Butter _butter;
        private Bread _bread;
        private Milk _milk;

        private double milkCost;
        private double breadCost;
        private double butterCost;

        [TestInitialize]
        public void Initialize()
        {
            _butter = new Butter();
            _bread = new Bread();
            _milk = new Milk();

            butterCost = _butter.Cost;
            breadCost = _bread.Cost;
            milkCost = _milk.Cost;

            _mockOffers = new Offers();
        }

        //TEST SCENARIO 1
        [TestMethod]
        public void BreadAndButterDiscountAndMilkDiscount_OneBreadOneButterOneMilk_ZeroDiscount()
        {
            var milkDiscountToApply = _mockOffers.FourForThreeMilkDiscount(milkCost, 1);
            var breadDiscountToApply = _mockOffers.BreadAndButterDiscount(breadCost, 1, 1);

            var discount = milkDiscountToApply + breadDiscountToApply;

            Assert.AreEqual(discount, 0);
        }

        //TEST SCENARIO 2
        [TestMethod]
        public void BreadAndButterDiscount_TwoBreadTwoButter_HalfTheCostOfBread()
        {
            var breadDiscountToApply = _mockOffers.BreadAndButterDiscount(breadCost, 2, 2);

            Assert.AreEqual(breadCost / 2, breadDiscountToApply);
        }

        //TEST SCENARIO 3
        [TestMethod]
        public void FourForThreeMilkDiscount_FourMilks_TheCostOfMilk()
        {
            var milkDiscountToApply = _mockOffers.FourForThreeMilkDiscount(milkCost, 4);

            Assert.AreEqual(milkCost, milkDiscountToApply);
        }

        //TEST SCENARIO 4
        [TestMethod]
        public void BreadAndButterDiscountAndMilkDiscount_OneBreadTwoButterEightMilk_HalfTheCostOfBread()
        {
            // 2 x milk discount
            var milkDiscountToApply = _mockOffers.FourForThreeMilkDiscount(milkCost, 8);
            // 1/2 Bread discount
            var breadDiscountToApply = _mockOffers.BreadAndButterDiscount(breadCost, 1, 2);

            var discount = milkDiscountToApply + breadDiscountToApply;

            Assert.AreEqual(discount, ((milkCost * 2) + (breadCost / 2)));
        }

        [TestMethod]
        public void FourForThreeMilkDiscount_LessThanFourMilks_NoDiscount()
        {
            var milkDiscountToApply = _mockOffers.FourForThreeMilkDiscount(milkCost, 2);

            Assert.AreEqual(0, milkDiscountToApply);
        }

        [TestMethod]
        public void FourForThreeMilkDiscount_EightMilks_DoubleTheCostOfMilk()
        {
            var milkDiscountToApply = _mockOffers.FourForThreeMilkDiscount(milkCost, 8);

            Assert.AreEqual(milkCost * 2, milkDiscountToApply);
        }

        [TestMethod]
        public void BreadAndButterDiscount_TwoBreadZeroButter_NoDiscount()
        {
            var breadDiscountToApply = _mockOffers.BreadAndButterDiscount(breadCost, 2, 0);

            Assert.AreEqual(0, breadDiscountToApply);
        }

        [TestMethod]
        public void BreadAndButterDiscount_FourBreadFourButter_TheCostOfBread()
        {
            var breadDiscountToApply = _mockOffers.BreadAndButterDiscount(breadCost, 4, 4);

            Assert.AreEqual(breadCost, breadDiscountToApply);
        }
    }
}
