using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using Dapper.Oracle;
using Demo.Web.Models;
using Oracle.ManagedDataAccess.Client;
using static Demo.Web.DBConnection.OracleConnectionString;

namespace Demo.Web.Repositories
{
    public class EmployeeRepository
    {
        public static async Task<int> InsertEmployeeAsync(Employee employee)
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                string query = "INSERT INTO EMPLOYEES (FIRST_NAME, MIDDLE_NAME, LAST_NAME, GENDER, DOB, EMPLOYEE_TYPE_ID) VALUES (UPPER(:P_FIRST_NAME), UPPER(:P_MIDDLE_NAME), UPPER(:P_LAST_NAME), :P_GENDER, :P_DOB, :P_EMPLOYEE_TYPE_ID)";
                var parameters = new OracleDynamicParameters();
                parameters.Add("P_FIRST_NAME", employee.FirstName, OracleMappingType.Varchar2);
                parameters.Add("P_MIDDLE_NAME", employee.MiddleName, OracleMappingType.Varchar2);
                parameters.Add("P_LAST_NAME", employee.LastName, OracleMappingType.Varchar2);
                parameters.Add("P_GENDER", employee.Gender, OracleMappingType.Varchar2);
                parameters.Add("P_DOB", employee.Dob, OracleMappingType.Date);
                parameters.Add("P_EMPLOYEE_TYPE_ID", employee.EmployeeTypeId, OracleMappingType.Varchar2);
                return await connection.ExecuteAsync(query, parameters);
            }
        }

    }
}