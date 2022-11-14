
using CleanArchitecture.Application.TodoLists.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
   // [Authorize]
    public class CustomerController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<CustomersVm>> SearchCustomer([FromQuery] SearchCustomerQuery query)
        {
            return await Mediator.Send(query);
        }


    [HttpGet]
    [Route("GetCustomer")]
    public async Task<ActionResult<CustomersVm>> GetCustomer()
    {
      var query = new SearchCustomerQuery();
      return await Mediator.Send(query);
    }





  }
}
