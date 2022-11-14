using CleanArchitecture.Domain.Common;
namespace CleanArchitecture.Domain.Entities
{
  public class Customer : AuditableEntity
  {
  //  [Key]
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Year { get; set; }


   
  }
}
