using Microsoft.AspNetCore.Mvc;
using Reviews.Application.CommentDirectory.Add;
using Reviews.Application.CommentDirectory.Delete;
using Reviews.Application.CommentDirectory.Get;
using Reviews.Application.DTOs;

namespace Reviews.API.Controllers;

[ApiController]
[Route("api/[action]")]
public class CommentsController : ControllerBase
{
    /// <summary>
    /// Create a new comment.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<CommentDto>> Create(
        [FromServices] AddCommentHandler handler,
        [FromBody] AddCommentRequest request)
    {
        var commentDto = await handler.Handle(request);
        
        return Ok(commentDto);
    }
    
    /// <summary>
    /// Get comments with pagination.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] int page, 
        [FromQuery] int pageSize,
        [FromServices] GetCommentsHandler handler)
    {
        var comments = await handler.Handle(page, pageSize);
        
        return Ok(comments);
    }

    /// <summary>
    /// Delete a comment by its ID.
    /// </summary>
    [HttpDelete("{commentId:guid}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid commentId,
        [FromServices] DeleteCommentHandler handler)
    {
        var success = await handler.Handle(commentId);
        
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}