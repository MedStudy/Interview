using AutoMapper;
using FullStackDevExercise.Data;
using FullStackDevExercise.Data.Entities;
using FullStackDevExercise.Services.Contracts;
using FullStackDevExercise.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FullStackDevExercise.Services.Services
{
  public class OwnerService : IOwnerService
  {
    private readonly IOwnerRepository ownerRepository;
    private readonly IMapper mapper;
    public OwnerService(IOwnerRepository OwnerRepository, IMapper Mapper)
    {
      ownerRepository = OwnerRepository;
      mapper = Mapper;
    }

    public List<OwnerDTO> GetAll()
    {
      var data = ownerRepository.GetAll().ToList();
      var dtoData = mapper.Map<List<OwnerDTO>>(data);
      return dtoData;
    }

    public OwnerDTO GetById(int Id)
    {
      var data = ownerRepository.GetById(Id);
      var dtoData = mapper.Map<OwnerDTO>(data);
      return dtoData;
    }

    public int Save(OwnerDTO OwnerDTO)
    {
      var entity = mapper.Map<Owner>(OwnerDTO);
      return ownerRepository.Save(entity); 
    }

    public void Delete(int Id)
    {
      ownerRepository.Delete(Id);
    }
  }
}
