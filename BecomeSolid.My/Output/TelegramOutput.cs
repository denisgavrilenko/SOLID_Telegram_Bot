using System;
using Telegram.Bot;

namespace BecomeSolid.My
{
	public class TelegramOutput : IOutput
	{
		private TelegramBotClient _bot;

		public TelegramOutput(TelegramBotClient bot)
		{
			_bot = bot;
		}

		public void SendResponse(ICommand command, string message)
		{
			_bot.SendTextMessageAsync(command.Id, message);
		}
	}
}
