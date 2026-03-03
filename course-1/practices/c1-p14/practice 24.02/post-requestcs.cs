using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
namespace practice_24_02.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EasyController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Update update)
		{
			Console.WriteLine("Hello");
			return Ok();
		}
	}
}

