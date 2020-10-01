using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Oracle;
using Demo.Web.Enums;
using Demo.Web.Models;
using Oracle.ManagedDataAccess.Client;
using static Demo.Web.DBConnection.OracleConnectionString;

namespace Demo.Web.Repositories
{
    public class ReferenceRepository
    {
        public static async Task<string> GetReferenceNoSequenceAsync()
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                string query = "SELECT REFERENCE_NO_SEQ.NEXTVAL FROM DUAL";
                return await connection.ExecuteScalarAsync<string>(query);
            }
        }

        public static async Task<int> InsertReferenceAsync(Reference reference)
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                string query = "INSERT INTO REFERENCES (REFERENCE_ID, REFERENCE_NO) VALUES (:P_REFERENCE_ID, :P_REFERENCE_NO)";
                var parameters = new OracleDynamicParameters();
                parameters.Add("P_REFERENCE_ID", reference.ReferenceId, OracleMappingType.Varchar2);
                parameters.Add("P_REFERENCE_NO", reference.ReferenceNo, OracleMappingType.Varchar2);
                return await connection.ExecuteAsync(query, parameters);
            }
        }

        public static async Task<bool> HasExistingReferenceIdAsync(string referenceId)
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                string query = "SELECT COUNT(1) FROM REFERENCES WHERE REFERENCE_ID = :P_REFERENCE_ID";
                var parameters = new OracleDynamicParameters();
                parameters.Add("P_REFERENCE_ID", referenceId, OracleMappingType.Varchar2);
                return await connection.ExecuteScalarAsync<bool>(query, parameters);
            }
        }

        public static async Task<IEnumerable<Reference>> GetAllReferenceAsync(IsDeleted isDeleted)
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                string query = "SELECT REFERENCE_ID ReferenceId, REFERENCE_NO ReferenceNo, DATE_CREATED DateCreated FROM REFERENCES WHERE IS_DELETED = :P_IS_DELETED";
                var parameters = new OracleDynamicParameters();
                parameters.Add("P_IS_DELETED", isDeleted, OracleMappingType.Byte);
                return await connection.QueryAsync<Reference>(query, parameters);
            }
        }
    }
}