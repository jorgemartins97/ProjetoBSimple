namespace Domain.Tests;
 
public class PeriodoFormacaoTest
{

    [Theory]
        [InlineData("2024-03-12", "2024-03-13")]
        public void WhenPassingCorrectPeriodoFormacao_ThenCompetenciasIsInstantiated(string dataInicio, string dataFim)
        {
            var dataIn = DateOnly.Parse(dataInicio);
            var dataF = DateOnly.Parse(dataFim);
            new PeriodoFormacao(dataIn, dataF);
        }

    
    [Theory]
        [InlineData("2024-03-12", "2024-03-11")]
        public void WhenPassingInvalidPeriodoFormacao_ThenIsReturnException(string dataInicio, string dataFim)
        {
            var dataIn = DateOnly.Parse(dataInicio);
            var dataF = DateOnly.Parse(dataFim);
            // assert
            Assert.Throws<ArgumentException>(() =>
                // act
                new PeriodoFormacao(dataIn, dataF)
            );
        }
}