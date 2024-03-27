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
            var desc = new Formacao (strDescriçao);

            Assert.Equal(strDescriçao, desc._strDescriçao);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void WhenPassingInvalidDescription_ThenThrowsException(string strDescricao)
        {
            // arrange

            // assert 
            var ex = Assert.Throws<ArgumentException>(() => 
        
             // act 
                new Formacao(strDescricao)
                );
            Assert.Equal("Invalid arguments.", ex.Message);
        }

        [Fact]
        public void WhenRequestingAddPeriodoFormacao_DatasValidas_ThenReturnPeriodoFormacao()
        {
        // arrange
            var pfDouble = new Mock<IPeriodoFormacao>();
            var pfFactoryDouble = new Mock<IPeriodoFormacaoFactory>();
            var formacao = new Formacao("olaamigos");

            pfFactoryDouble.Setup(hpF => hpF.NewPeriodoFormacao(new DateOnly(2024, 03, 02), new DateOnly(2024, 03, 07))).Returns(pfDouble.Object);

            var result = formacao.AddPeriodoFormacao(pfFactoryDouble.Object, new DateOnly(2024, 03, 02), new DateOnly(2024, 03, 07));
 
            // assert
            Assert.Equal(result, pfDouble.Object);
        }

        [Fact]
        public void AddCompetenciaPrevia_Deve_AdicionarCompetenciaPreviaCorretamente()
        {
            // Arrange
            var competencia1Mock = new Mock<ICompetencias>();
            
            var formacao = new Formacao("Formacao 1");

            // Act
            var result = formacao.AddCompetenciaPrevia(competencia1Mock.Object);

            // Assert
            Assert.Single(result);
            Assert.Equal(competencia1Mock.Object, result.Single());
        }

        [Fact]
        public void AddCompetenciaAdquirir_AdicionaCompetenciasCorretamente()
        {
        // Arrange
        var competencia1 = new Mock<ICompetencias>();
        var competencia2 = new Mock<ICompetencias>();

        var listaCompetencias = new List<ICompetencias> { competencia1.Object, competencia2.Object };

        var suaClasse = new Formacao("Formacao"); // Substitua 'SuaClasse' pelo nome da sua classe que contém o método AddCompetenciaAdquirir

        // Act
        var result = suaClasse.AddCompetenciaAdquirir(listaCompetencias);

        // Assert
        Assert.Equal(2, result.Count); // Verifica se o número de competências após a adição está correto
        Assert.Contains(competencia1.Object, result); // Verifica se a primeira competência foi adicionada corretamente
        Assert.Contains(competencia2.Object, result); // Verifica se a segunda competência foi adicionada corretamente
        }

 
        [Fact]
        public void AddCompetenciaPrevia_NullSkill_ThrowsArgumentNullException()
        {
            // Arrange
            var formacao = new Formacao("Description");
            var competenciaDouble = new Mock<ICompetencias>();
 
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => formacao.AddCompetenciaPrevia(null));
 
            Assert.Equal("Competencias nao podem ser nulas!", exception.Message);
        }
        
        [Fact]
        public void AddCompetenciaAdquirir_SkillsAlreadyAdded_ThrowsInvalidOperationException()
        {
            // Arrange
            var competenciasMock = new Mock<ICompetencias>();
            var formacao = new Formacao("Description");
            formacao.AddCompetenciaAdquirir(new List<ICompetencias> { competenciasMock.Object });
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => formacao.AddCompetenciaAdquirir(new List<ICompetencias> { competenciasMock.Object }));
            Assert.Equal("Uma ou mais competencias ja estao adicionadas.", exception.Message);
        }

        [Fact]
        public void AddCompetenciaAdquirir_EmptySkillsList_ThrowsArgumentException()
        {
            // Arrange
            var formacao = new Formacao("Description");
 
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => formacao.AddCompetenciaAdquirir(new List<ICompetencias>()));
            Assert.Equal("A lista nao pode ser vazia ou nula", exception.Message);
        }

        [Fact]
        public void AddCompetenciaAdquirir_NullSkillsList_ThrowsArgumentException()
        {
            // Arrange
            var formacao = new Formacao("Description");
 
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => formacao.AddCompetenciaAdquirir(null));
            Assert.Equal("A lista nao pode ser vazia ou nula", exception.Message);
        }

    }

