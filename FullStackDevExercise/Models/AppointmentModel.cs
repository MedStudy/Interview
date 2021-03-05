namespace FullStackDevExercise.Models
{
  public class AppointmentModel
  {
    public string ScheduledDate { get; set; }

    public virtual OwnerModel Owner { get; set; }
    public virtual PetModel Pet { get; set; }
    public virtual VetModel Vet { get; set; }
  }
}
