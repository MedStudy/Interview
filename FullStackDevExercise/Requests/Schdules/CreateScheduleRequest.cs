using System;
using System.ComponentModel.DataAnnotations;
using FullStackDevExercise.Models;
using FullStackDevExercise.Responses.Schdules;
using MediatR;

namespace FullStackDevExercise.Requests.Schdules
{
  public class CreateScheduleRequest : IRequest<CreateScheduleResponse>
  {
    public long OwnerId { get; set; }
    public long PetId { get; set; }

    public long VetId { get; set; }

    [Required, MaxLength(50)]
    public string AppointmentTime { get; set; }
  }
}
