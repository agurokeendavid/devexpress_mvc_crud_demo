using System;
using System.Threading.Tasks;
using Demo.Tests.Enums;
using Demo.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Demo.Web.Repositories.EmployeeRepository;

namespace Demo.Tests.Repositories
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        [TestMethod]
        public async Task Insert_Employee_Async_Should_Return_True()
        {
            // Arrange
            var model = new Employee
            {
                FirstName = "Juan",
                MiddleName = "Smith",
                LastName = "Cruz",
                Gender = "MALE",
                Dob = new DateTime(1998, 6, 21),
                EmployeeTypeId = "F1778BA40F6D44DC8F93CDF75B17612A"
            };

            // Act
            int result = await InsertEmployeeAsync(model); 

            // Assert
            Assert.IsTrue(result == (int) Result.Successful);
        }
    }
}
