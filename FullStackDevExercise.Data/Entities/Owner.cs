using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FullStackDevExercise.Data.Entities
{
  public class Owner
  {
    public int id { get; set; }
    [Column("first_name")]
    public string firstName { get; set; }
    [Column("last_name")]
    public string lastName { get; set; }
  }

  public class Pet
  {
    public int id { get; set; }
    //public int owner_id { get; set; }
    //public long owner_id { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public int age { get; set; }

    [ForeignKey("owner_id")]
    public virtual Owner Owner { get; set; }
  }

}
