using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using Dapper.Oracle;
using Demo.Web.Enums;
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
                string query = "INSERT INTO EMPLOYEES (REFERENCE_ID, FIRST_NAME, MIDDLE_NAME, LAST_NAME, GENDER, DATE_OF_BIRTH, EMPLOYEE_TYPE_ID) VALUES (:P_REFERENCE_ID, UPPER(:P_FIRST_NAME), UPPER(:P_MIDDLE_NAME), UPPER(:P_LAST_NAME), :P_GENDER, :P_DATE_OF_BIRTH, :P_EMPLOYEE_TYPE_ID)";
                var parameters = new OracleDynamicParameters();
                parameters.Add("P_REFERENCE_ID", employee.ReferenceId, OracleMappingType.Varchar2);
                parameters.Add("P_FIRST_NAME", employee.FirstName, OracleMappingType.Varchar2);
                parameters.Add("P_MIDDLE_NAME", employee.MiddleName, OracleMappingType.Varchar2);
                parameters.Add("P_LAST_NAME", employee.LastName, OracleMappingType.Varchar2);
                parameters.Add("P_GENDER", employee.Gender, OracleMappingType.Varchar2);
                parameters.Add("P_DATE_OF_BIRTH", employee.DateOfBirth, OracleMappingType.Date);
                parameters.Add("P_EMPLOYEE_TYPE_ID", employee.EmployeeTypeId, OracleMappingType.Varchar2);
                return await connection.ExecuteAsync(query, parameters);
            }
        }

        public static async Task<List<Employee>> GetEmployeesByReferenceIdAsync(string referenceId, IsDeleted isDeleted)
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                string query = "SELECT EMPLOYEES.ID Id, EMPLOYEES.FIRST_NAME FirstName, NVL(EMPLOYEES.MIDDLE_NAME, 'N/A') MiddleName, EMPLOYEES.LAST_NAME LastName, EMPLOYEES.GENDER Gender, EMPLOYEES.DATE_OF_BIRTH DateOfBirth, EMPLOYEES.EMPLOYEE_TYPE_ID EmployeeTypeId, EMPLOYEES.DATE_CREATED DateCreated, REFERENCES.REFERENCE_NO ReferenceNo, EMPLOYEE_TYPE.EMPLOYEE_TYPE_DESC EmployeeTypeDescription FROM EMPLOYEES INNER JOIN REFERENCES ON EMPLOYEES.REFERENCE_ID = REFERENCES.REFERENCE_ID INNER JOIN EMPLOYEE_TYPE ON EMPLOYEES.EMPLOYEE_TYPE_ID = EMPLOYEE_TYPE.ID WHERE EMPLOYEES.REFERENCE_ID = :P_REFERENCE_ID AND EMPLOYEES.IS_DELETED = :P_IS_DELETED ORDER BY EMPLOYEES.DATE_CREATED DESC";
                var parameters = new OracleDynamicParameters();
                parameters.Add("P_REFERENCE_ID", referenceId, OracleMappingType.Varchar2);
                parameters.Add("P_IS_DELETED", isDeleted, OracleMappingType.Byte);
                var result = await connection.QueryAsync<Employee, Reference, EmployeeType, Employee>(query,
                    (employee, reference, employeeType) =>
                    {
                        employee.Reference = reference;
                        employee.EmployeeType = employeeType;
                        return employee;
                    }, parameters, splitOn: "ReferenceNo,EmployeeTypeDescription");
                return result.ToList();
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