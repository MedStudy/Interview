using System.Collections.Generic;
using System.Linq;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Schdules;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FullStackDevExercise.ViewModels
{
  public class AppointmentViewModel
  {
    public int Status { get; set; }
    public AppointmentModel Model { get; set; }

    public List<string> ErrorMessages { get; set; } = new List<string>();

    public AppointmentViewModel()
    {
    }

    public AppointmentViewModel(AppointmentModel model)
    {
      Model = model;
    }

    public AppointmentViewModel(CreateScheduleRequest createScheduleRequest, ModelStateDictionary keyValuePairs, string message = null)
    {
      if (!string.IsNullOrEmpty(message))
      {
        ErrorMessages.Add(message);
      }

      ErrorMessages.AddRange(keyValuePairs.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
    }
  }
}
