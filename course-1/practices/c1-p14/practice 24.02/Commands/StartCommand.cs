using ChatBot.Dtos;
using Telegram.Bot;
namespace ChatBot.Commands
{
	public class StartCommand : IBotCommand
	{
		private readonly ILogger<StartCommand> _logger;

		public StartCommand(ILogger<StartCommand> logger)
		{
			_logger = logger;
		}

		public string Trigger => "/start";
		public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
		{
			_logger.LogInformation("Команда /start выполнена для чата {ChatId}", chatId);

			try
			{
				var welcomeMessage = "Привет! Я OpenAI-бот. Отправь сообщение -- я передам его сторонней модели и верну ответ.\n/help для списка команд.";

				await bot.SendTextMessageAsync(chatId, welcomeMessage);

				_logger.LogInformation("Команда /start успешно выполнена для чата {ChatId}. Приветствие отправлено.", chatId);
			}
			catch (Exception ex)
			{ 
				_logger.LogError(ex, "Ошибка при выполнении команды /start для чата {ChatId}", chatId);
			}
		}

	}
}