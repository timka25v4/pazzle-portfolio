using Microsoft.AspNetCore.Mvc;
using practice.Data;
using practice.Models;

namespace practice.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GroupsController : ControllerBase
	{
		private readonly AppDbContext _db;

		public GroupsController(AppDbContext db)
		{
			_db = db;
		}

		// 1. Получить все группы (GET: api/groups)
		[HttpGet]
		public IActionResult GetGroups()
		{
			var groups = _db.Groups.ToList();
			return Ok(groups);
		}

		// 2. Получить группу по Id (GET: api/groups/5)
		[HttpGet("{id}")]
		public IActionResult GetGroupById(int id)
		{
			var group = _db.Groups.FirstOrDefault(g => g.Id == id);
			if (group == null)
				return NotFound("Группа не найдена"); // 404

			return Ok(group);
		}

		// 3. Создать новую группу (POST: api/groups)
		[HttpPost]
		public IActionResult CreateGroup([FromBody] Group group)
		{
			if (group == null)
				return BadRequest("Некорректные данные"); // 400

			_db.Groups.Add(group);
			_db.SaveChanges();

			return CreatedAtAction(nameof(GetGroupById), new { id = group.Id }, group); // 201
		}

		// 4. Обновить группу (PUT: api/groups/5)
		[HttpPut("{id}")]
		public IActionResult UpdateGroup(int id, [FromBody] Group group)
		{
			// Находим существующую группу в базе данных
			var existingGroup = _db.Groups.FirstOrDefault(g => g.Id == id);
			if (existingGroup == null)
				return NotFound("Группа для обновления не найдена"); // 404

			// Переносим измененные данные из запроса в найденную модель
			existingGroup.Name = group.Name;
			existingGroup.DirectionId = group.DirectionId;
			existingGroup.CourseId = group.CourseId;
			existingGroup.ProjectId = group.ProjectId;

			_db.Groups.Update(existingGroup);
			_db.SaveChanges();

			return NoContent(); // 204
		}

		// 5. Удалить группу (DELETE: api/groups/5)
		[HttpDelete("{id}")]
		public IActionResult DeleteGroup(int id)
		{
			var group = _db.Groups.FirstOrDefault(g => g.Id == id);
			if (group == null)
				return NotFound("Группа для удаления не найдена"); // 404

			_db.Groups.Remove(group);
			_db.SaveChanges();

			return Ok("Группа успешно удалена"); // 200
		}
	}
}
