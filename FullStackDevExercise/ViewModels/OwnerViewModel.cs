using System.ComponentModel.DataAnnotations;

namespace FullStackDevExercise.ViewModels
{
  public class OwnerViewModel
  {
    public long? Id { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; }

    [Required, MaxLength(50)]
    public string LastName { get; set; }
  }
}
