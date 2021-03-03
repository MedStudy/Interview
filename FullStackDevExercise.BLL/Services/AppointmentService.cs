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
  public class AppointmentService : IAppointmentService
  {
    private readonly IAppointmentRepository repository;
    private readonly IMapper mapper;
    public AppointmentService(IAppointmentRepository Repository, IMapper Mapper)
    {
      repository = Repository;
      mapper = Mapper;
    }

    public List<AppointmentDTO> GetAll()
    {
      var data = repository.GetAll().ToList();
      var dtoData = mapper.Map<List<AppointmentDTO>>(data);
      return dtoData;
    }

    public List<AppointmentDTO> GetByDate(DateTime date)
    {
      var appointments = repository.GetByDate(date).ToList();
      if (appointments.Count>0)
        return mapper.Map<List<AppointmentDTO>>(appointments);
      return null;
    }


    public AppointmentDTO GetById(int Id)
    {
      var data = repository.GetById(Id);
      var dtoData = mapper.Map<AppointmentDTO>(data);
      return dtoData;
    }

    public int Save(AppointmentDTO dto)
    {
      var entity = mapper.Map<Appointment>(dto);
      return repository.Save(entity);
    }

    public void Delete(int Id)
    {
      repository.Delete(Id);
    }
  }
}
