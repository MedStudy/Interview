using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FullStackDevExercise.Data.Entities
{
  public class Owner : BaseEntity
  {
    //public int id { get; set; }
    //[Column("first_name")]
    public string first_name { get; set; }
    //[Column("last_name")]
    public string last_name { get; set; }
  }
}
