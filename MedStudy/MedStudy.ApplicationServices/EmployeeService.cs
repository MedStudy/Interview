using MedStudy.Interfaces;
using MedStudy.Model;
using MedStudy.DataAccess;
using Newtonsoft.Json;
using MedStudy.Common;

namespace MedStudy.ApplicationServices
{
    public class EmployeeService : IEmployee
    {
        Employee _employee;
        public EmployeeService()
        {
            _employee = new Employee();
        }
        public async Task<List<EmployeeResponseModel>> SearchEmployee(EmployeeRequestModel employeeRequestModel)
        {
            var result =  await Task.Run(() => { return _employee.SearchEmployee(employeeRequestModel) ;});

            string JsonResult = Utility.JSonConverter(result);
            return JsonConvert.DeserializeObject<List<EmployeeResponseModel>>(JsonResult);
        }

        public async Task<List<StateModel>> GetStates()
        {
            var result = await Task.Run(() => { return _employee.GetStates(); });

            string JsonResult = Utility.JSonConverter(result);
            return JsonConvert.DeserializeObject<List<StateModel>>(JsonResult);
        }


    }
}
