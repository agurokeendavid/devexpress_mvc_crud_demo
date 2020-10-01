using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Web.Models;

namespace Demo.Web.ViewModels
{
    public class BatchCreateViewModel
    {
        public string Id { get; set; }
        public string ReferenceId { get; set; }
        public string ReferenceNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmployeeTypeId { get; set; }
        public IEnumerable<EmployeeType> EmployeeTypes { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}