using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Events;
using System;
using System.Collections.Generic;

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
