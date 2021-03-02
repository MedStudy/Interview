using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FullStackDevExercise.Data.Entities
{
  public class Pet : BaseEntity
  {
    //public int id { get; set; }
    public int owner_id { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public int age { get; set; }

    [ForeignKey("owner_id")]
    public virtual Owner Owner { get; set; }
  }
}
