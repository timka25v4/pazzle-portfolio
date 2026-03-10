using Telegram.Bot;
using ChatBot.Dtos;
namespace ChatBot.Commands
{
	public interface IBotCommand
	{
		string Trigger { get; }
		void ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId);

	}
}
