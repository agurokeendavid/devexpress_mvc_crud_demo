using System;
using System.Collections;
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
                string query = "INSERT INTO EMPLOYEES (FIRST_NAME, MIDDLE_NAME, LAST_NAME, GENDER, DATE_OF_BIRTH, EMPLOYEE_TYPE_ID) VALUES (UPPER(:P_FIRST_NAME), UPPER(:P_MIDDLE_NAME), UPPER(:P_LAST_NAME), :P_GENDER, :P_DATE_OF_BIRTH, :P_EMPLOYEE_TYPE_ID)";
                var parameters = new OracleDynamicParameters();
                parameters.Add("P_FIRST_NAME", employee.FirstName, OracleMappingType.Varchar2);
                parameters.Add("P_MIDDLE_NAME", employee.MiddleName, OracleMappingType.Varchar2);
                parameters.Add("P_LAST_NAME", employee.LastName, OracleMappingType.Varchar2);
                parameters.Add("P_GENDER", employee.Gender, OracleMappingType.Varchar2);
                parameters.Add("P_DATE_OF_BIRTH", employee.DateOfBirth, OracleMappingType.Date);
                parameters.Add("P_EMPLOYEE_TYPE_ID", employee.EmployeeTypeId, OracleMappingType.Varchar2);
                return await connection.ExecuteAsync(query, parameters);
            }
        }

        public static async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                string query =
                    "SELECT ID Id, FIRST_NAME FirstName, MIDDLE_NAME MiddleName, LAST_NAME LastName, GENDER Gender, DATE_OF_BIRTH DateOfBirth, EMPLOYEE_TYPE_ID EmployeeTypeId, DATE_CREATED DateCreated FROM EMPLOYEES";
                return await connection.QueryAsync<Employee>(query);
            }
        }

        public static async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                string query =
                    "UPDATE EMPLOYEES SET FIRST_NAME = UPPER(:P_FIRST_NAME), MIDDLE_NAME = UPPER(:P_MIDDLE_NAME), LAST_NAME = UPPER(:P_LAST_NAME), GENDER = :P_GENDER, DATE_OF_BIRTH = :P_DATE_OF_BIRTH, EMPLOYEE_TYPE_ID = :P_EMPLOYEE_TYPE_ID WHERE ID = :P_ID";
                var parameters = new OracleDynamicParameters();
                parameters.Add("P_FIRST_NAME", employee.FirstName, OracleMappingType.Varchar2);
                parameters.Add("P_MIDDLE_NAME", employee.MiddleName, OracleMappingType.Varchar2);
                parameters.Add("P_LAST_NAME", employee.LastName, OracleMappingType.Varchar2);
                parameters.Add("P_GENDER", employee.Gender, OracleMappingType.Varchar2);
                parameters.Add("P_DATE_OF_BIRTH", employee.DateOfBirth, OracleMappingType.Date);
                parameters.Add("P_EMPLOYEE_TYPE_ID", employee.EmployeeTypeId, OracleMappingType.Varchar2);
                parameters.Add("P_ID", employee.Id, OracleMappingType.Varchar2);
                return await connection.ExecuteAsync(query, parameters);
            }
        }

        public static async Task<int> DeleteEmployeeAsync(string id)
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                string query = "DELETE FROM EMPLOYEES WHERE ID = :P_ID";
                var parameters = new OracleDynamicParameters();
                parameters.Add("P_ID", id, OracleMappingType.Varchar2);
                return await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}