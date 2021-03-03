using FullStackDevExercise.Services.DTOs;
using System;
using System.Collections.Generic;

namespace FullStackDevExercise.Services.Contracts
{
  public interface IAppointmentService
  {
    List<AppointmentDTO> GetAll();
    List<AppointmentDTO> GetByDate(DateTime date);
    AppointmentDTO GetById(int Id);
    int Save(AppointmentDTO OwnerDTO);
    void Delete(int Id);
  }
}
