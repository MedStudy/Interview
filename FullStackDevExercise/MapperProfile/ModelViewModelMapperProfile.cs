using AutoMapper;
using FullStackDevExercise.Common.Models;
using FullStackDevExercise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.MapperProfile
{
    public class ModelViewModelMapperProfile : Profile
    {
        public ModelViewModelMapperProfile()
        {
            MapPetModels();
            MapOwnerModels();
            MapAppointmentModels();
        }

        private void MapPetModels()
        {
            CreateMap<PetModel, PetViewModel>();
            CreateMap<PetViewModel, PetModel>();
        }

        private void MapOwnerModels()
        {
            CreateMap<OwnerModel, OwnerViewModel>();
            CreateMap<OwnerViewModel, OwnerModel>();
        }

        private void MapAppointmentModels()
        {
            CreateMap<AppointmentModel, AppointmentViewModel>();
            CreateMap<AppointmentViewModel, AppointmentModel>();
        }
    }
}
