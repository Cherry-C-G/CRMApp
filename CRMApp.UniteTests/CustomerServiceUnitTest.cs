using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antra.CRMApp.Infrastructure.Service;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Moq;
using Antra.CRMApp.Core.Model;

namespace CRMApp.UnitTests
{
    [TestClass]
    public class CustomerServiceAsyncUnitTest
    {
        /*
         * Arrange: Initializes objects, creates mock with arguments that are passed to the method under test and adds expectations.
         * Act: Invokes the method or property under test with the arranged parameters
         * Assert: Verifies that the action of the method under test behaves as expected
         */
        private CustomerServiceAsync _sut;
        private static List<Customer> _customers;
        //Run in runtime, create class ICustomerRepositoryAsync
        private Mock<ICustomerRepositoryAsync> _mockCustomerRepositoryAsync;

        [TestInitialize]
        //[OneTimeSetup] in
        //It's gonna call before each and every test method runs
        public void OneTimeSetup() //Use this method to set up fake data
        {
            _mockCustomerRepositoryAsync = new Mock<ICustomerRepositoryAsync>();

            //Dependency injection
            _sut = new CustomerServiceAsync(_mockCustomerRepositoryAsync.Object);

            //Whoever someone call GetAllAsync(), return _customers obj
            _mockCustomerRepositoryAsync.Setup(m => m.GetAllAsync()).ReturnsAsync(_customers);


        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _customers = new List<Customer>
            {
                new Customer {Id = 1 ,Name="Rice", Title="Customer", Address= "Demo street ", City="Chicago ", RegionId=1, PostalCode=12345 , Country= "USA ", Phone="1111111111 "},
                new Customer {Id = 2,  Name="Bread",  Title="Manager", Address= "Demo1 street ", City="LA ", RegionId=2, PostalCode= 54321, Country= "USA ", Phone="2222222222 "},
                new Customer {Id = 3, Name="Cake", Title="Sales", Address= "Demo2 street ", City="Lincoln ", RegionId=3, PostalCode=11111 , Country= "USA ", Phone="3333333333 "},
            };
        }


        [TestMethod]
        public async Task TestGetAllAsyncListOfCustomersFromFakeData()
        {
            // SUT System under Test CustomerServiceAsync => GetAllAsync()

            // Arranging:
            // mock objects, data, methods, .etc
            //Dependency injection
            //_sut = new CustomerServiceAsync(new MockCustomerRepositoryAsync());


            // Act: calling the actual method we testing
            var customers = await _sut.GetAllAsync();

            // check the actual output with expected data.
            // AAA:
            // Arrange, Act, Assert 

            // Assert: checking the expected value with actual value
            // do multiple condition checks (nullValue, dataTypes, .etc)
            //if one assert fail, the whole test fail (so do around 2-3 asserts)
            Assert.IsNotNull(customers);
            Assert.IsInstanceOfType(customers, typeof(IEnumerable<CustomerRequestModel>));
            Assert.AreEqual(3, customers.Count());
        }

        //public class MockCustomerRepositoryAsync : ICustomerRepositoryAsync
        //{
        //    public Task<int> DeleteAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<IEnumerable<Customer>> GetAllAsync()
        //    {
        //        //This method will get fake data
        //        List<Customer> _customers = new List<Customer>
        //        {
        //            new Customer {Id = 1, Name = "Hulk", Phone = "2233222332" },
        //            new Customer {Id = 2, Name = "Thor", Phone = "9489382935"},
        //            new Customer {Id = 3, Name = "Iron Man", Phone = "2323445223"},
        //        };

        //        return _customers;
        //    }

        //    public Task<Customer> GetByIdAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> InsertAsync(Customer entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> UpdateAsync(Customer entity)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}