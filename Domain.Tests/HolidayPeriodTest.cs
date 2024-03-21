namespace Domain.Tests
{
    public class HolidayPeriodTest
    {
        [Theory]
        [InlineData("2024-03-12", "2024-03-13")]
        public void WhenPassingCorrectPeriodoFerias_ThenCompetenciasIsInstantiated(string dataInicio, string dataFim)
        {
            var dataIn = DateOnly.Parse(dataInicio);
            var dataF = DateOnly.Parse(dataFim);
            new HolidayPeriod(dataIn, dataF);
        }

        [Theory]
        [InlineData("2024-03-12", "2024-03-11")]
        public void WhenPassingInvalidPeriodoFerias_ThenCompetenciasIsInstantiated(string dataInicio, string dataFim)
        {
            var dataIn = DateOnly.Parse(dataInicio);
            var dataF = DateOnly.Parse(dataFim);
            // assert
            Assert.Throws<ArgumentException>(() =>
                // act
                new HolidayPeriod(dataIn, dataF)
            );
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
    }

}