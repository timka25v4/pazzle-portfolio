using ChatBot.Dtos;
using ChatBot.Repositories.Interfaces;
using Telegram.Bot;

namespace ChatBot.Commands
{
	public class ClearCommand : IBotCommand
	{
		private readonly IChatModelRepository _chatModelRepository;
		private readonly ILogger<ClearCommand> _logger;

		public ClearCommand(IChatModelRepository chatModelRepository, ILogger<ClearCommand> logger)
		{
			_chatModelRepository = chatModelRepository;
			_logger = logger;
		}

		public string Trigger => "/clear";

		string IBotCommand.Trigger => throw new NotImplementedException();

		public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
		{
			_logger.LogInformation("Начало выполнения команды /clear для ChatId: {ChatId}", chatId);

			try
			{
				await _chatModelRepository.ClearHistoryAsync(chatId);

				var message = "История очищена\n\n" +
							  "Начните новый диалог — я буду отвечать с чистого листа.";

				await bot.SendTextMessageAsync(chatId, message);

				_logger.LogInformation("Команда /clear успешно выполнена для {ChatId}. История очищена.", chatId);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка при выполнении /clear для {ChatId}", chatId);
				await bot.SendTextMessageAsync(chatId, "Произошла ошибка при очистке истории.");
			}
		}

		Task IBotCommand.ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
		{
			throw new NotImplementedException();
		}
	}
}