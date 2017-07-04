using System.Collections.ObjectModel;
using DecisionTechDataContracts;
using DecisionTechShoppingBasket.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace DecisionTechShoppingBasket.UnitTests
{
    [TestClass]
    public class ShopUnitTests
    {
        private IStock _stubStock;
        private ICustomer _stubCustomer;
        private IOrder _stubOrder;
        private IShop _shop;

        private ProductOrdered _milkProductOrdered;
        private ProductOrdered _breadProductOrdered;
        private ProductOrdered _butterProductOrdered;

        [TestInitialize]
        public void Initialize()
        {
            _stubStock = MockRepository.GenerateStub<IStock>();
            _stubStock.Stub(s => s.GetAvailableProducts()).Return(new Collection<Product> { new Butter(), new Bread(), new Milk() });

            _stubCustomer = MockRepository.GenerateStub<ICustomer>();

            _butterProductOrdered = new ProductOrdered
            {
                Product = new Butter(),
                Quantity = 0
            };

            _breadProductOrdered = new ProductOrdered
            {
                Product = new Bread(),
                Quantity = 0
            };

            _milkProductOrdered = new ProductOrdered
            {
                Product = new Milk(),
                Quantity = 4
            };

            var collection = new Collection<ProductOrdered>
            {
                _milkProductOrdered,
                _breadProductOrdered,
                _butterProductOrdered
            };

            _stubCustomer.ShoppingBasket = new ShoppingBasket { ProductsOrdered = collection };

            _stubOrder = MockRepository.GenerateStub<IOrder>();

            _shop = new Shop(_stubCustomer, _stubStock, _stubOrder);

        }

        [TestMethod]
        public void PlaceCustomerOrder()
        {
            _shop.PlaceCustomerOrder();

            _stubStock.AssertWasCalled(s => s.GetAvailableProducts());

            _stubCustomer.AssertWasCalled(c => c.AddToBasket(Arg<Product>.Is.Anything, Arg<int>.Is.Anything));
            _stubCustomer.AssertWasCalled(c => c.GetQuantity(Arg<Product>.Is.Anything));

            _stubOrder.AssertWasCalled(o => o.ApplyDiscounts(Arg<IShoppingBasket>.Is.Anything));
        }
    }
}
