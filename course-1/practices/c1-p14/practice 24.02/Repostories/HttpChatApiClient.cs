using System.Net.Http.Headers;
using ChatBot.Repositories.Interfaces;
using ChatBot.Repositories.Models;
using ChatBot.Settings;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
public interface IChatApiClient
{
	Task<string> SendMessageAsync(string userMessage, IEnumerable<OpenApiResponse.Message> history);
}
namespace ChatBot.Repositories.Implementations
{
	public class HttpChatApiClient : IChatApiClient
	{
		private readonly HttpClient _httpClient;
		private readonly ChatApiSettings _settings;

		public HttpChatApiClient(HttpClient httpClient, IOptions<ChatApiSettings> options)
		{
			_httpClient = httpClient;
			_settings = options.Value;

			_httpClient.BaseAddress = new Uri(_settings.BaseUrl);
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.ApiKey);
		}

		public async Task<string> SendMessageAsync(string userMessage, IEnumerable<OpenApiResponse.Message> history)
		{
			var payload = new OpenApiRequest()
			{
				Model = _settings.DefaultModel,
				Messages = history.ToList(),
				MaxTokens = 1000
			};
			var response = await _httpClient.PostAsJsonAsync("", payload);
			response.EnsureSuccessStatusCode();

			var body = await response.Content.ReadFromJsonAsync<OpenApiResponse?>();
			if (body?.Choices != null && body.Choices.Length > 0)
			{
				return body.Choices[0].Message.Content;
			}
			return await response.Content.ReadAsStringAsync();
		}
	}
}

