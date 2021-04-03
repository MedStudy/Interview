using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public class owners
  {
    
    public int id { get; set; }

    [MaxLength(50)]
    public string first_name { get; set; }
    [MaxLength(50)]
    public string last_name { get; set; }
  }
}
