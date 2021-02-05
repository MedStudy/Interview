using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackDevExercise.DAL.Entity
{
  public class AppointmentEntity : BaseEntity, IEntity
  {
    public long pet_id { get; set; }
    public string slot_from { get; set; }
    public string slot_to { get; set; }

    public long? owner_id { get; set; }

    public string notes { get; set; }

    public string pet_type { get; set; }
    public string pet_name { get; set; }
    public int pet_age { get; set; }

    public string owner_first_name { get; set; }
    public string owner_last_name { get; set; }

    [ForeignKey("pet_id")]
    public virtual PetEntity Pet { get; set; }
  }
}
