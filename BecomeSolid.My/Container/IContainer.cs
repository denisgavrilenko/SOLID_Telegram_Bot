using System;
namespace BecomeSolid.My
{
	public interface IContainer
	{
		void Register<TService>(Func<Container, TService> creator);
		void RegisterPrototype<TService>(Func<TService> creator);
		T Resolve<T>();
	}
}
