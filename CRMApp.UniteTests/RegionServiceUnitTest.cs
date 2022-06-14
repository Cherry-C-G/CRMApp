using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antra.CRMApp.Infrastructure.Service;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Moq;
using Antra.CRMApp.Core.Model;

namespace CRMApp.UnitTests
{
    [TestClass]
    public class RegionServiceAsyncUnitTest
    {
        /*
         * Arrange: Initializes objects, creates mock with arguments that are passed to the method under test and adds expectations.
         * Act: Invokes the method or property under test with the arranged parameters
         * Assert: Verifies that the action of the method under test behaves as expected
         */
        private RegionServiceAsync _sut;
        private static List<Region> _regions;
        //Run in runtime, create class IRegionRepositoryAsync
        private Mock<IRegionRepositoryAsync> _mockRegionRepositoryAsync;

        [TestInitialize]
        //[OneTimeSetup] in
        //It's gonna call before each and every test method runs
        public void OneTimeSetup() //Use this method to set up fake data
        {
            _mockRegionRepositoryAsync = new Mock<IRegionRepositoryAsync>();

            //Dependency injection
            _sut = new RegionServiceAsync(_mockRegionRepositoryAsync.Object);

            //Whoever someone call GetAllAsync(), return _regions obj
            _mockRegionRepositoryAsync.Setup(m => m.GetAllAsync()).ReturnsAsync(_regions);


        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _regions = new List<Region>
            {
                new Region {Id = 1, Name = "Hulk" },
                new Region {Id = 2, Name = "Thor"},
                new Region {Id = 3, Name = "Iron Man"},
            };
        }


        [TestMethod]
        public async Task TestGetAllAsyncListOfRegionsFromFakeData()
        {
            // SUT System under Test ProductServiceAsync => GetAllAsync()

            // Arranging:
            // mock objects, data, methods, .etc
            //Dependency injection
            //_sut = new RegionServiceAsync(new MockRegionRepositoryAsync());


            // Act: calling the actual method we testing
            var regions = await _sut.GetAllAsync();

            // check the actual output with expected data.
            // AAA:
            // Arrange, Act, Assert 

            // Assert: checking the expected value with actual value
            // do multiple condition checks (nullValue, dataTypes, .etc)
            //if one assert fail, the whole test fail (so do around 2-3 asserts)
            Assert.IsNotNull(regions);
            Assert.IsInstanceOfType(regions, typeof(IEnumerable<RegionRequestModel>));
            Assert.AreEqual(3, regions.Count());
        }

        //public class MockRegionRepositoryAsync : IRegionRepositoryAsync
        //{
        //    public Task<int> DeleteAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<IEnumerable<Region>> GetAllAsync()
        //    {
        //        //This method will get fake data
        //        List<Region> _regions = new List<Region>
        //        {
        //            new Region {Id = 1, Name = "Hulk", Phone = "2233222332" },
        //            new Region {Id = 2, Name = "Thor", Phone = "9489382935"},
        //            new Region {Id = 3, Name = "Iron Man", Phone = "2323445223"},
        //        };

        //        return _regions;
        //    }

        //    public Task<Region> GetByIdAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> InsertAsync(Region entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> UpdateAsync(Region entity)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}