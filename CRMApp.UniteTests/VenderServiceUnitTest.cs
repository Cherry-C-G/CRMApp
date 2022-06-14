using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antra.CRMApp.Infrastructure.Service;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Moq;
using Antra.CRMApp.Core.Model;

namespace CRMApp.UnitTests
{
    [TestClass]
    public class VendorServiceAsyncUnitTest
    {
        /*
         * Arrange: Initializes objects, creates mock with arguments that are passed to the method under test and adds expectations.
         * Act: Invokes the method or property under test with the arranged parameters
         * Assert: Verifies that the action of the method under test behaves as expected
         */
        private VendorServiceAsync _sut;
        private static List<Vendor> _vendors;
        //Run in runtime, create class IVendorRepositoryAsync
        private Mock<IVendorRepositoryAsync> _mockVendorRepositoryAsync;

        [TestInitialize]
        //[OneTimeSetup] in
        //It's gonna call before each and every test method runs
        public void OneTimeSetup() //Use this method to set up fake data
        {
            _mockVendorRepositoryAsync = new Mock<IVendorRepositoryAsync>();

            //Dependency injection
            _sut = new VendorServiceAsync(_mockVendorRepositoryAsync.Object);

            //Whoever someone call GetAllAsync(), return _vendors obj
            _mockVendorRepositoryAsync.Setup(m => m.GetAllAsync()).ReturnsAsync(_vendors);


        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _vendors = new List<Vendor>
            {
                new Vendor {Id = 1, Name = "Hulk", Country="USA" , Mobile="111111111", City="Chicago", },
                new Vendor {Id = 2, Name = "Thor", Country="USA", Mobile ="2222222222", City="Lincoln"},
                new Vendor {Id = 3, Name = "Iron Man", Country="USA", Mobile="3333333333", City="LA"},
            };
        }


        [TestMethod]
        public async Task TestGetAllAsyncListOfVendorsFromFakeData()
        {
            // SUT System under Test ProductServiceAsync => GetAllAsync()

            // Arranging:
            // mock objects, data, methods, .etc
            //Dependency injection
            //_sut = new VendorServiceAsync(new MockVendorRepositoryAsync());


            // Act: calling the actual method we testing
            var vendors = await _sut.GetAllAsync();

            // check the actual output with expected data.
            // AAA:
            // Arrange, Act, Assert 

            // Assert: checking the expected value with actual value
            // do multiple condition checks (nullValue, dataTypes, .etc)
            //if one assert fail, the whole test fail (so do around 2-3 asserts)
            Assert.IsNotNull(vendors);
            Assert.IsInstanceOfType(vendors, typeof(IEnumerable<VendorRequestModel>));
            Assert.AreEqual(3, vendors.Count());
        }

        //public class MockVendorRepositoryAsync : IVendorRepositoryAsync
        //{
        //    public Task<int> DeleteAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<IEnumerable<Vendor>> GetAllAsync()
        //    {
        //        //This method will get fake data
        //        List<Vendor> _vendors = new List<Vendor>
        //        {
        //            new Vendor {Id = 1, Name = "Hulk", Phone = "2233222332" },
        //            new Vendor {Id = 2, Name = "Thor", Phone = "9489382935"},
        //            new Vendor {Id = 3, Name = "Iron Man", Phone = "2323445223"},
        //        };

        //        return _vendors;
        //    }

        //    public Task<Vendor> GetByIdAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> InsertAsync(Vendor entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> UpdateAsync(Vendor entity)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}