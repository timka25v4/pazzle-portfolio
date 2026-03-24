using Telegram.Bot;
using ChatBot.Dtos;
public interface IBotCommand
{
	string Trigger { get; }
	Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId);

}

