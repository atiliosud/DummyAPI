using dotnet_dummy.business.Models;
using dotnet_dummy.business.Models.Base;
using dotnet_dummy.business.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_dummy.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private IPostService _postService;

        public PostController(IPostService userService)
        {
            _postService = userService;
        }

        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(BaseResult<List<PostModel>>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> GetList(int page = 0, int limit = 20, bool own = false)
        {
            try
            {
                var result = _postService
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

        [HttpGet("GetListByUser")]
        [ProducesResponseType(200, Type = typeof(BaseResult<List<PostModel>>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> GetListByUser(string userId, int page = 0, int limit = 20)
        {
            try
            {
                var result = _postService
                                .GetListByUser(userId,
                                               page,
                                               limit);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetListByTag")]
        [ProducesResponseType(200, Type = typeof(BaseResult<List<PostModel>>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> GetListByTag(string tagId, int page = 0, int limit = 20, bool own = false)
        {
            try
            {
                var result = _postService
                                .GetListByTag(tagId,
                                              page,
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
        [ProducesResponseType(200, Type = typeof(BaseResult<PostModel>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var result = _postService
                                .GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Create")]
        [ProducesResponseType(200, Type = typeof(BaseResult<PostModelCreate>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> Create(PostModelCreate post)
        {
            try
            {
                var result = _postService
                                .Create(post);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        [ProducesResponseType(200, Type = typeof(BaseResult<PostModelUpdate>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> Update(PostModelUpdate post)
        {
            try
            {
                var result = _postService
                                .Update(post, post.Id);

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
                var result = _postService
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
