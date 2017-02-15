using System;
namespace BecomeSolid.My
{
	public class CommandExecutor : ICommandExecutor
	{
		private ICommandHandler[] _handlers;
		private ICommandHandler _defaultHandler;
		
		public CommandExecutor(ICommandHandler[] handlers, ICommandHandler defaultHandler)
		{
			_handlers = handlers;
			_defaultHandler = defaultHandler;
		}

		public void ExecuteCommand(ICommand command)
		{
			foreach (var handler in _handlers)
			{
				if (handler.isApplicable(command))
				{
					handler.execute(command);
					return;
				}
			}
			_defaultHandler.execute(command);
		}
	}
}
