using System;
namespace BecomeSolid.My
{
	public interface ICommand
	{
		long Id { get; }
		string Identifier { get; }
		string[] Parameters { get; }
	}
}
