using System;
using System.Collections.Generic;

namespace BecomeSolid.My
{
	public class Container : IContainer
	{
		Dictionary<Type, Func<object>> _registers = new Dictionary<Type, Func<object>>();

		public void Register<TService>(Func<Container, TService> creator)
		{
			_registers.Add(typeof(TService), () =>
			{
				var instance = creator(this);
				_registers[typeof(TService)] = () => instance;
				return instance;
			});
		}

		public void RegisterPrototype<TService>(Func<TService> creator)
		{
			_registers.Add(typeof(TService), () => creator());
		}

		public T Resolve<T>()
		{
			Func<object> creator;
			if (_registers.TryGetValue(typeof(T), out creator))
			{
				return (T)Convert.ChangeType(creator(), typeof(T));
			}
			else
			{
				throw new InvalidOperationException("Can't resolve " + typeof(T));
			}
		}
	}
}
