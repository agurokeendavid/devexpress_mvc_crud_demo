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
    public class EmployeeTypeRepository
    {
        public static async Task<int> InsertEmployeeTypeAsync(EmployeeType employeeType)
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                string query = "INSERT INTO EMPLOYEE_TYPE (EMPLOYEE_TYPE_DESC) VALUES (UPPER(:P_EMPLOYEE_TYPE_DESC))";
                var parameters = new OracleDynamicParameters();
                parameters.Add("P_EMPLOYEE_TYPE_DESC", employeeType.EmployeeTypeDescription,
                    OracleMappingType.Varchar2);
                return await connection.ExecuteAsync(query, parameters);
            }
        }

        public static async Task<IEnumerable<EmployeeType>> GetEmployeeTypeAsync()
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                string query =
                    "SELECT ID Id, EMPLOYEE_TYPE_DESC EmployeeTypeDescription, DATE_CREATED DateCreated FROM EMPLOYEE_TYPE";
                return await connection.QueryAsync<EmployeeType>(query);
            }
        }

    }
}