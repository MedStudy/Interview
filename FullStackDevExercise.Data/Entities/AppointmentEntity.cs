using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FullStackDevExercise.Data.Entities
{
  [Table("appointments")]
  public class AppointmentEntity : EntityBase
  {
      [Column("pet_id")]
      public long PetId { get; set; }
      [Column("slot_from")]
      public DateTime SlotFrom { get; set; }
      [Column("slot_to")]
      public DateTime SlotTo { get; set; }
      [Column("summary")]
      public string Summary { get; set; }

      [ForeignKey("PetId")]
      public PetEntity Pet { get; set; }
  }
}
