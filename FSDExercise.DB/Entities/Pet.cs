namespace FSDExercise.DB.Entities
{
  public class Pet //: BaseEntity
  {
    public int id { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public int age { get; set; }
    public int owner_id { get; set; }
    //public int Ownerid { get; set; }
    public virtual Owner Owner { get; set; }
  }
  
}
