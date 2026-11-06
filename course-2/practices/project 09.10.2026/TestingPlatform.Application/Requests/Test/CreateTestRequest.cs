using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.Application.Requests.Test;

public class CreateTestRequest
{
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
}