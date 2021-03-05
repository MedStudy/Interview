using System;
using FullStackDevExercise.Models;
using FullStackDevExercise.Responses.Schdules;
using MediatR;

namespace FullStackDevExercise.Requests.Schdules
{
  public class UpdateScheduleRequest : IRequest<UpdateScheduleResponse> {

    public long Id { get; set; }
    public string NewAppointmentTime { get; set; }

  }
}
