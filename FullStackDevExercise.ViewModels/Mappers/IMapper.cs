using FullStackDevExercise.DAL.Entity;
using System.Collections.Generic;

namespace FullStackDevExercise.ViewModels.Mapper
{
  public interface IMapper<TEntity, TViewModel>
    where TEntity : class, IEntity
    where TViewModel : BaseViewModel
  {
    IEnumerable<TEntity> Decode(IEnumerable<TViewModel> data);
    TEntity Decode(TViewModel data);
    IList<TViewModel> Encode(IList<TEntity> data);
    TViewModel Encode(TEntity data);
  }
}
