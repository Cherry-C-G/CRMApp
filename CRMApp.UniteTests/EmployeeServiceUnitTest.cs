using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antra.CRMApp.Infrastructure.Service;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Moq;
using Antra.CRMApp.Core.Model;

namespace CRMApp.UnitTests
{
    [TestClass]
    public class EmployeeServiceAsyncUnitTest
    {
        /*
         * Arrange: Initializes objects, creates mock with arguments that are passed to the method under test and adds expectations.
         * Act: Invokes the method or property under test with the arranged parameters
         * Assert: Verifies that the action of the method under test behaves as expected
         */
        private EmployeeServiceAsync _sut;
        private static List<Employee> _employees;
        //Run in runtime, create class IEmployeeRepositoryAsync
        private Mock<IEmployeeRepositoryAsync> _mockEmployeeRepositoryAsync;

        [TestInitialize]
        //[OneTimeSetup] in
        //It's gonna call before each and every test method runs
        public void OneTimeSetup() //Use this method to set up fake data
        {
            _mockEmployeeRepositoryAsync = new Mock<IEmployeeRepositoryAsync>();

            //Dependency injection
            _sut = new EmployeeServiceAsync(_mockEmployeeRepositoryAsync.Object);

            //Whoever someone call GetAllAsync(), return _employees obj
            _mockEmployeeRepositoryAsync.Setup(m => m.GetAllAsync()).ReturnsAsync(_employees);


        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _employees = new List<Employee>
            {
                new Employee {Id = 1 ,FirstName="Rice", LastName="Noodle", Title="Employee", TitleOfCourtesy="MR ", Address= "Demo street ", City="Chicago ", RegionId=1 , PostalCode=12345 , Country= "USA ", Phone="1111111111 ", ReportsTo=1, PhotoPath="*** "},
                new Employee {Id = 2,  FirstName="Bread", LastName="Slice", Title="Manager", TitleOfCourtesy="MRS ", Address= "Demo1 street ", City="LA ", RegionId=2 , PostalCode=54321, Country= "USA ", Phone="2222222222 ", ReportsTo=2 , PhotoPath="*** "},
                new Employee {Id = 3, FirstName="Cake", LastName="Cup", Title="Sales", TitleOfCourtesy="MS ",  Address= "Demo2 street ", City="Lincoln ", RegionId=3 , PostalCode=11111 , Country= "USA ", Phone="3333333333 ", ReportsTo=1 , PhotoPath="*** " },
            };
        }


        [TestMethod]
        public async Task TestGetAllAsyncListOfEmployeesFromFakeData()
        {
            // SUT System under Test EmployeeServiceAsync => GetAllAsync()

            // Arranging:
            // mock objects, data, methods, .etc
            //Dependency injection
            //_sut = new EmployeeServiceAsync(new MockEmployeeRepositoryAsync());


            // Act: calling the actual method we testing
            var employees = await _sut.GetAllAsync();

            // check the actual output with expected data.
            // AAA:
            // Arrange, Act, Assert 

            // Assert: checking the expected value with actual value
            // do multiple condition checks (nullValue, dataTypes, .etc)
            //if one assert fail, the whole test fail (so do around 2-3 asserts)
            Assert.IsNotNull(employees);
            Assert.IsInstanceOfType(employees, typeof(IEnumerable<EmployeeRequestModel>));
            Assert.AreEqual(3, employees.Count());
        }

        //public class MockEmployeeRepositoryAsync : IEmployeeRepositoryAsync
        //{
        //    public Task<int> DeleteAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<IEnumerable<Employee>> GetAllAsync()
        //    {
        //        //This method will get fake data
        //        List<Employee> _employees = new List<Employee>
        //        {
        //            new Employee {Id = 1, Name = "Hulk", Phone = "2233222332" },
        //            new Employee {Id = 2, Name = "Thor", Phone = "9489382935"},
        //            new Employee {Id = 3, Name = "Iron Man", Phone = "2323445223"},
        //        };

        //        return _employees;
        //    }

        //    public Task<Employee> GetByIdAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> InsertAsync(Employee entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> UpdateAsync(Employee entity)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}