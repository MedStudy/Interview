
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using CleanArchitecture.Application.TodoLists.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
  // [Authorize]
  public class CustomerController : ApiController
  {
    [HttpGet]
    [Route("SearchCustomer")]
    public async Task<ActionResult<CustomersVm>> SearchCustomer([FromQuery] string query)
    {
      SearchCustomerQuery searchquery = JsonConvert.DeserializeObject<SearchCustomerQuery>(query);


      return await Mediator.Send((searchquery));
    }



    [HttpGet]
    [Route("GetCustomer")]
    public async Task<ActionResult<PaginatedList<CustomerDto>>> GetCustomer()
    {
      var query = new SearchCustomersWithPaginationQuery();
      return await Mediator.Send(query);
    }





  }
}
