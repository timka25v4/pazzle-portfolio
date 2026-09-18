using Microsoft.AspNetCore.Mvc;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")] // базовый маршрут: /api/answers
public class AnswersController : ControllerBase
{
	[HttpGet]
	public IActionResult GetAllAnswers() => Ok("Список ответов"); // 200

	[HttpGet("{id:int}")]
	public IActionResult GetAnswerById(int id)
	{
		if (id <= 0)
			return BadRequest("Некорректный id"); // 400

		if (id == 1)
			return Ok("Ответ 1"); // 200 (заглушка)

		return NotFound(); // 404
	}

	[HttpPost]
	public IActionResult CreateAnswer()
	{
		// Имитация: создали ответ с id=1
		return Created("/api/answers/1", "Создан ответ с id=1"); // 201 + Location
	}

	[HttpPut("{id:int}")]
	public IActionResult UpdateAnswer(int id)
	{
		if (id <= 0)
			return BadRequest("Некорректный id"); // 400

		// Имитация: если не существует
		if (id != 1)
			return NotFound(); // 404

		// Имитация: обновили
		return NoContent(); // 204
	}

	[HttpDelete("{id:int}")]
	public IActionResult DeleteAnswer(int id)
	{
		if (id <= 0)
			return BadRequest("Некорректный id"); // 400

		if (id != 1)
			return NotFound(); // 404

		return NoContent(); // 204
	}
}
