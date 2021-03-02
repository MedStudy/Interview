using AutoMapper;
using FullStackDevExercise.Data.Entities;
using FullStackDevExercise.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Helpers
{
  public class MappingProfile: Profile
  {
    public MappingProfile()
    {
      CreateMap<Owner, OwnerDTO>()
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.first_name))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.last_name))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ReverseMap();

      CreateMap<Appointment, AppointmentDTO>()
              .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
              .ForMember(d => d.Notes, o => o.MapFrom(s => s.notes))
              .ForMember(d => d.PetId, o => o.MapFrom(s => s.pet_id))
              .ForMember(d => d.SlotFrom, o => o.MapFrom(s => s.slot_from))
              .ForMember(d => d.SlotTo, o => o.MapFrom(s => s.slot_to))
              .ForMember(d => d.AppointmentDate, o => o.MapFrom(s => s.appointment_date))
              .ReverseMap();
    }
    

  }
}
