using ChatBot.Dtos;
using Microsoft.AspNetCore.Mvc;
namespace ChatBot.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UpdateController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] TelegramUpdate update)
		{
			Console.WriteLine(update?.Message?.Text);
			return Ok();
		}
	}
}
