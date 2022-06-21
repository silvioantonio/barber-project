using MeuBarbeiro.API.Data.ValueObjects;
using MeuBarbeiro.API.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace MeuBarbeiro.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            if (id > 0)
            {
                var user = await _userService.FindById(id);
                return Ok(user);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserVO>>> FindAll()
        {
            var response = await _userService.FindAll();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<UserVO>> Create([FromBody] UserVO userVO)
        {
            if (userVO == null)
            {
                return BadRequest();
            }

            try
            {
                var user = await _userService.Create(userVO);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<UserVO>> Update([FromBody] UserVO userVO)
        {
            if (userVO == null)
            {
                return BadRequest();
            }

            try
            {
                var user = await _userService.Update(userVO);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            if (id > 0)
            {
                await _userService.Delete(id);
                return Ok();
            }

            return BadRequest();
        }
    }
}
