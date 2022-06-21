using MeuBarbeiro.API.Data.ValueObjects;
using MeuBarbeiro.API.Services.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace MeuBarbeiro.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AppointmentVO>>> FindAll(long id, [FromQuery] int? page, int? size)
        {
            var response = await _appointmentService.FindAllById(id, page, size);
            return Ok(response);
        }

        [HttpGet("findById/{id}")]
        public async Task<ActionResult<AppointmentVO>> FindById(long id)
        {
            var response = await _appointmentService.FindById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentVO>> Create([FromBody] AppointmentCreateVO appointmentCreateVO)
        {
            if (appointmentCreateVO.ProviderId <= 0 || appointmentCreateVO.UserId <= 0 || appointmentCreateVO.Date < DateTime.Now)
            {
                return BadRequest();
            }

            try
            {
                var response = await _appointmentService.Create(appointmentCreateVO);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _appointmentService.Delete(id);

            return Ok();
        }
    }
}
