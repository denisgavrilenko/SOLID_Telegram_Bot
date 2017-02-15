using System;
namespace BecomeSolid.My
{
	public class WeatherCommandHandler : ICommandHandler
	{
		private WeatherService _weatherService = new WeatherService();
		private string _identifier;
		private IOutput _output;

		public WeatherCommandHandler(string identifier, IOutput output)
		{
			_identifier = identifier;
			_output = output;
		}

		public void execute(ICommand command)
		{
			if (command.Parameters.Length > 0)
			{
				var currentWeather = _weatherService.GetWeatherForCity(command.Parameters[0]);
				_output.SendResponse(command, currentWeather.Temperature.ToString());
			}
		}

		public bool isApplicable(ICommand command)
		{
			return command.Identifier.Equals(_identifier);
		}
	}
}
