using System.Collections.Generic;

namespace FullStackDevExercise.DAL.Entity
{
  public class OwnerEntity : BaseEntity, IEntity
  {
    public string first_name { get; set; }
    public string last_name { get; set; }

    public virtual ICollection<PetEntity> Pets { get; set; }
  }
}
