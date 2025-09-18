using Microsoft.AspNetCore.Mvc;
using Reviews.Application.CommentDirectory.Add;
using Reviews.Application.DTOs;

namespace Reviews.API.Controllers;

[ApiController]
[Route("api/[action]")]
public class CommentsController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CommentDto>> Post(
        [FromServices] AddCommentHandler handler,
        [FromBody] AddCommentRequest request)
    {
        var commentDto = await handler.Handle(request);
        
        return Ok(commentDto);
    }
}