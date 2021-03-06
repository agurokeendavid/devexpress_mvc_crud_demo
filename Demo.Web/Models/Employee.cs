﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Web.Enums;

namespace Demo.Web.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string ReferenceId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmployeeTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public Reference Reference { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public IsDeleted IsDeleted { get; set; }
    }
}