using FSDExercise.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDExercise.DB.Actions
{
    public interface IDBOperations
    {
      Task<Pet> GetPetAsync(int id);
      Task<IEnumerable<Pet>> GetAllPetsAsync();
      Task AddPetAsync(Pet pet);
      Task UpdatePetAsync(Pet pet);
      Task DeletePet(Pet pet);
      Task DeleteOwner(Owner owner);
      Task AddAppointmentAsync(Appointment appointment);
      Task DeleteAppointment(Appointment appointment);
      Task<IEnumerable<Appointment>> GetAppointmentsByPetAsync(int ownerId, int petId);
      Task<Appointment> GetAppointmentAsync(int appointmentId);
      Task<IEnumerable<Appointment>> GetAllAppointmentsByOwnerAsync(int ownerId);
      Task CancelAppointmentAsync(int appointmentId);
      Task UpdateAppointmentAsync(Appointment appointment);      
    }
}
