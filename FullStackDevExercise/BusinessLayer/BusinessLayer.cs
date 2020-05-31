using FullStackDevExercise.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackDevExercise.Data; 

namespace FullStackDevExercise.Business
{
  public class BusinessLayer
  {
    DataLayer dataLayer;
    public BusinessLayer()
    {
      dataLayer = new DataLayer();
    }
    public List<Owner> GetOwners(int id)
    {
      return dataLayer.GetOwners(id);
    }
    public int AddUpdateOwner(Owner owner)
    {
      return dataLayer.AddUpdateOwner(owner);
    }
    public List<Pet> GetPets(int id)
    {
      return dataLayer.GetPets(id);
    }
    public int AddUpdatePet(Pet pet)
    {
      return dataLayer.AddUpdatePet(pet);
    }
    public List<Appointment> GetAppointments(int id)
    {
      return dataLayer.GetAppointments(id);
    }
    public int AddAppointment(Appointment appointment)
    {
      int ownerId = AddUpdateOwner(appointment.owner);
      appointment.owner.Id = ownerId;
      appointment.pet.OwnerId = ownerId;
      int petId = AddUpdatePet(appointment.pet);
      appointment.pet.Id = petId;
      return dataLayer.AddAppointment(appointment);
    }
    public int DeletePet(int id)
    {
      return dataLayer.DeletePet(id);
    }
    public int DeleteOwner(int id)
    {
      return dataLayer.DeleteOwner(id);
    }
    public int DeleteAppointment(int id)
    {
      return dataLayer.DeleteAppointment(id);
    }
    public object MarkCompleteAppointment(int id)
    {
      return dataLayer.MarkCompleteAppointment(id);
    }
  }
}
