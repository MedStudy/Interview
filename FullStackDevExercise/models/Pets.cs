using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public class PetsList : Pets
  {
    public string owner_name { get; set; }
  }
  public class Pets
  {
    public int id { get; set; }
    public int owner_id { get; set; }
    [MaxLength(50)]
    public string type { get; set; }
    [MaxLength(50)]
    public string name { get; set; }
    public int age { get; set; }

  }
}
