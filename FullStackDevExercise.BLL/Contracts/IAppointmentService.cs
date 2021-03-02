using FullStackDevExercise.Services.DTOs;
using System.Collections.Generic;

namespace FullStackDevExercise.Services.Contracts
{
  public interface IAppointmentService
  {
    List<AppointmentDTO> GetAll();
    AppointmentDTO GetById(int Id);
    int Save(AppointmentDTO OwnerDTO);
    void Delete(int Id);
  }
}
