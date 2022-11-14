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
  public class CustomerRepository : GenericRepository<Customer>, ICustomerrRepository
  {
    public CustomerRepository(ApplicationDbContext context) : base(context) {

     


    }
    Task<IEnumerable<Customer>> FindAll() {

      var customer = context.Customers.ToList();
      return null;



    }




  }
}
