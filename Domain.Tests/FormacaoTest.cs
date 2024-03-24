namespace Domain.Tests;

using System.Diagnostics.Contracts;
using System.Net.Cache;
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

        [Fact]
        public void AddCompetenciaPrevia_CompetenciaNaoExiste_AdicionaCompetencia()
        {
        // Arrange
        var formacao = new Formacao("Desc da Formação");
        var competenciasMock = new Mock<ICompetencias>();
        var competenciasList = new List<ICompetencias> {competenciasMock.Object};

        competenciasMock.Setup(c => c.isCompExist(It.IsAny<string>(), It.IsAny<int>())).Returns(false);

        // Act
        formacao.AddCompetenciaPrevia("Competência A", 3);

        Assert.Single(competenciasList); 
        }

        [Fact]
        public void AddCompetenciaAdquirir_CompetenciaNaoExiste_AdicionarCompetencia(){
            //Arrange 
            var formacao = new Formacao("Descricao da formacao");
            var competenciasMock = new Mock<ICompetencias>();
            var competenciasList = new List<ICompetencias>() {competenciasMock.Object};

            competenciasMock.Setup(c => c.isCompExist(It.IsAny<string>(), It.IsAny<int>())).Returns(false);

            // Act
            formacao.AddCompetenciaAdquirir("Competência B", 3);

            Assert.Single(competenciasList); 
        }
    }

