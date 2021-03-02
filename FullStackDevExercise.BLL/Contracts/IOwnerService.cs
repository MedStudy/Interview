using FullStackDevExercise.Services.DTOs;
using System.Collections.Generic;

namespace FullStackDevExercise.Services.Contracts
{
  public interface IOwnerService
  {
    List<OwnerDTO> GetAll();
    OwnerDTO GetById(int Id);
    int Save(OwnerDTO OwnerDTO);
    void Delete(int Id);
  }
}
