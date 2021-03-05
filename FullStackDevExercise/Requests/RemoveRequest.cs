using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace FullStackDevExercise.Requests
{
  public abstract class RemoveRequest<T> : IRequest<T>
  {
    protected RemoveRequest(long id)
    {
      Id = id;
    }

    public long Id { get; }
  }
}
