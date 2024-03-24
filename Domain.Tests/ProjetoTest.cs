namespace Domain.Tests
{
    public class ProjetoTest
    {
        [Fact]
        public void WhenPassingCorrectData_ThenProjectIsInstantiated()
        {
            string strNome = "teste";
            DateOnly dataIn = new DateOnly(2024,1,1);
            DateOnly dataF = new DateOnly(2024,3,1);
            new Projeto(strNome, dataIn, dataF);
        }
 
        [Theory]
        [InlineData("qweqwe qweqwefdgdf gdf gdfgdfg dfgdf fd dfgdfgdf fdg dfg dfgfhfghgfhfgd fgh  fghfghfghfghfghfg d gdfjgjghjhg  fgfhfghfghgf")]
        [InlineData("    ")]
        [InlineData("1112321")]
        [InlineData(null)]
        public void WhenPassingInvalidProjeto_ThenThrowsException(string strNome)
        {
            DateOnly dataIn = new DateOnly(2024,1,1);
            DateOnly dataF = new DateOnly(2024,3,1);
            // assert
            Assert.Throws<ArgumentException>(() =>
                // actS
                new Projeto(strNome, dataIn, dataF)
            );
        }
 
        [Theory]
        [InlineData("Teste")]
        public void WhenPassingInvalidProjetoData_ThenCompetenciasIsInstantiated(string strNome){
            DateOnly dataIn = new DateOnly(2024,1,1);
            DateOnly dataF = new DateOnly(2023,3,1);
            // assert
            Assert.Throws<ArgumentException>(() =>
                
            // act
                new Projeto(strNome, dataIn, dataF)
            );
        }
    
        /*[Fact]
        public void GetDiasFeriasDosColaboradores_ThenReturnsCorrectTotalDays()
        {
            // Arrange
            var colaboradorMock = new Mock<IColaborator>();
            var holidayMock = new Mock<IHoliday>();
            
            var dataInicio = new DateOnly(2024, 01, 01);
            var dataFim = new DateOnly(2024, 01, 10);
            var holidayPeriods = new HolidayPeriod(dataInicio,dataFim);
            int expectedTotalDiasFerias = (dataFim.DayNumber - dataInicio.DayNumber)+1;

            holidayMock.Setup(h => h.getColaborador()).Returns(colaboradorMock.Object);
            
            holidayMock.Object.addHolidayPeriod(dataInicio, dataFim);
            
            Projeto sut = new Projeto("ola",dataInicio,dataFim);

            sut.addAssociacao(new Associacao(colaboradorMock.Object,sut));

            // Act
            int totalDiasFerias = sut.GetDiasFeriasDosColaboradores(dataInicio, dataFim, sut);
            // Assert
            Assert.Equal(expectedTotalDiasFerias, totalDiasFerias);
        }*/
    }

}