using MedStudy.Model;
using System.Data;
using System.Data.SqlClient;

namespace MedStudy.DataAccess
{
    public class Employee 
    {
        public DataTable SearchEmployee(EmployeeRequestModel employeeRequestModel)
        {
            SqlParameter param = null;
            List<SqlParameter> paramList = new List<SqlParameter>();    

            param = new SqlParameter("@FirstName", employeeRequestModel.FirstName); paramList.Add(param);
            param = new SqlParameter("@LastName", employeeRequestModel.LastName); paramList.Add(param);
            param = new SqlParameter("@State", employeeRequestModel.State); paramList.Add(param);
            param = new SqlParameter("@Year", employeeRequestModel.Year); paramList.Add(param);

            DataTable dt = SQLServerDB.ExecProcDt("PorcGetEmployeeDetails", paramList); 
            return dt;
        }

        public DataTable GetStates()
        {
            DataTable dt = SQLServerDB.ExecProcDt("ProcGetStates");
            return dt;
        }
    }
}
