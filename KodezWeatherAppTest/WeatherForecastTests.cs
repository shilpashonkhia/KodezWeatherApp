using KodezWeatherApp;

namespace KodezWeatherAppTest
{
	public class WeatherForecastTests
	{
		[Test]
		public async Task IncorrectNumberOfArguments()
		{
			// Arrange
			var input = new string[] {"1"};
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string expectedOutput = "Usage: WeatherApp <numDays> <latitude> <longitude>\r\n";
			// Act
			await Weather.FetchWeatherFromOpenMeteo(input);

			// Assert
			var output = stringWriter.ToString();
			Assert.That(output, Is.EqualTo(expectedOutput));
		}


		[Test]
		public async Task IncorrectNumDays()
		{
			// Arrange
			var input = new string[] { "StringNumDays", "1.45", "1.45" };
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string expectedOutput = "Error: <numDays> parameter must be a positive integer and less than 16\r\n";
			// Act
			await Weather.FetchWeatherFromOpenMeteo(input);

			// Assert
			var output = stringWriter.ToString();
			Assert.That(output, Is.EqualTo(expectedOutput));
		}

		[Test]
		public async Task IncorrectNumDaysMaxThan16()
		{
			// Arrange
			var input = new string[] { "18", "1.45", "1.45" };
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string expectedOutput = "Error: <numDays> parameter must be a positive integer and less than 16\r\n";
			// Act
			await Weather.FetchWeatherFromOpenMeteo(input);

			// Assert
			var output = stringWriter.ToString();
			Assert.That(output, Is.EqualTo(expectedOutput));
		}

		[Test]
		public async Task IncorrectNumDaysLessThan0()
		{
			// Arrange
			var input = new string[] { "-2", "1.45", "1.45" };
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string expectedOutput = "Error: <numDays> parameter must be a positive integer and less than 16\r\n";
			// Act
			await Weather.FetchWeatherFromOpenMeteo(input);

			// Assert
			var output = stringWriter.ToString();
			Assert.That(output, Is.EqualTo(expectedOutput));
		}

		[Test]
		public async Task IncorrectLatitude()
		{
			// Arrange
			var input = new string[] { "1", "WrongLatitude", "1.45" };
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string expectedOutput = "Error: <latitude> parameter must be a decimal number between -90 and 90\r\n";
			// Act
			await Weather.FetchWeatherFromOpenMeteo(input);

			// Assert
			var output = stringWriter.ToString();
			Assert.That(output, Is.EqualTo(expectedOutput));
		}

		[Test]
		public async Task IncorrectLatitudeLessThanMinus90()
		{
			// Arrange
			var input = new string[] { "1", "-97", "1.45" };
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string expectedOutput = "Error: <latitude> parameter must be a decimal number between -90 and 90\r\n";
			// Act
			await Weather.FetchWeatherFromOpenMeteo(input);

			// Assert
			var output = stringWriter.ToString();
			Assert.That(output, Is.EqualTo(expectedOutput));
		}

		[Test]
		public async Task IncorrectLatitudeGreaterThan90()
		{
			// Arrange
			var input = new string[] { "1", "97", "1.45" };
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string expectedOutput = "Error: <latitude> parameter must be a decimal number between -90 and 90\r\n";
			// Act
			await Weather.FetchWeatherFromOpenMeteo(input);

			// Assert
			var output = stringWriter.ToString();
			Assert.That(output, Is.EqualTo(expectedOutput));
		}

		[Test]
		public async Task IncorrectLongitude()
		{
			// Arrange
			var input = new string[] { "1", "8.9", "WrongLongitude" };
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string expectedOutput = "Error: <longitude> parameter must be a decimal number between -180 and 180\r\n";
			// Act
			await Weather.FetchWeatherFromOpenMeteo(input);

			// Assert
			var output = stringWriter.ToString();
			Assert.That(output, Is.EqualTo(expectedOutput));
		}

		[Test]
		public async Task IncorrectLongitudeLessThanMinus180()
		{
			// Arrange
			var input = new string[] { "1", "8.9", "-190" };
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string expectedOutput = "Error: <longitude> parameter must be a decimal number between -180 and 180\r\n";
			// Act
			await Weather.FetchWeatherFromOpenMeteo(input);

			// Assert
			var output = stringWriter.ToString();
			Assert.That(output, Is.EqualTo(expectedOutput));
		}

		[Test]
		public async Task IncorrectLongitudeGreaterThan180()
		{
			// Arrange
			var input = new string[] { "1", "8.6", "185" };
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string expectedOutput = "Error: <longitude> parameter must be a decimal number between -180 and 180\r\n";
			// Act
			await Weather.FetchWeatherFromOpenMeteo(input);

			// Assert
			var output = stringWriter.ToString();
			Assert.That(output, Is.EqualTo(expectedOutput));
		}
		
	}
}