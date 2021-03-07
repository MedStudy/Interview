using System;
using System.Collections.Generic;
using FullStackDevExercise.Models;
using FullStackDevExercise.Responses.Vets;
using MediatR;

namespace FullStackDevExercise.Requests.Vets
{
  /// <summary>
  /// Models a request to get a list of vets per availability
  /// </summary>
  public class ListVetAvailabilityRequest : IRequest<ListVetAvailabilityResponse>
  {
    public ListVetAvailabilityRequest(string date)
    {
      Date = date;
    }
    public string Date { get; set; }
  }
}
