using Telegram.Bot.Types;

namespace ChatBot.Dtos
{
	public class TelegramMessage
	{
		public int MessageId { get; set; }
		public Chat Chat { get; set; } = new Chat();
		public string? Text { get; set; }
		public int Date { get; set; }
	}
}