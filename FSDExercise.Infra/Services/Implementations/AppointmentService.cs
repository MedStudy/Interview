using FSDExercise.Common.Enums;
using FSDExercise.Common.Models;
using FSDExercise.Core.Contracts;
using FSDExercise.DB.Entities;
using FSDExercise.Infra.Services.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSDExercise.Infra.Services.Implementations
{
  public class AppointmentService : IAppointmentService
  {
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly ILogger<AppointmentService> _logger;
    public AppointmentService(IAppointmentRepository appointmentRepository,
      ILogger<AppointmentService> logger)
    {
      _appointmentRepository = appointmentRepository;
      _logger = logger;
    }

    public async Task<Result> RequestAppointment(int ownerId,int petId,AppointmentRequest request)
    {
      Result result = null;
      try
      {
        await _appointmentRepository.Add(new Appointment
        {
          appointee_id = ownerId,
          appointmentdate = request.AppointmentDate,
          end_time = TimeSpan.Parse(request.EndTime),
          start_time = TimeSpan.Parse(request.StartTime),
          pet_id = petId,
          Status = AppointmentStatus.Confirmed.ToString()
          
        });
        result = new Result(true);
      }
      catch (Exception ex)
      {
        result = new Result(false, "Error occured while requesting an appointment");
        _logger.LogError(ex.Message, request);
      }
      return result;
    }

    public async Task<Appointment> GetAppointmentDetails(int id)
    {
      Appointment appointment = null;
      try
      {
        appointment = await _appointmentRepository.Get(id);
        return appointment;
      }
      catch(Exception ex)
      {
        _logger.LogError(ex.Message);
      }
      return appointment;
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointments()
    {
      IEnumerable<Appointment> appointments = null;
      try
      {
        appointments = await _appointmentRepository.GetAll();
        return appointments;
      }
      catch(Exception ex)
      {
        _logger.LogError(ex.Message);
      }
      return appointments;
    }

    public async Task<(Result,Appointment)> UpdateAppointment(int id,AppointmentUpdateRequest request)
    {
      Appointment appointment = null;
      Result result = null;
      try
      {
        appointment = await GetAppointmentDetails(id);
        if (appointment is null)
          return (new Result(false, "Appointment doesn't exists"), appointment);

        appointment.appointmentdate = request.AppointmentDate;
        appointment.start_time = request.StartTime;
        appointment.end_time = request.EndTime;
        await _appointmentRepository.Update(appointment);
        result = new Result(true);
      }
      catch(Exception ex)
      {
        result = new Result(false, "Error occured while updating an appointment");
        _logger.LogError(ex.Message, request);
      }
      return (result, appointment);
    }

    public async Task<Result> DeleteAppointment(int id)
    {
      Result result = null;
      try
      {
        var appointment = await GetAppointmentDetails(id);
        if (appointment is null)
          return new Result(false, $"Appointment with Id : {id}, doesn't exists");

        await _appointmentRepository.Delete(appointment);
        result = new Result(true);
      }
      catch (Exception ex)
      {
        result = new Result(false, "Error occured while deleting an appointment");
        _logger.LogError(ex.Message, id);
      }

      return result;
    }

    public async Task<Result> CancelAppointment(int id)
    {
      Result result = null;
      try
      {
        var appointment = await GetAppointmentDetails(id);
        if (appointment is null)
          return new Result(false, $"Appointment with Id : {id}, doesn't exists");

        appointment.Status = AppointmentStatus.Cancelled.ToString();

        await _appointmentRepository.Update(appointment);
        result = new Result(true);
      }
      catch (Exception ex)
      {
        result = new Result(false, "Error occured while cancelling an appointment");
        _logger.LogError(ex.Message, id);
      }

      return result;
    }
  }
}
