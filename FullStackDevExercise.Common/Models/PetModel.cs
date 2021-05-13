using System;
using System.Collections.Generic;
using System.Text;

namespace FullStackDevExercise.Common.Models
{
      public class PetModel : ModelBase
      {
          public long OwnerId { get; set; }
          public string Type { get; set; }
          public string Name { get; set; }
          public int Age { get; set; }
    }
}
