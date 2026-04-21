using ChatBot.Dtos;
using ChatBot.Repositories.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBot.Commands;

public class JokeCommand : IBotCommand
{
	private readonly IChatModelRepository _chatModelRepository;
	private readonly ILogger<JokeCommand> _logger;

	public JokeCommand(IChatModelRepository chatModelRepository, ILogger<JokeCommand> logger)
	{
		_chatModelRepository = chatModelRepository;
		_logger = logger;
	}

	public string Trigger => "/joke";

	string IBotCommand.Trigger => throw new NotImplementedException();

	public async Task ExecuteAsync(Update update, ITelegramBotClient bot, long chatId)
	{
		await bot.SendChatActionAsync(chatId, Telegram.Bot.Types.Enums.ChatAction.Typing);
		_logger.LogInformation("Выполнение команды /joke для ChatId: {chatId}", chatId);

		try
		{
			string prompt = "Расскажи одну короткую и смешную шутку на русском языке.";
			string joke = await _chatModelRepository.GetAiResponseAsync(chatId, prompt);

			await bot.SendTextMessageAsync(chatId, joke);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Ошибка при выполнении /joke для {chatId}", chatId);
			await bot.SendTextMessageAsync(chatId, "Прости, сегодня с юмором туго. Попробуй позже.");
		}
	}

	Task IBotCommand.ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
	{
		throw new NotImplementedException();
	}
}