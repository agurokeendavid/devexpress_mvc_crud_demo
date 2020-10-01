using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Web.Enums;

namespace Demo.Web.Models
{
    public class Reference
    {
        public string ReferenceId { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime DateCreated { get; set; }
        public IsDeleted IsDeleted { get; set; }
    }
}