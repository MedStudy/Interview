using FullStackDevExercise.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Services.Implementation
{
  public class AppointmentService: IAppointmentService
  {
    /// <summary>
    /// Logger for logging events.
    /// </summary>
    private readonly ILogger<AppointmentService> Logger;

    private readonly MedStudyContext Context;
    private readonly IOwnerService ownerService;
    private readonly IPetService petService;

    public AppointmentService(MedStudyContext context, ILogger<AppointmentService> logger, IOwnerService ownerService, IPetService petService)
    {
      this.Context = context;
      this.Logger = logger;
      this.ownerService = ownerService;
      this.petService = petService;
    }

    public async Task<Appointment> Add(Appointment appointment)
    {
      if (appointment.Id != 0)
      {
        throw new InvalidDataException("To add an Appointment, Id should be set to zero.");
      }

      // New Appointment adds to Owner and pets table as well.
      Owner owner = new Owner { Id = 0, First_Name = appointment.Client_Name, Last_Name = ""};
      var result = await this.ownerService.Add(owner);

      Pet pet = new Pet { Id = 0, Age = appointment.Age, Name = appointment.Client_Name, Owner_Id = result.Id, Type = appointment.Pet_Type};
      await this.petService.Add(pet);

      this.Context.Add<Appointment>(appointment); // adds the Appointment to the DbSet in memory

      this.Context.SaveChanges(); // commits the changes to the database
      var response = await Task.FromResult(this.Context.Appointments.OrderByDescending(appoint => appoint.Id).First());

      return response;
    }

    public async Task<Appointment> Update(int id, Appointment appointment)
    {
      var response = await Task.FromResult(this.Context.Appointments.Single(user => user.Id == id));
      if (response is null)
      {
        throw new Exception("Specified Appointment does not exist.");
      }
      else
      {
        response.Pet_Type = appointment.Pet_Type;
        response.Client_Name = appointment.Client_Name;
        response.Age = appointment.Age;
        response.Appointment_Date = appointment.Appointment_Date;

        this.Context.SaveChanges(); // commits the changes to the database
      }
      return response;
    }

    public async Task Delete(int id)
    {
      var response = await Task.FromResult(this.Context.Appointments.Single(user => user.Id == id));
      if (response is null)
      {
        throw new Exception("Specified Appointment does not exist.");
      }
      else
      {
        this.Context.Appointments.Remove(response);
        this.Context.SaveChanges(); // commits the changes to the database
      }
    }

    public async Task<Appointment> GetById(int id)
    {
      var response = await Task.FromResult(this.Context.Appointments.Single(user => user.Id == id)).ConfigureAwait(false);
      if (response is null)
      {
        throw new Exception("Specified Appointment does not exist.");
      }
      return response;
    }

    public async Task<IEnumerable<Appointment>> GetAll()
    {
      var response = await (from Appointments in Context.Appointments
                            select Appointments).ToListAsync().ConfigureAwait(false);
      return response;
    }
  }
}
