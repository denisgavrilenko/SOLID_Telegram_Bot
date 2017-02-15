using System;
namespace BecomeSolid.My
{
	public interface ICommandHandler
	{
		bool isApplicable(ICommand command);
		void execute(ICommand command);
	}
}
