using FullStackDevExercise.Common.Interfaces;
using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Services.Interfaces;
using FullStackDevExercise.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FullStackDevExercise.Controllers
{
  [ApiController]
  [Route("api/appointments")]
  public class AppointmentController : Controller
  {
    private readonly IAppointmentservice _appointmentService;
    private readonly IMapperExtension _mapper;
    public AppointmentController(IAppointmentservice appointmentservice, IMapperExtension mapper)
    {
      _appointmentService = appointmentservice;
      _mapper = mapper; 
    }

    [HttpPost("CreateAppointment")]
    public async Task<ActionResult<AppointmentViewModel>> Post(AppointmentViewModel createAppointment)
    {
      AppointmentModel appointment = _mapper.MapObjectTo<AppointmentModel>(createAppointment);
      bool isCreated = await _appointmentService.CreateAppointmentAsync(appointment);
      return isCreated ? Created(Url.Action(nameof(GetAppointmentById), new { id = appointment.Id }), _mapper.MapObjectTo<AppointmentViewModel>(appointment)) as ActionResult : BadRequest() as ActionResult;
    }

    [HttpGet("GetAppointmentById/{id}")]
    public async Task<ActionResult<AppointmentViewModel>> GetAppointmentById(long id)
    {
        AppointmentModel result = await _appointmentService.GetAppointmentById(id);
        return result != null ? Ok(_mapper.MapObjectTo<AppointmentViewModel>(result)) as ActionResult : NotFound();
    }

    [HttpGet("GetAppointmentByDate/{year}/{month}/{date}")]
    public ActionResult<AppointmentViewModel> GetAppointmentsByDate(int year, int month, int date) =>
       Ok(_mapper.MapListTo<AppointmentViewModel, AppointmentModel>(_appointmentService.GetByDate(year, month, date)));

    [HttpDelete("DeleteAppointment/{id}")]
    public async Task<ActionResult> DeleteAppointment(long id) => Ok(await _appointmentService.DeleteAsync(id));

  }
}
