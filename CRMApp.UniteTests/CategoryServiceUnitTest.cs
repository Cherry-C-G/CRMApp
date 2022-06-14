using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antra.CRMApp.Infrastructure.Service;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Moq;
using Antra.CRMApp.Core.Model;

namespace CRMApp.UnitTests
{
    [TestClass]
    public class CategoryServiceAsyncUnitTest
    {
        /*
         * Arrange: Initializes objects, creates mock with arguments that are passed to the method under test and adds expectations.
         * Act: Invokes the method or property under test with the arranged parameters
         * Assert: Verifies that the action of the method under test behaves as expected
         */
        private CategoryServiceAsync _sut;
        private static List<Category> _categorys;
        //Run in runtime, create class ICategoryRepositoryAsync
        private Mock<ICategoryRepositoryAsync> _mockCategoryRepositoryAsync;

        [TestInitialize]
        //[OneTimeSetup] in
        //It's gonna call before each and every test method runs
        public void OneTimeSetup() //Use this method to set up fake data
        {
            _mockCategoryRepositoryAsync = new Mock<ICategoryRepositoryAsync>();

            //Dependency injection
            _sut = new CategoryServiceAsync(_mockCategoryRepositoryAsync.Object);

            //Whoever someone call GetAllAsync(), return _categorys obj
            _mockCategoryRepositoryAsync.Setup(m => m.GetAllAsync()).ReturnsAsync(_categorys);


        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _categorys = new List<Category>
            {
                new Category {Id = 1 ,Name="Rice", Description="Employee"},
                new Category {Id = 2,  Name="Bread",  Description="Manager"},
                new Category {Id = 3, Name="Cake", Description="Sales"},
            };
        }


        [TestMethod]
        public async Task TestGetAllAsyncListOfCategorysFromFakeData()
        {
            // SUT System under Test CategoryServiceAsync => GetAllAsync()

            // Arranging:
            // mock objects, data, methods, .etc
            //Dependency injection
            //_sut = new CategoryServiceAsync(new MockCategoryRepositoryAsync());


            // Act: calling the actual method we testing
            var categorys = await _sut.GetAllAsync();

            // check the actual output with expected data.
            // AAA:
            // Arrange, Act, Assert 

            // Assert: checking the expected value with actual value
            // do multiple condition checks (nullValue, dataTypes, .etc)
            //if one assert fail, the whole test fail (so do around 2-3 asserts)
            Assert.IsNotNull(categorys);
            Assert.IsInstanceOfType(categorys, typeof(IEnumerable<CategoryRequestModel>));
            Assert.AreEqual(3, categorys.Count());
        }

        //public class MockCategoryRepositoryAsync : ICategoryRepositoryAsync
        //{
        //    public Task<int> DeleteAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<IEnumerable<Category>> GetAllAsync()
        //    {
        //        //This method will get fake data
        //        List<Category> _categorys = new List<Category>
        //        {
        //            new Category {Id = 1, Name = "Hulk", Phone = "2233222332" },
        //            new Category {Id = 2, Name = "Thor", Phone = "9489382935"},
        //            new Category {Id = 3, Name = "Iron Man", Phone = "2323445223"},
        //        };

        //        return _categorys;
        //    }

        //    public Task<Category> GetByIdAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> InsertAsync(Category entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> UpdateAsync(Category entity)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}