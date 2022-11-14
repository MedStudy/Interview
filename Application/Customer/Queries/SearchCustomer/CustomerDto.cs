using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.TodoLists.Queries.GetTodos
{
  public class CustomerDto : IMapFrom<Customer>
  {
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Year { get; set; }

  }
}
