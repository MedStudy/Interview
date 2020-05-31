using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Entities
{
  public class AppointmentSnapshot
  {
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public int PetId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PetName { get; set; }
    public string Type { get; set; }
    public short Age { get; set; }
    public string AppointmentDate { get; set; }
    public bool IsComplete { get; set; }
  }
  public class Appointment
  {
    public int Id { get; set; }
    public string AppointmentDate  { get; set;}
    public bool IsComplete { get; set; }
    public Owner owner { get; set; }
    public Pet pet { get; set; }
  }
  public class Owner
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
  public class Pet
  {
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public short Age { get; set; }
  }
}
