using System;
using Telegram.Bot;

namespace BecomeSolid.My
{
	public class ContainerContract
	{
		public void LoadContract(Container container)
		{
			container.Register((Container resolver) => new TelegramBotClient("378764217:AAFqHrX6KZMiRkFacjTRj8ybiLnTIZFOauA"));
			container.Register((Container resolver) => new TelegramOutput(resolver.Resolve<TelegramBotClient>()));
			container.Register((Container resolver) => new WeatherCommandHandler("/weather", resolver.Resolve<TelegramOutput>()));
			container.Register((Container resolver) => new DefaultCommandHandler());
			container.Register((Container resolver) => new CommandExecutor(new ICommandHandler[] { resolver.Resolve<WeatherCommandHandler>() }, resolver.Resolve<DefaultCommandHandler>()));
			container.Register((Container resolver) => new TelegramCommandProducer(resolver.Resolve<TelegramBotClient>(), resolver.Resolve<CommandExecutor>()));
		}
	}
}
