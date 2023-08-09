using dotnet_dummy.business.Models.Base;
using dotnet_dummy.business.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_dummy.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        private ITagService _tagService;

        public TagController(ITagService userService)
        {
            _tagService = userService;
        }

        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(BaseResult<string[]>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> GetList(int page = 0, int limit = 20, bool own = false)
        {
            try
            {
                var result = _tagService
                                .GetList(page,
                                         limit);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
