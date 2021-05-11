using FullStackDevExercise.Common.Interfaces;
using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Services.Interfaces;
using FullStackDevExercise.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace FullStackDevExercise.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapperExtension _mapper;

        public OwnerController(IOwnerService ownerService, IMapperExtension mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }

        [HttpGet("GetAllOwners")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _ownerService.GetOwnerListAsync());
        }

        [HttpGet("GetOwnerById/{id}")]
        public async Task<ActionResult<OwnerViewModel>> GetOwnerById(long id)
        {
             var owner = await _ownerService.GetOwnerById(id);
             if (owner == null) return NotFound();
             return Ok(owner);
        }

        [HttpPost("CreateOwner")]
        public async Task<ActionResult<OwnerViewModel>> Post(OwnerViewModel createOwner)
        {
            OwnerModel owner = _mapper.MapObjectTo<OwnerModel>(createOwner);
            bool isCreated = await _ownerService.CreateOwnerAsync(owner);
            return isCreated ? Created(Url.Action(nameof(GetOwnerById), new { id = owner.Id }), _mapper.MapObjectTo<OwnerViewModel>(owner)) as ActionResult : BadRequest() as ActionResult;
        }

        [HttpPut("UpdateOwner/{id}")]
        public async Task<ActionResult<OwnerModel>> UpdateOwnerAsync(long id, OwnerViewModel updateOwner)
        {
            OwnerModel owner = _mapper.MapObjectTo<OwnerModel>(updateOwner);
            bool isSaved = await _ownerService.UpdateOwnerAsync(id, owner);
            if (!isSaved) return NotFound();
            return Ok(isSaved);
        }

        [HttpDelete("DeleteOwner/{id}")]
        public async Task<ActionResult> DeleteOwnerAsync(long id)
        {
            bool isDeleted = await _ownerService.DeleteOwnerAsync(id);
            return isDeleted ? Ok() : StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
