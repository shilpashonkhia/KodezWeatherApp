using OpenMeteo;
using System.Text.Json;

namespace KodezWeatherApp
{
	public static class Weather
	{
		public async static Task FetchWeatherFromOpenMeteo(string[] args)
		{
			if (args.Length < 3)
			{
				Console.WriteLine("Usage: WeatherApp <numDays> <latitude> <longitude>");
				return;
			}

			if (!int.TryParse(args[0], out int numDays) || numDays <= 0 || numDays > 16)
			{
				Console.WriteLine("Error: <numDays> parameter must be a positive integer and less than 16");
				return;
			}

			if (!float.TryParse(args[1], out float latitude) || latitude < -90 || latitude > 90)
			{
				Console.WriteLine("Error: <latitude> parameter must be a decimal number between -90 and 90");
				return;
			}
			if (!float.TryParse(args[2], out float longitude) || longitude < -180 || longitude > 180)
			{
				Console.WriteLine("Error: <longitude> parameter must be a decimal number between -180 and 180");
				return;
			}


			// Create client
			OpenMeteoClient client = new();

			// Set custom options
			WeatherForecastOptions options = new();
			options.Latitude = latitude;
			options.Longitude = longitude;
			options.Start_date = DateTime.Today.ToString("yyyy-MM-dd");
			options.End_date = DateTime.Today.AddDays(numDays).ToString("yyyy-MM-dd");
			options.Daily = new DailyOptions(){
				DailyOptionsParameter.temperature_2m_min,
				DailyOptionsParameter.temperature_2m_max ,
				DailyOptionsParameter.snowfall_sum
			};

			// Make a api call to get the weather data
			var weatherData = await client.QueryAsync(options);

			if (weatherData is not null)
			{
				var weatherDtos = new List<WeatherDto>();

				for (int i = 0; i < numDays; i++)
				{
					var weatherDto = new WeatherDto();
					weatherDto.Time = weatherData.Daily?.Time?[i];
					weatherDto.TemperatureLow = weatherData.Daily?.Temperature_2m_min?[i];
					weatherDto.TemperatureHigh = weatherData.Daily?.Temperature_2m_max?[i];
					weatherDto.TemperatureFahrenheitLow = CelsiusToFahrenheit(weatherData.Daily.Temperature_2m_min[i]);
					weatherDto.TemperatureFahrenheitHigh = CelsiusToFahrenheit(weatherData.Daily.Temperature_2m_max[i]);
					weatherDto.Snowfall = weatherData.Daily?.Snowfall_sum?[i];
					weatherDtos.Add(weatherDto);
				}

				// Save weather data to JSON file
				var fileName = $"weatherExport_{DateTime.Now:yyyyMMdd}.json";
				var opt = new JsonSerializerOptions() { WriteIndented = true };
				var strJson = JsonSerializer.Serialize<IList<WeatherDto>>(weatherDtos, opt);
				File.WriteAllText(fileName, strJson);
			}			
		}
		private static float CelsiusToFahrenheit(float celsius)
		{
			return celsius * 9 / 5 + 32;
		}
	}
}
