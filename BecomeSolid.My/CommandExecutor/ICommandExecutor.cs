using System;
namespace BecomeSolid.My
{
	public interface ICommandExecutor
	{
		void ExecuteCommand(ICommand command);
	}
}
