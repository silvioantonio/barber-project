using MeuBarbeiro.API.Data.ValueObjects;
using MeuBarbeiro.API.Services.Provider;
using Microsoft.AspNetCore.Mvc;

namespace MeuBarbeiro.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            if (id > 0)
            {
                var provider = await _providerService.FindById(id);
                return Ok(provider);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProviderVO>>> FindAll()
        {
            var response = await _providerService.FindAll();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProviderVO providerVO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados invalidos!");
            }

            try
            {
                var provider = await _providerService.Create(providerVO);
                return Ok(provider);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProviderVO>> Update([FromBody] ProviderVO providerVO)
        {
            if (providerVO == null)
            {
                return BadRequest();
            }

            try
            {
                var provider = await _providerService.Update(providerVO);
                return Ok(provider);
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
            return await _providerService.Delete(id) ? Ok() : NotFound();
        }

    }
}
