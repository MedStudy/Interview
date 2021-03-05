using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace FullStackDevExercise.Requests
{
  public abstract class GetRequest<T> : IRequest<T>
  {
    protected GetRequest( long id)
    {
      Id = id;
    }

    public long Id { get; }
  }
}
