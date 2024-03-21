namespace Domain.Tests;
using Domain.interfaces;

public class FormacaoTest
    {
        [Theory]
        [InlineData("Formação")]
        [InlineData("A formação será sobre Angular.")]

        public void WhenPassingCorrectData_ThenFormacaoIsInstantiated(string strDescriçao)
        {
            new Formacao (strDescriçao);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void WhenPassingInvalidDescription_ThenThrowsException(string strDescricao)
        {
            // arrange

            // assert 
            Assert.Throws<ArgumentException>(() => 
        
             // act 
                new Formacao(strDescricao)
                );
        }

        [Fact]
        public void WhenRequestingAddPeriodoFormacao_ThenReturnPeriodoFormacao()
        {
        // // arrange
        // Mock<IColaborator> doubleColaborator = new Mock<IColaborator>();
        // var formacao = new Formacao("olaamigos");
 
        // DateOnly dataInicio = new DateOnly(2024, 7, 1);
        // DateOnly dataFim = new DateOnly(2024, 7, 15);
 
        // Mock<IPeriodoFormacaoFactory> pfFactoryDouble = new Mock<IPeriodoFormacaoFactory>();
 
        // Mock<PeriodoFormacao> pfDouble = new Mock<PeriodoFormacao>(dataInicio, dataFim);
 
        // pfFactoryDouble.Setup(pfF => pfF.createPeriodoFormacao(dataInicio, dataFim)).Returns(pfDouble.Object);
 
        // // act
        // DateOnly hpDataInicio = new DateOnly(2024, 7, 1);
        // DateOnly hpDataFim = new DateOnly(2024, 7, 15);
 
        // var periodoFormacao = formacao.AddPeriodoFormacao(pfFactoryDouble.Object, hpDataInicio, hpDataFim);
 
 
        // // assert
        // Assert.Equal(dataInicio, periodoFormacao.getDataInicio());
        // Assert.Equal(dataFim, periodoFormacao.getDataFim());

        // arrange
            Mock<IColaborator> doubleColaborator = new Mock<IColaborator>();
            var formacao = new Formacao("olaamigos");

            DateOnly dataInicio = new DateOnly(2024, 7, 1);
            DateOnly dataFim = new DateOnly(2024, 7, 15);

            Mock<IPeriodoFormacaoFactory> pfFactoryDouble = new Mock<IPeriodoFormacaoFactory>();
            Mock<PeriodoFormacao> pfDouble = new Mock<PeriodoFormacao>(dataInicio, dataFim);
 
            pfFactoryDouble.Setup(hpF => hpF.NewPeriodoFormacao(dataInicio, dataFim)).Returns(pfDouble.Object);
 
            // act
            DateOnly pfDataInicio = new DateOnly(2024, 7, 1);
            DateOnly pfDataFim = new DateOnly(2024, 7, 15);
    
            var periodoFormacao = formacao.AddPeriodoFormacao(pfFactoryDouble.Object, pfDataInicio, pfDataFim);
 
 
            // assert
            Assert.Equal(dataInicio, pfDataInicio);
            Assert.Equal(dataFim, pfDataFim);

        }
    }

