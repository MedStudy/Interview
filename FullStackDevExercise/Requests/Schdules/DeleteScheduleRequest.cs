using System;
using FullStackDevExercise.Models;
using FullStackDevExercise.Responses.Schdules;
using MediatR;

namespace FullStackDevExercise.Requests.Schdules
{
  public class DeleteScheduleRequest : RemoveRequest<DeleteScheduleResponse>
  {
    public DeleteScheduleRequest(long id): base(id)
    {
    }
  }
}
