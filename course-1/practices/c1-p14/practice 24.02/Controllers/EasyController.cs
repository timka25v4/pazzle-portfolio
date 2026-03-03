using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class UpdateController : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> Get()
	{
		return Ok("Hello world!");
	}

	[HttpPost]
	public async Task<IActionResult> Post(string test)
	{
		Console.WriteLine(test);
		return Ok(test);
	}
}