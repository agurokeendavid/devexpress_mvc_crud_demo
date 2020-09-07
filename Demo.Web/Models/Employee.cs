using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Web.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string EmployeeTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}