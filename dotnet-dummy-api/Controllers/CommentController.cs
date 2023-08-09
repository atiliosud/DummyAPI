using dotnet_dummy.business.Models;
using dotnet_dummy.business.Models.Base;
using dotnet_dummy.business.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_dummy.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private ICommentService _commentService;

        public CommentController(ICommentService userService)
        {
            _commentService = userService;
        }

        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(BaseResult<List<CommentModel>>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> GetList(int page = 0, int limit = 20, bool own = false)
        {
            try
            {
                var result = _commentService
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
        [ProducesResponseType(200, Type = typeof(BaseResult<List<CommentModel>>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> GetListByUser(string userId, int page = 0, int limit = 20, bool own = false)
        {
            try
            {
                var result = _commentService
                                .GetListByUser(userId,
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

        [HttpGet("GetListByPost")]
        [ProducesResponseType(200, Type = typeof(BaseResult<List<CommentModel>>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> GetListByPost(string postId, int page = 0, int limit = 20, bool own = false)
        {
            try
            {
                var result = _commentService
                                .GetListByPost(postId,
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
        [ProducesResponseType(200, Type = typeof(BaseResult<CommentModel>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var result = _commentService
                                .GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Create")]
        [ProducesResponseType(200, Type = typeof(BaseResult<CommentModelCreate>))]
        [ProducesResponseType(400, Type = typeof(BaseResult<object>))]
        public async Task<IActionResult> Create(CommentModelCreate comment)
        {
            try
            {
                var result = _commentService
                                .Create(comment);

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
                var result = _commentService
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
