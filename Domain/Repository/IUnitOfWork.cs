using CleanArchitecture.Domain.Entities;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repository
{
  public interface IUnitOfWork  
  {
    ICustomerrRepository Customers{ get; }

    Task CompleteAsync();

  }
}
