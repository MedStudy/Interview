using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repository
{
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    private readonly ApplicationDbContext _context;
  //s  private readonly ILogger _logger;

    public ICustomerrRepository Customers { get; private set; }

    public UnitOfWork(ApplicationDbContext context, ICustomerrRepository customer)
    {
      _context = context;
      //_logger = loggerFactory.CreateLogger("logs");
      Customers = customer;
    }

    public async Task CompleteAsync()
    {
      await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  

}
}
