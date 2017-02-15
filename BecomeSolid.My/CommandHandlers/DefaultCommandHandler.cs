using System;
namespace BecomeSolid.My
{
	public class DefaultCommandHandler : ICommandHandler
	{
		public DefaultCommandHandler()
		{
		}

		public void execute(ICommand command)
		{
			
		}

		public bool isApplicable(ICommand command)
		{
			return true;
		}
	}
}
