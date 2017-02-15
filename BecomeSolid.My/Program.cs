using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BecomeSolid.My
{
	public class Program
	{
		static void Main(string[] args)
		{
			Run().Wait();
		}

		static async Task Run()
		{
			var container = new TelegramContainer(new ContainerContract());
			await container.Resolve<TelegramCommandProducer>().Start();
			await Task.Delay(1000);
		}
	}
}
