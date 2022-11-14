using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
     

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions
           ) : base(options, operationalStoreOptions)
        {
            
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<TodoList> TodoLists { get; set; }


    public DbSet<Customer> Customers { get; set; }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
               
            }

            var result = await base.SaveChangesAsync(cancellationToken);

          //  await DispatchEvents();

            return result;
        }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
     

   
            base.OnModelCreating(builder);

      builder.Entity<Customer>()
             .HasData(
              new Customer { Id = 1, FirstName = "test", LastName = "test" },
              new Customer { Id = 2, FirstName = "test", LastName = "test" },
              new Customer { Id = 3, FirstName = "test", LastName = "test" },
               new Customer { Id = 4, FirstName = "test", LastName = "test" });
    }

        //private async Task DispatchEvents()
        //{
        //    while (true)
        //    {
        //        var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
        //            .Select(x => x.Entity.DomainEvents)
        //            .SelectMany(x => x)
        //            .Where(domainEvent => !domainEvent.IsPublished)
        //            .FirstOrDefault();
        //        if (domainEventEntity == null) break;

        //        domainEventEntity.IsPublished = true;
                
        //    }
        //}
    }
}
