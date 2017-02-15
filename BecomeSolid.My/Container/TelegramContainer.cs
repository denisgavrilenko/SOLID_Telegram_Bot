using System;
namespace BecomeSolid.My
{
	public class TelegramContainer : IContainer
	{
		private Container _container = new Container();

		public TelegramContainer(ContainerContract contract = null)
		{
			if (contract != null)
			{
				LoadContract(contract);
			}
		}

		public void LoadContract(ContainerContract contract)
		{
			contract.LoadContract(_container);
		}

		public void Register<TService>(Func<Container, TService> creator)
		{
			_container.Register(creator);
		}

		public void RegisterPrototype<TService>(Func<TService> creator)
		{
			_container.RegisterPrototype(creator);
		}

		public T Resolve<T>()
		{
			return _container.Resolve<T>();
		}
	}
}
