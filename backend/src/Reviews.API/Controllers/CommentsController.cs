using Microsoft.AspNetCore.Mvc;
using Reviews.Application.AttachmentDirectory.Add;
using Reviews.Application.Attachments;
using Reviews.Application.CommentDirectory.Add;
using Reviews.Application.CommentDirectory.Delete;
using Reviews.Application.CommentDirectory.Get;
using Reviews.Application.DTOs;

namespace Reviews.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
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
    
    /// <summary>
    /// Upload attachment for comment.
    /// </summary>
    [HttpPost("{commentId:guid}/attachments")]
    public async Task<IActionResult> UploadAttachment(
        [FromRoute] Guid commentId,
        [FromForm] FileUploadDto fileModel,
        [FromServices] AddAttachmentHandler handler)
    {
        var dto = await handler.Handle(commentId, fileModel.File);
        
        return Ok(dto);
    }
    
    /// <summary>
    /// Delete attachment from comment.
    /// </summary>
    [HttpDelete("{commentId:guid}/attachments/{attachmentId:guid}")]
    public async Task<IActionResult> DeleteAttachment(
        [FromRoute] Guid commentId,
        [FromRoute] Guid attachmentId,
        [FromServices] DeleteAttachmentHandler handler)
    {
        var success = await handler.Handle(commentId, attachmentId);
        
        if (!success)
        {
            return NotFound();
        }
        
        return NoContent();
    }

}