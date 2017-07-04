using System.Collections.ObjectModel;
using DecisionTechDataContracts;
using DecisionTechShoppingBasket.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace DecisionTechShoppingBasket.UnitTests
{
    [TestClass]
    public class CustomerUnitTests
    {
        private IShoppingBasket _stubShoppingBasket;
        private ICustomer _mockCustomer;

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

            _stubShoppingBasket = MockRepository.GenerateStub<IShoppingBasket>();
            _stubShoppingBasket.ProductsOrdered = collection;

            _mockCustomer = new Customer(_stubShoppingBasket);
        }

        [TestMethod]
        public void AddToBasket()
        {
            _mockCustomer.AddToBasket(new Milk(), 2);

            Assert.AreEqual(_stubShoppingBasket.ProductsOrdered[3].Product.Name, "Milk");
            Assert.AreEqual(_stubShoppingBasket.ProductsOrdered[3].Product.Cost, 1.15);
            Assert.AreEqual(_stubShoppingBasket.ProductsOrdered[3].Quantity, 2);
        }
    }
}
