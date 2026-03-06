namespace ChatBot.Dtos
{
	public class TelegramUpdate
	{
		public int UpdateId { get; set; }
		public TelegramMessage? Message { get; set; }
		public TelegramMessage? EditedMessage { get; set; }
	}
}