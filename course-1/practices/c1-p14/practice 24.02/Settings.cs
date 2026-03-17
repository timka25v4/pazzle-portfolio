namespace ChatBot.Settings
{
	public static class ChatApiSettings
	{
		public static string BaseUrl { get; } = "https://openrouter.ai/api/v1/chat/completions";
		public static string ApiKey { get; } = "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";
		public static string DefaultModel { get; } = "gpt-3.5-turbo";

	}
}