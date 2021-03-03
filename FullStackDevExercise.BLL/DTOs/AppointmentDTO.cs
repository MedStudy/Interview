using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FullStackDevExercise.Services.DTOs
{
  public class AppointmentDTO : BaseDTO
  {
    [Range(90, 240)]
    public int SlotFrom { get; set; }
    [Range(90, 240)]
    public int SlotTo { get; set; }
    public string Notes { get; set; }
    [Range(1, int.MaxValue)]
    public int PetId { get; set; }
    [Required]
    public string AppointmentDate { get; set; }

    public PetDTO Pet { get; set; }
    public OwnerDTO Owner { get; set; }


  }
}
