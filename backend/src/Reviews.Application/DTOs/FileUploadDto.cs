using Microsoft.AspNetCore.Http;

namespace Reviews.Application.DTOs;

public class FileUploadDto
{
    public IFormFile File { get; set; }
}