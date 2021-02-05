using FullStackDevExercise.DAL.Entity;

namespace FullStackDevExercise.ViewModels.Mapper
{
  public class PetMapper : BaseMapper<PetEntity, PetViewModel>, IPetMapper
  {
    private long _ownerId = 0;

    public override PetEntity Decode(PetViewModel data) => new PetEntity
    {
      id = data.Id,
      age = data.Age,
      name = data.Name,
      owner_id = _ownerId,
      type = data.Type
    };

    public override PetViewModel Encode(PetEntity data) => new PetViewModel
    {
      Id = data.id,
      OwnerId = _ownerId,
      Age = data.age,
      Name = data.name,
      Type = data.type
    };

    public IPetMapper ForOwnerId(long id)
    {
      _ownerId = id;
      return this;
    }
  }

  public interface IPetMapper : IMapper<PetEntity, PetViewModel>
  {
    IPetMapper ForOwnerId(long id);
  }
}
