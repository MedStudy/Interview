using FullStackDevExercise.Common.Interfaces;
using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Data.Entities;
using FullStackDevExercise.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FullStackDevExercise.Data.Repository
{
  public class AppointmentRepository : BaseRepository<AppointmentEntity, AppointmentModel>, IAppointmentRepository
  {
      public AppointmentRepository(DoLittleDbContext context, IMapperExtension mapper) : base(context, mapper)
      {


      }

      public List<AppointmentModel> GetByDate(int year, int month, int date)
      {
          var dbSet =  _dbSet.AsQueryable<AppointmentEntity>();
          var appointmentEntity = dbSet.Where(x => x.SlotFrom.Day == date && x.SlotFrom.Month == month && x.SlotFrom.Year == year).ToList();
          return _mapper.MapListTo<AppointmentModel, AppointmentEntity>(appointmentEntity);
      }
  }
}
