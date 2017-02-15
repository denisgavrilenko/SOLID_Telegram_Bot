using System;
namespace BecomeSolid.My
{
	public interface IOutput
	{
		void SendResponse(ICommand command, string message);
	}
}
