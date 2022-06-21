using MeuBarbeiro.API.Data.ValueObjects;
using MeuBarbeiro.API.Services.Worker;
using Microsoft.AspNetCore.Mvc;

namespace MeuBarbeiro.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            if (id > 0)
            {
                var worker = await _workerService.FindById(id);
                return Ok(worker);
            }

            return BadRequest();
        }

        [HttpGet("findAllByProviderId/{id}")]
        public async Task<ActionResult<IEnumerable<WorkerVO>>> FindAll(long id)
        {
            var response = await _workerService.FindAll(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<WorkerVO>> Create([FromBody] WorkerVO workerVO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var worker = await _workerService.Create(workerVO);
                return Ok(worker);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<WorkerVO>> Update([FromBody] WorkerVO workerVO)
        {
            if (workerVO == null)
            {
                return BadRequest();
            }

            try
            {
                var worker = await _workerService.Update(workerVO);
                return Ok(worker);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                await _workerService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }
    }
}
