namespace ChatBot.Repositories.Interfaces;

public interface IChatApiClient
{
	Task<string> SendMessageAsync(string userMessage);
}


