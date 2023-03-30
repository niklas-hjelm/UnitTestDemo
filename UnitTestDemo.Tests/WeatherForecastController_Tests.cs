using FakeItEasy;
using Microsoft.Extensions.Logging;
using UnitTestDemo.Controllers;

namespace UnitTestDemo.Tests
{
    public class WeatherForecastController_Tests
    {
        [Fact]
        public void WeatherForecast_Get_Returns_ArrayOfWeather()
        {
            //Arrange
            var logger = A.Fake<ILogger<WeatherForecastController>>();
            var sut = new WeatherForecastController(logger);

            //Act
            var result = sut.Get();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<WeatherForecast[]>(result);
        }
    }
}