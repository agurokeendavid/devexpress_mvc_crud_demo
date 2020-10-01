﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Web.Enums;

namespace Demo.Web.Models
{
    public class EmployeeType
    {
        public string Id { get; set; }
        public string EmployeeTypeDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public IsDeleted IsDeleted { get; set; }

    }
}