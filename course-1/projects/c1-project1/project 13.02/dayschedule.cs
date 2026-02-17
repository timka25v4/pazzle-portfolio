using Telegram.Bot;
using Telegram.Bot.Types;
using System.Text;

namespace ScheduleBot.Commands;

public class TodayScheduleCommand : ICommand
{
	protected readonly IScheduleRepository _scheduleRepository;

	public TodayScheduleCommand(IScheduleRepository scheduleRepository)
	{
		_scheduleRepository = scheduleRepository;
	}

	public async Task ExecuteAsync(Update update, ITelegramBotClient botClient, CancellationToken ct)
	{
		var chatId = update.Message!.Chat.Id;

		var schedule = _scheduleRepository.Load();

		string today = DateTime.Now.DayOfWeek.ToString();

		if (schedule.Groups == null || !schedule.Groups.Any())
		{
			await botClient.SendTextMessageAsync(chatId, "Список групп пуст.", cancellationToken: ct);
			return;
		}

		var lines = new List<string> { $"Расписание на сегодня для всех групп: " };

		foreach (var group in schedule.Groups)
		{
			lines.Add($"Группа: {group.Group}");

			var daySchedule = group.Days.FirstOrDefault(d =>
				string.Equals(d.Day, today, StringComparison.OrdinalIgnoreCase));

			if (daySchedule == null || daySchedule.Lessons == null || daySchedule.Lessons.Count == 0)
			{
				lines.Add("Уроков нет");
			}
			else
			{
				lines.AddRange(daySchedule.Lessons.Select((l, i) =>
					$"  {i + 1}. {l.Time} -- {l.Subject} {(string.IsNullOrEmpty(l.Teacher) ? "" : "(" + l.Teacher + ")")}"));
			}
			lines.Add("");
		}

		await botClient.SendTextMessageAsync(
			chatId,
			string.Join('\n', lines),
			cancellationToken: ct);
	}
}