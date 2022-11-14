using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.TodoLists.Queries.GetTodos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repository;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination
{
  public class SearchCustomersWithPaginationQuery : IRequest<PaginatedList<CustomerDto>>
  {
    public int ListId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 55;
  }

  public class SearchCustomersWithPaginationQueryHandler : IRequestHandler<SearchCustomersWithPaginationQuery, PaginatedList<CustomerDto>>
  {
    private readonly ICustomerrRepository _customer;
    private readonly IUnitOfWork _unit;
    private readonly IMapper _mapper;

    public SearchCustomersWithPaginationQueryHandler(ICustomerrRepository customer, IUnitOfWork unit, IMapper mapper)
    {
      _customer = customer;
      _mapper = mapper;
      _unit = unit;
    }

    public async Task<PaginatedList<CustomerDto>> Handle(SearchCustomersWithPaginationQuery request, CancellationToken cancellationToken)
    {

      await LoadData();
      var customers = _customer.FindAll()
         // .Where(x => x.Id == request.ListId)
          .OrderBy(x => x.FirstName)
          .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
          .PaginatedListAsync(request.PageNumber, request.PageSize); ;
      return customers.Result;
    }

    private async Task LoadData()
    {
      for (int i = 0; i < 1000; i++)
      {
        Random rd = new Random();
        _customer.Create(new Customer { Id = rd.Next(), FirstName="FirstTest"+i,LastName="LastTest"+i, Year=2010 });
      }
      await _unit.CompleteAsync();

    }
  }
}
