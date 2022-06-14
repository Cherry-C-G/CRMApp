using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antra.CRMApp.Infrastructure.Service;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Moq;
using Antra.CRMApp.Core.Model;

namespace CRMApp.UnitTests
{
    [TestClass]
    public class ProductServiceAsyncUnitTest
    {
        /*
         * Arrange: Initializes objects, creates mock with arguments that are passed to the method under test and adds expectations.
         * Act: Invokes the method or property under test with the arranged parameters
         * Assert: Verifies that the action of the method under test behaves as expected
         */
        private ProductServiceAsync _sut;
        private static List<Product> _products;
        //Run in runtime, create class IProductRepositoryAsync
        private Mock<IProductRepositoryAsync> _mockProductRepositoryAsync;

        [TestInitialize]
        //[OneTimeSetup] in
        //It's gonna call before each and every test method runs
        public void OneTimeSetup() //Use this method to set up fake data
        {
            _mockProductRepositoryAsync = new Mock<IProductRepositoryAsync>();

            //Dependency injection
            _sut = new ProductServiceAsync(_mockProductRepositoryAsync.Object);

            //Whoever someone call GetAllAsync(), return _products obj
            _mockProductRepositoryAsync.Setup(m => m.GetAllAsync()).ReturnsAsync(_products);


        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _products = new List<Product>
            {
                new Product {Id = 1 ,Name="Rice", VendorId=1, CategoryId=3, QuantityPerUnit=2 , UnitPrice=1 , UnitsInStock=3 , UnitsOnOrder= 1 , ReorderLevel=1 , Discontinued=true  },
                new Product {Id = 2, Name="Bread", VendorId=2, CategoryId=2, QuantityPerUnit=5 , UnitPrice=1 , UnitsInStock=4 , UnitsOnOrder= 2 , ReorderLevel=2 , Discontinued=false  },
                new Product {Id = 3, Name="Egg", VendorId=3, CategoryId=1, QuantityPerUnit=7 , UnitPrice= 1, UnitsInStock=5 , UnitsOnOrder= 3 , ReorderLevel=3 , Discontinued=true  },
            };
        }


        [TestMethod]
        public async Task TestGetAllAsyncListOfProductsFromFakeData()
        {
            // SUT System under Test ProductServiceAsync => GetAllAsync()

            // Arranging:
            // mock objects, data, methods, .etc
            //Dependency injection
            //_sut = new ProductServiceAsync(new MockProductRepositoryAsync());


            // Act: calling the actual method we testing
            var products = await _sut.GetAllAsync();

            // check the actual output with expected data.
            // AAA:
            // Arrange, Act, Assert 

            // Assert: checking the expected value with actual value
            // do multiple condition checks (nullValue, dataTypes, .etc)
            //if one assert fail, the whole test fail (so do around 2-3 asserts)
            Assert.IsNotNull(products);
            Assert.IsInstanceOfType(products, typeof(IEnumerable<ProductRequestModel>));
            Assert.AreEqual(3, products.Count());
        }

        //public class MockProductRepositoryAsync : IProductRepositoryAsync
        //{
        //    public Task<int> DeleteAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<IEnumerable<Product>> GetAllAsync()
        //    {
        //        //This method will get fake data
        //        List<Product> _products = new List<Product>
        //        {
        //            new Product {Id = 1, Name = "Hulk", Phone = "2233222332" },
        //            new Product {Id = 2, Name = "Thor", Phone = "9489382935"},
        //            new Product {Id = 3, Name = "Iron Man", Phone = "2323445223"},
        //        };

        //        return _products;
        //    }

        //    public Task<Product> GetByIdAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> InsertAsync(Product entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> UpdateAsync(Product entity)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}