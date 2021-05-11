using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.ViewModels
{
  public class PetViewModel
  {
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
  }
}
