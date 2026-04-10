using ChatBot.Dtos;
using Telegram.Bot;

namespace ChatBot.Commands
{
	public class HelpCommand : IBotCommand
	{
		private readonly ILogger<HelpCommand> _logger;

		public HelpCommand(ILogger<HelpCommand> logger)
		{
			_logger = logger;
		}

		public string Trigger => "/help";

		public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
		{
			_logger.LogInformation("Выполнение команды /help для ChatId: {ChatId}", chatId);

			try
			{
				await SendHelpMessage(bot, chatId);

				_logger.LogInformation("Команда /help успешно выполнена для {ChatId}", chatId);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка при выполнении /help");
			}
		}
		private async Task SendHelpMessage(ITelegramBotClient botClient, long chatId)
		{
			string helpText =
				"Доступные команды:\n" +
				"/start - Запустить бота\n" +
				"/stats - Показать статистику\n" +
				"/clear - Очистить историю данных\n" +
				"/help - Показать это сообщение";

			await botClient.SendTextMessageAsync(chatId, helpText);
		}
	}
}