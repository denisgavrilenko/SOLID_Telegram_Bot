using System;
using Newtonsoft.Json;

namespace BecomeSolid.My
{
	public class CurrentWeather
	{
		[JsonProperty("temp_c")]
		public double Temperature { get; set; }
	}
}
