using System;
using Newtonsoft.Json;

namespace BecomeSolid.My
{
	public class WeatherResponse
	{
		[JsonProperty("current")]
		public CurrentWeather Weather { get; set; }
	}
}
