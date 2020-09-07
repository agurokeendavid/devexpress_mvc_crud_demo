using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Tests.Enums;
using Demo.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Demo.Web.Repositories.EmployeeTypeRepository;

namespace Demo.Tests.Repositories
{
    [TestClass]
    public class EmployeeTypeRepositoryTest
    {
        [TestMethod]
        public async Task Insert_Employee_Type_Async_Should_Return_True()
        {
            // Arrange
            var model = new EmployeeType
            {
                EmployeeTypeDescription = "Contractual"
            };

            // Act
            int result = await InsertEmployeeTypeAsync(model);

            // Assert
            Assert.IsTrue(result == (int) Result.Successful);
        }

        [TestMethod]
        public async Task Get_Employee_Type_Async_Should_Return_True()
        {
            // Act
            IEnumerable<EmployeeType> result = await GetEmployeeTypeAsync();

            // Assert
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task Get_Employee_Type_Async_Should_Equal_2()
        {
            // Arrange
            int actual = 2;

            // Act
            IEnumerable<EmployeeType> result = await GetEmployeeTypeAsync();

            // Assert
            Assert.AreEqual(result.Count(), actual);
        }
    }
}
