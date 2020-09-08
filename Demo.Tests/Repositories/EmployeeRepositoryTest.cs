using System;
using System.Collections.Generic;
using System.Linq;
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
                DateOfBirth = new DateTime(1998, 6, 21),
                EmployeeTypeId = "F1778BA40F6D44DC8F93CDF75B17612A"
            };

            // Act
            int result = await InsertEmployeeAsync(model); 

            // Assert
            Assert.IsTrue(result == (int) Result.Successful);
        }

        [TestMethod]
        public async Task Get_Employees_Async_Should_Return_True()
        {
            // Act
            var employees = await GetEmployeesAsync();

            // Assert
            Assert.IsTrue(employees.Cast<dynamic>().Any());
        }

        [TestMethod]
        public async Task Get_Employees_Async_Should_Equal_1()
        {
            // Arrange
            int actual = 1;

            // Act
            var employees = await GetEmployeesAsync();

            // Assert
            Assert.AreEqual(employees.Cast<dynamic>().Count(), actual);
        }

        [TestMethod]
        public async Task Update_Employee_Async_Should_Return_True()
        {
            // Arrange
            var model = new Employee
            {
                Id = "C82BE1B2F2BE4878A6EE8AEFA36F6164",
                FirstName = "Juan",
                MiddleName = "Cruz",
                LastName = "Smith",
                Gender = "MALE",
                DateOfBirth = new DateTime(2020, 6, 21),
                EmployeeTypeId = "F1778BA40F6D44DC8F93CDF75B17612A"
            };

            // Act
            var result = await UpdateEmployeeAsync(model);
            
            // Assert
            Assert.IsTrue(result == (int) Result.Successful);
        }

        [TestMethod]
        public async Task Delete_Employee_Async_Should_Return_True()
        {
            // Arrange
            string id = "C82BE1B2F2BE4878A6EE8AEFA36F6164";

            // Act
            int result = await DeleteEmployeeAsync(id);

            // Assert
            Assert.IsTrue(result == (int) Result.Successful);
        }
    }
}
