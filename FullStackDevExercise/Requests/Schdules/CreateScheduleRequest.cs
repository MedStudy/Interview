using System;
using System.ComponentModel.DataAnnotations;
using FullStackDevExercise.Responses.Schdules;
using MediatR;

namespace FullStackDevExercise.Requests.Schdules
{
  public class CreateScheduleRequest : IRequest<CreateScheduleResponse>
  {
    [Range(1, long.MaxValue)]
    public long OwnerId { get; set; }

    [Range(1, long.MaxValue)]
    public long PetId { get; set; }

    [Range(1, long.MaxValue)]
    public long VetId { get; set; }

    [Required, MaxLength(50)]
    public string AppointmentTime { get; set; }
  }
}
