using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Demo.Web.DBConnection
{
    public class OracleConnectionString
    {
        public static string GetConnectionString(string connectionName = "MVC_CRUD_DEMO")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
    }
}