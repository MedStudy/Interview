using System;
using FullStackDevExercise.Models;
using FullStackDevExercise.Responses.Schdules;
using MediatR;

namespace FullStackDevExercise.Requests.Schdules
{
  public class CreateScheduleRequest : IRequest<CreateScheduleResponse>
  {
    public OwnerModel Owner { get; set; }
    public PetModel Pet { get; set; }

    public VetModel Vet { get; set; }

    public DateTime AppointmentTime { get; set; }
  }
}
