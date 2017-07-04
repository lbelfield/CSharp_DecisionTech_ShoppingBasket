using System.Collections.ObjectModel;
using DecisionTechDataContracts;
using DecisionTechShoppingBasket.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace DecisionTechShoppingBasket.UnitTests
{
    [TestClass]
    public class OrderUnitTests
    {
        private IOffers _stubOffers;
        private IShoppingBasket _stubShoppingBasket;
        private IOrder _mockOrder;

        private ProductOrdered _milkProductOrdered;
        private ProductOrdered _breadProductOrdered;
        private ProductOrdered _butterProductOrdered;

        [TestInitialize]
        public void Initialize()
        {
            _milkProductOrdered = new ProductOrdered
            {
                Product = new Milk(),
                Quantity = 1
            };

            _breadProductOrdered = new ProductOrdered
            {
                Product = new Bread(),
                Quantity = 1
            };

            _butterProductOrdered = new ProductOrdered
            {
                Product = new Butter(),
                Quantity = 1
            };

            var collection = new Collection<ProductOrdered>
            {
                _milkProductOrdered,
                _breadProductOrdered,
                _butterProductOrdered
            };

            _stubOffers = MockRepository.GenerateStub<IOffers>();
            _stubShoppingBasket = MockRepository.GenerateStub<IShoppingBasket>();
            _stubShoppingBasket.ProductsOrdered = collection;

            _mockOrder = new Order(_stubOffers);
        }

        [TestMethod]
        public void ApplyDiscounts()
        {
            _mockOrder.ApplyDiscounts(_stubShoppingBasket);

            _stubOffers.AssertWasCalled(b => b.FourForThreeMilkDiscount(Arg<double>.Is.Anything, Arg<int>.Is.Anything));
            _stubOffers.AssertWasCalled(b => b.BreadAndButterDiscount(Arg<double>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything));
        }
    }
}
