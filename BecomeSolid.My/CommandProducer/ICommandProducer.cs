using System;
using System.Threading.Tasks;

namespace BecomeSolid.My
{
	public interface ICommandProducer
	{
		Task Start();
		void Stop();
	}
}
