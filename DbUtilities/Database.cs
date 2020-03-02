using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManagement.DbUtilities
{
    public class Database
    {
        protected class procedureCall
        {
            internal String ProcedureName { get; set; }
            private SqlParameter[] ProcedureParams { get; set; }
            
            private static readonly String ConnectionString = "Initial Catalog = CoffeManagement; Data Source = DESKTOP-6SE50ED\\SQLSERVER; User ID = sa; Password = 12345";

            public procedureCall Params(params SqlParameter[] sqlParameters)
            {
                if(sqlParameters != null)
                {
                    ProcedureParams = sqlParameters;
                }
                return this;
            }
            public T Execute<T>() 
            {
                var dataSet = Database.ExecuteDataSetProcedure(ConnectionString, ProcedureName, ProcedureParams);
                if (typeof(T) == typeof(SqlDataReader))
                    return (T)(GetSqlDataReader(dataSet) as Object);
                if (typeof(T) == typeof(DataTable))
                    return (T)(GetDataTable(dataSet) as Object);
                
                return (T)(dataSet as Object);
            }

            private DataTable GetDataTable(DataSet dataSet)
            {
                return dataSet.Tables[0];
            }

            private SqlDataReader GetSqlDataReader(DataSet dataSet)
            {
                return ExecuteSqlDataReader();
            }

            private SqlDataReader ExecuteSqlDataReader()
            {
                var dataAdapter = new SqlDataAdapter();
                using (var mySqlConnection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand(ProcedureName, mySqlConnection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        if (ProcedureParams.Any())
                        {
                            foreach (var sqlParameter in ProcedureParams)
                            {
                                command.Parameters.Add(sqlParameter);
                            }
                        }
                        mySqlConnection.Open();
                        return command.ExecuteReader();
                    }
                }
            }
        }
        private static DataSet ExecuteDataSetProcedure(String connectionString, String procedureName, SqlParameter[] procedureParams)
        {
            var dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter();
            using (var mySqlConnection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(procedureName, mySqlConnection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (procedureParams != null)
                    {
                        if (procedureParams.Any())
                        {
                            foreach (var sqlParameter in procedureParams)
                            {
                                command.Parameters.Add(sqlParameter);
                            }
                        }
                    }
                    mySqlConnection.Open();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dataSet);
                }
            }
            return dataSet;
        }

        protected procedureCall Procedure(String procedureName)
        {
            return new procedureCall
            {
                ProcedureName = procedureName
            };
        }
    }
}
