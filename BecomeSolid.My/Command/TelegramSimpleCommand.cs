using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Linq;

namespace BecomeSolid.My
{
	public class TelegramSimpleCommand : ICommand
	{
		private string _identifier;
		private string[] _parameters;
		private long _id;

		public long Id
		{
			get
			{
				return _id;
			}
		}

		public string Identifier
		{
			get
			{
				return _identifier;
			}
		}

		public string[] Parameters
		{
			get
			{
				return _parameters;
			}
		}

		public TelegramSimpleCommand(Update update)
		{
			var messageText = update.Message.Text;
			var messagePart = messageText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			_identifier = messagePart.First();
			_parameters = messagePart.Skip(1).ToArray();
			_id = update.Message.Chat.Id;
		}
	}
}
