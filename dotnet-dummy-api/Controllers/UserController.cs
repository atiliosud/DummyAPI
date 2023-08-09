using dotnet_dummy.business.Models;
using dotnet_dummy.business.Models.Base;
using dotnet_dummy.business.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_dummy.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(BaseResult<List<UserModel>>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> GetList(int page = 0, int limit = 20, bool own = false)
        {
            try
            {
                var result = _userService
                                .GetList(page,
                                         limit,
                                         own ? "&created=1" : string.Empty);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetById")]
        [ProducesResponseType(200, Type = typeof(BaseResult<UserModel>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var result = _userService
                                .GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Create")]
        [ProducesResponseType(200, Type = typeof(BaseResult<UserModel>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> Create(UserModel user)
        {
            try
            {
                var result = _userService
                                .Create(user);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        [ProducesResponseType(200, Type = typeof(BaseResult<UserModel>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> Update(UserModel user)
        {
            try
            {
                var result = _userService
                                .Update(user, user.Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(200, Type = typeof(BaseResult<string>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = _userService
                                .Delete(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
