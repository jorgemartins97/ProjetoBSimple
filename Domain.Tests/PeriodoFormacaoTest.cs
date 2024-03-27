namespace Domain.Tests;
 
public class PeriodoFormacaoTest
{

    [Theory]
        [InlineData("2024-03-12", "2024-03-13")]
        public void WhenPassingCorrectPeriodoFormacao_ThenCompetenciasIsInstantiated(string dataInicio, string dataFim)
        {
            var dataIn = DateOnly.Parse(dataInicio);
            var dataF = DateOnly.Parse(dataFim);
            var pFormacao = new PeriodoFormacao(dataIn, dataF);

            //assert
            Assert.Equal(dataInicio, pFormacao._dataInicio.ToString("yyyy-MM-dd"));
            Assert.Equal(dataFim, pFormacao._datafim.ToString("yyyy-MM-dd"));
        }

    
    [Theory]
        [InlineData("2024-03-12", "2024-03-12")] // Mutação: <= em vez de <
        [InlineData("2024-03-13", "2024-03-12")] // Mutação: troca de ordem de data
        [InlineData("2024-03-13", "2024-03-13")] // Mutação: remover bloco else vazio
        public void WhenPassingInvalidPeriodoFormacao_ThenIsReturnException(string dataInicio, string dataFim)
        {
            var dataIn = DateOnly.Parse(dataInicio);
            var dataF = DateOnly.Parse(dataFim);
            // assert
            var ex = Assert.Throws<ArgumentException>(() =>
                // act
                new PeriodoFormacao(dataIn, dataF)
            );
            Assert.Equal("invalid arguments: start date >= end date.", ex.Message);
        }
}