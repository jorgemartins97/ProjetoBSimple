namespace Domain.Tests
{
    public class HolidayPeriodTest
    {
        [Theory]
        [InlineData("2024-03-12", "2024-03-13")]
        public void WhenPassingCorrectPeriodoFerias_ThenIsInstantiated(string dataInicio, string dataFim)
        {
            var dataIn = DateOnly.Parse(dataInicio);
            var dataF = DateOnly.Parse(dataFim);
            var hPeriod = new HolidayPeriod(dataIn, dataF);

            // Assert.Equal(dataIn, hPeriod._startDate);
            // Assert.Equal(dataF, hPeriod._endDate);
        }

        [Theory]
        [InlineData("2024-03-12", "2024-03-11")]
        public void WhenPassingInvalidPeriodoFerias_ThenIsReturnException(string dataInicio, string dataFim)
        {
            var dataIn = DateOnly.Parse(dataInicio);
            var dataF = DateOnly.Parse(dataFim);
            // assert
            var ex = Assert.Throws<ArgumentException>(() =>
                // act
                new HolidayPeriod(dataIn, dataF)
            );
            Assert.Equal("invalid arguments: start date >= end date.", ex.Message);
        }

        [Theory]
        [InlineData("2024-03-01", "2024-03-15", "2024-03-05", "2024-03-10", true)] // Intervalo totalmente contido
        [InlineData("2024-03-01", "2024-03-15", "2024-02-25", "2024-03-20", false)] // Intervalo totalmente fora
        [InlineData("2024-03-01", "2024-03-15", "2024-02-25", "2024-03-05", false)] // Intervalo que começa antes e termina dentro
        [InlineData("2024-03-01", "2024-03-15", "2024-03-10", "2024-03-20", false)] // Intervalo que começa dentro e termina depois
        public void IsValidPeriod_ReturnsExpectedResult(string holidayStart, string holidayEnd, string rangeStart, string rangeEnd, bool expected)
        {
            // Arrange
            var holidayPeriod = new HolidayPeriod(DateOnly.Parse(holidayStart), DateOnly.Parse(holidayEnd));
 
            // Act
            bool result = holidayPeriod.IsValidPeriod(DateOnly.Parse(rangeStart), DateOnly.Parse(rangeEnd));
 
            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("2024-03-01", "2024-03-10", "2024-03-05", "2024-03-15", 6)] // Total overlap
        [InlineData("2024-03-01", "2024-03-10", "2024-02-25", "2024-03-20", 10)] // Full range includes holiday period
        [InlineData("2024-03-01", "2024-03-10", "2024-03-05", "2024-03-08", 4)] // Partial overlap
        [InlineData("2024-03-01", "2024-03-10", "2024-03-11", "2024-03-15", 0)] // No overlap
        public void CalcularNumeroDias_DeveRetornarDiferencaCorreta(string holidayStart, string holidayEnd, string rangeStart, string rangeEnd, int expectedTotalDays)
        {

        // Arrange
            var holidayPeriod = new HolidayPeriod(DateOnly.Parse(holidayStart), DateOnly.Parse(holidayEnd));

            // Act
            var totalDays = holidayPeriod.CalculateTotalDays(DateOnly.Parse(rangeStart), DateOnly.Parse(rangeEnd));

            // Assert
            Assert.Equal(expectedTotalDays, totalDays);
    }

        [Fact]
        public void CalculateTotalDays_Returns_Correct_TotalDays()
        {
        // Arrange
        
        var startDate = new DateOnly(2024, 3, 1);
        var endDate = new DateOnly(2024, 3, 10);
        var dateCalculator = new HolidayPeriod(startDate, endDate);

        // Act
        var totalDays = dateCalculator.CalculateTotalDays(startDate, endDate);

        // Assert
        Assert.Equal(10, totalDays); // Change the expected value as per your calculation
        }
    }

}