using System;

namespace FullStackDevExercise.ViewModels
{
  public class AppointmentViewModel
    {
          public long Id { get; set; }
          public long PetId { get; set; }
          public DateTime SlotFrom { get; set; }
          public DateTime SlotTo { get; set; }
          public string Notes { get; set; }
    }
}
