using ChatBot.Commands;
using Telegram.Bot;
public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers().AddNewtonsoftJson();

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var telegramToken = "токен";
		builder.Services.AddSingleton<ITelegramBotClient>(sp => new TelegramBotClient(telegramToken));
		builder.Services.AddSingleton<IBotCommand, StartCommand>();
		builder.Services.AddSingleton<IBotCommand, HelpCommand>();
		builder.Services.AddSingleton<TelegramUpdateProcessor>();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();


		app.MapControllers();

		app.Run();
	}
}

