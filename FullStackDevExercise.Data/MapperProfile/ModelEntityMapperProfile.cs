using AutoMapper;
using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Data.Entities;

namespace FullStackDevExercise.Data.MapperProfile
{
  public class ModelEntityMapperProfile : Profile
  {
      public ModelEntityMapperProfile()
      {
          CreateMap<PetModel, PetEntity>();
          CreateMap<PetEntity, PetModel>();

          CreateMap<OwnerModel, OwnerEntity>();
          CreateMap<OwnerEntity, OwnerModel>();

          CreateMap<AppointmentModel, AppointmentEntity>();
          CreateMap<AppointmentEntity, AppointmentModel>();
      }
  }
}
