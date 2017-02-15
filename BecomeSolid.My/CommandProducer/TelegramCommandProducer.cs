using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BecomeSolid.My
{
	public class TelegramCommandProducer : ICommandProducer
	{
		private TelegramBotClient _bot;
		private ICommandExecutor _executor;
		private bool _isWorking;

		public TelegramCommandProducer(TelegramBotClient bot, ICommandExecutor executor)
		{
			_bot = bot;
			_executor = executor;
			_isWorking = false;
		}

		public async Task Start()
		{
			if (_isWorking)
			{
				return;
			}

			_isWorking = true;

			var offset = 0;

			while (_isWorking)
			{
				var updates = await _bot.GetUpdatesAsync(offset);

				foreach (var update in updates)
				{
					if (update.Type == UpdateType.MessageUpdate)
					{
						var command = new TelegramSimpleCommand(update);
						_executor.ExecuteCommand(command);
					}
					offset = update.Id + 1;
				}
				await Task.Delay(1000);
			}
		}

		public void Stop()
		{
			_isWorking = false;
		}
	}
}
