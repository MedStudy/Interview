using Microsoft.AspNetCore.Mvc;
using MedStudy.Model;
using MedStudy.Interfaces;

namespace MedStudy.Apis.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpPost]
        [Route("SearchEmployee")]
        public async Task<IActionResult> SearchEmployee([FromBody]EmployeeRequestModel request)
        {
            var response = await _employee.SearchEmployee(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetStates")]
        public async Task<IActionResult> GetStates()
        {
            var response = await _employee.GetStates();
            return Ok(response);
        }


    }
}
