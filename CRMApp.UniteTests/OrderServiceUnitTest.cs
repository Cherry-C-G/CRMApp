using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antra.CRMApp.Infrastructure.Service;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Moq;
using Antra.CRMApp.Core.Model;

namespace CRMApp.UnitTests
{
    [TestClass]
    public class OrderServiceAsyncUnitTest
    {
        /*
         * Arrange: Initializes objects, creates mock with arguments that are passed to the method under test and adds expectations.
         * Act: Invokes the method or property under test with the arranged parameters
         * Assert: Verifies that the action of the method under test behaves as expected
         */
        private OrderServiceAsync _sut;
        private static List<Order> _orders;
        //Run in runtime, create class IOrderRepositoryAsync
        private Mock<IOrderRepositoryAsync> _mockOrderRepositoryAsync;

        [TestInitialize]
        //[OneTimeSetup] in
        //It's gonna call before each and every test method runs
        public void OneTimeSetup() //Use this method to set up fake data
        {
            _mockOrderRepositoryAsync = new Mock<IOrderRepositoryAsync>();

            //Dependency injection
            _sut = new OrderServiceAsync(_mockOrderRepositoryAsync.Object);

            //Whoever someone call GetAllAsync(), return _orders obj
            _mockOrderRepositoryAsync.Setup(m => m.GetAllAsync()).ReturnsAsync(_orders);


        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _orders = new List<Order>
            {
                new Order {Id = 1 },
                new Order {Id = 2},
                new Order {Id = 3},
            };
        }


        [TestMethod]
        public async Task TestGetAllAsyncListOfOrdersFromFakeData()
        {
            // SUT System under Test ProductServiceAsync => GetAllAsync()

            // Arranging:
            // mock objects, data, methods, .etc
            //Dependency injection
            //_sut = new OrderServiceAsync(new MockOrderRepositoryAsync());


            // Act: calling the actual method we testing
            var orders = await _sut.GetAllAsync();

            // check the actual output with expected data.
            // AAA:
            // Arrange, Act, Assert 

            // Assert: checking the expected value with actual value
            // do multiple condition checks (nullValue, dataTypes, .etc)
            //if one assert fail, the whole test fail (so do around 2-3 asserts)
            Assert.IsNotNull(orders);
            Assert.IsInstanceOfType(orders, typeof(IEnumerable<OrderRequestModel>));
            Assert.AreEqual(3, orders.Count());
        }

        //public class MockOrderRepositoryAsync : IOrderRepositoryAsync
        //{
        //    public Task<int> DeleteAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<IEnumerable<Order>> GetAllAsync()
        //    {
        //        //This method will get fake data
        //        List<Order> _orders = new List<Order>
        //        {
        //            new Order {Id = 1, Name = "Hulk", Phone = "2233222332" },
        //            new Order {Id = 2, Name = "Thor", Phone = "9489382935"},
        //            new Order {Id = 3, Name = "Iron Man", Phone = "2323445223"},
        //        };

        //        return _orders;
        //    }

        //    public Task<Order> GetByIdAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> InsertAsync(Order entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> UpdateAsync(Order entity)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}