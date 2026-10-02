using practice.Models;
/// <summary>
/// Студент
/// </summary>
public class Student
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// Номер телефона
	/// </summary>
	public string Phone { get; set; }

	/// <summary>
	/// Ссылка на профиль в ВК
	/// </summary>
	public string VkProfileLink { get; set; }

	/// <summary>
	/// 1:1 к пользователю (обязателен для студента)
	/// </summary>
	public int UserId { get; set; }
	public User User { get; set; }

	public List<Attempt> Attempts { get; set; } = new();
	public List<TestResult> TestResults { get; set; } = new();
}

