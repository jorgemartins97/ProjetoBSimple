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
            new HolidayPeriod(dataIn, dataF);
        }

        [Theory]
        [InlineData("2024-03-12", "2024-03-11")]
        public void WhenPassingInvalidPeriodoFerias_ThenIsReturnException(string dataInicio, string dataFim)
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

        [Fact]
        public void CalcularNumeroDias_DeveRetornarDiferencaCorreta()
        {
        // Arrange
        var startDate = new DateOnly(2024, 3, 10); // Suponhamos que a data de início seja 10 de março de 2024
        var endDate = new DateOnly(2024, 3, 15);   // Suponhamos que a data de término seja 15 de março de 2024
        var objetoExemplo = new HolidayPeriod(startDate, endDate); // Crie um objeto com as datas de início e término

        // Act
        var resultado = objetoExemplo.CalcularNumeroDias(); // Chame o método para calcular o número de dias

        // Assert
        Assert.Equal(6, resultado); // Verifique se a diferença calculada é 6 (15 - 10 + 1)
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