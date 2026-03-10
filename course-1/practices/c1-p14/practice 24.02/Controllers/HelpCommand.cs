using ChatBot.Commands;
using ChatBot.Dtos;
using Telegram.Bot;
public class HelpCommand : IBotCommand
{
	public string Trigger => "/help";
	public void ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
	{
		bot.SendTextMessageAsync(chatId, "Список доступных команд: \n/start - начало работы.");
	}

}