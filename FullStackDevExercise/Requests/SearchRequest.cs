using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace FullStackDevExercise.Requests
{
  public class SearchRequest<T> : IRequest<T>
  {
  }
}
