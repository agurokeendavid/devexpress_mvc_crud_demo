using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Demo.Web.Models;

namespace Demo.Web.ViewModels
{
    public class HomeViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "*")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "*")]
        public string EmployeeTypeId { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<EmployeeType> EmployeeTypes { get; set; }
    }
}