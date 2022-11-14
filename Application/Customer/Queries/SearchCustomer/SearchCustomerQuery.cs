using AutoMapper;
using AutoMapper.QueryableExtensions;

using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repository;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoLists.Queries.GetTodos
{
  public class SearchCustomerQuery : IRequest<CustomersVm>
  {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Year { get; set; }
  }
  public class SearchCustomerQueryt
  {
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Year { get; set; }
  }

  public class SearchCustomerQueryHandler : IRequestHandler<SearchCustomerQuery, CustomersVm>
  {
    private readonly ICustomerrRepository _customer;
    private readonly IUnitOfWork _unit;
    private readonly IMapper _mapper;
    public SearchCustomerQueryHandler(ICustomerrRepository customer, IUnitOfWork unit,IMapper mapper)
    {
      _customer = customer;
      _mapper = mapper;
      _unit = unit;
    }

    public async Task<CustomersVm> Handle(SearchCustomerQuery request, CancellationToken cancellationToken)
    {


      

      var conditions = PredicateBuilder.New<Customer>();
      if (!String.IsNullOrEmpty(request.FirstName))
      {
        conditions.And(x => x.FirstName.ToUpper().Contains(request.FirstName.ToUpper()));

      }
      if (!String.IsNullOrEmpty(request.LastName))
      {
        conditions.And(x => x.LastName.ToUpper().Contains( request.LastName.ToUpper()));

      }
      if (request.Year != 0)
      {
        conditions.And(x => x.Year == request.Year);

      }
      var customer=_customer.FindByCondition(conditions).ProjectTo<CustomerDto>(_mapper.ConfigurationProvider);
      
      return new CustomersVm {  Customers= customer };
     
    }
  }
}
