using Telegram.Bot;
using ChatBot.Dtos;
namespace ChatBot.Commands
{
	public class TelegramUpdateProcessor
	{
		private readonly IEnumerable<IBotCommand> _commands;
		private readonly ITelegramBotClient _botClient;

		public TelegramUpdateProcessor(
			IEnumerable<IBotCommand> commands,
			ITelegramBotClient botClient)
		{
			_commands = commands;
			_botClient = botClient;
		}

		public void Handle(TelegramUpdate update)
		{
			if (update.Message == null)
				return;

			var chatId = update.Message.Chat.Id;
			var text = update.Message.Text.Trim();

			if (text.StartsWith("/"))
			{
				var cmd = text.Split(' ', 2)[0];
				var command = _commands.FirstOrDefault(c => c.Trigger.Equals(cmd, StringComparison.OrdinalIgnoreCase));
				if (command != null)
				{
					command.ExecuteAsync(update, _botClient, chatId);
					return;
				}
				else
				{
					_botClient.SendTextMessageAsync(chatId, "Неизвестная команда. Используйте /help");
					return;
				}
			}
		}

	}
}
