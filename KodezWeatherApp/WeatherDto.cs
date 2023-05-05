namespace KodezWeatherApp
{
	public class WeatherDto
	{
		public string? Time { get; set; }
		public float? TemperatureLow { get; set; }
		public float? TemperatureHigh { get; set; }	
		public float? TemperatureFahrenheitLow { get; set; }
		public float? TemperatureFahrenheitHigh { get; set; }
		public float? Snowfall { get; set; }
	}
}
