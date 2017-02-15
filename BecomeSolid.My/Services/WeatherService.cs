using System;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace BecomeSolid.My
{
	public class WeatherService
	{
		private string _url = "http://api.apixu.com/v1/current.json?key=78ecb8e9a6a54007961205921171302&q={0}";

		public Weather GetWeatherForCity(string city)
		{
			var request = WebRequest.Create(string.Format(_url, city));
			WebResponse response = request.GetResponse();
			using (var streamReader = new StreamReader(response.GetResponseStream()))
			{
				string responseString = streamReader.ReadToEnd();

				var weather = JsonConvert.DeserializeObject<WeatherResponse>(responseString);

				return new Weather
				{
					Temperature = weather.Weather.Temperature
				};
			}
		}
	}
}
