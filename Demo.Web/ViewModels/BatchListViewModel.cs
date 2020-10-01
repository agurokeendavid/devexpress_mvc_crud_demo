using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Web.Models;

namespace Demo.Web.ViewModels
{
    public class BatchListViewModel
    {
        public IEnumerable<Reference> References { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<EmployeeType> EmployeeTypes { get; set; }
    }
}