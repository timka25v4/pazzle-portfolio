using ChatBot.Dtos;
using ChatBot.Repositories.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBot.Commands;

public class QuoteCommand : IBotCommand
{
	private readonly IChatModelRepository _chatModelRepository;
	private readonly ILogger<QuoteCommand> _logger;

	public QuoteCommand(IChatModelRepository chatModelRepository, ILogger<QuoteCommand> logger)
	{
		_chatModelRepository = chatModelRepository;
		_logger = logger;
	}

	public string Trigger => "/quote";

	string IBotCommand.Trigger => throw new NotImplementedException();

	public async Task ExecuteAsync(Update update, ITelegramBotClient bot, long chatId)
	{
		await bot.SendChatActionAsync(chatId, Telegram.Bot.Types.Enums.ChatAction.Typing);
		_logger.LogInformation("Выполнение команды /quote для ChatId: {chatId}", chatId);

		try
		{
			string prompt = "Напиши одну вдохновляющую цитату известного человека с указанием автора.";
			string quote = await _chatModelRepository.GetAiResponseAsync(chatId, prompt);

			await bot.SendTextMessageAsync(chatId, quote);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Ошибка при выполнении /quote для {chatId}", chatId);
			await bot.SendTextMessageAsync(chatId, "Не удалось найти подходящую цитату.");
		}
	}

	Task IBotCommand.ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
	{
		throw new NotImplementedException();
	}
}