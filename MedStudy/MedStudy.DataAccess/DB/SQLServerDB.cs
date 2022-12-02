using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MedStudy.DataAccess
{

    public static class SQLServerDB
    {
        public static string _dbConnectionString = String.Empty;
        public static int _idbSqlTimeoutSecs = Convert.ToInt32(ConfigurationManager.AppSettings["DBSqlTimeoutSecs"]);
        
        public static SqlConnection GetSQLConnectionString()
        {
            _dbConnectionString = ConfigurationManager.ConnectionStrings["MedStudyDB"].ConnectionString;
            return new SqlConnection(_dbConnectionString);
        }

        public static DataTable ExecProcDt(string sProc, List<SqlParameter> lstParams = null)
        {
            SqlConnection sqlConnection = GetSQLConnectionString();

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = sProc,
                CommandTimeout = _idbSqlTimeoutSecs
            };

            if(lstParams != null)
                foreach(SqlParameter param in lstParams)
                    cmd.Parameters.Add(param);

            SqlDataAdapter adapter = new SqlDataAdapter { SelectCommand = cmd };
            try
            {
                sqlConnection.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return dt;
        }
    }
}
