namespace practice_24._02.Repostories.Interface{
using ChatBot.Repositories.Models;


	public interface IChatModelRepository
	{
		Task<List<OpenApiResponse.Message>> GetHistoryAsync(long chatId);
		Task AddMessageAsync(long chatId, OpenApiResponse.Message message);
	}
}