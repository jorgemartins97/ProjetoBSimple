using Domain.interfaces;
using Microsoft.VisualBasic;

namespace Domain.Tests
{
    public class ProjetoTest
    {
        [Theory]
        [InlineData("Teste", "2024-03-12", "2024-03-13")]
        [InlineData("qqqqqqqqqqwwwwwwwwwweeeeeeeeeerrrrrrrrrrtttttttttt", "2024-03-12", "2024-03-13")]
        [InlineData("Teste", "2024-03-13", "2024-03-13")]
        public void WhenPassingCorrectData_ThenProjectIsInstantiated(string strNome, string dataInicio, string dataFim)
        {
            var dataIn =DateOnly.Parse(dataInicio);
            var dataF = DateOnly.Parse(dataFim);
            var projeto = new Projeto(strNome, dataIn, dataF);

            //assert
            Assert.Equal(strNome, projeto._strName);
        }
 
        [Theory]
        [InlineData("qweqwe qweqwefdgdf gdf gdfgdfg dfgdf fd dfgdfgdf fdg dfg dfgfhfghgfhfgd fgh  fghfghfghfghfghfg d gdfjgjghjhg  fgfhfghfghgf", "2024-03-12", "2024-03-13")]
        [InlineData("    ", "2024-03-12", "2024-03-13")]
        [InlineData("1112321", "2024-03-12", "2024-03-13")]
        [InlineData(null, "2024-03-12", "2024-03-13")]
        public void WhenPassingInvalidProjeto_ThenThrowsException(string strNome, string dataInicio, string dataFim)
        {
            var dataIn =DateOnly.Parse(dataInicio);
            var dataF = DateOnly.Parse(dataFim);
            // assert
            var ex = Assert.Throws<ArgumentException>(() =>
                // actS
                new Projeto(strNome, dataIn, dataF)
            );
            Assert.Equal("Invalid arguments.", ex.Message);
        }
 
        [Theory]
        [InlineData("Teste")]
        public void WhenPassingInvalidProjetoData_ThenCompetenciasIsInstantiated(string strNome){
            DateOnly dataIn = new DateOnly(2024,1,1);
            DateOnly dataF = new DateOnly(2023,3,1);
            // assert
            var ex = Assert.Throws<ArgumentException>(() =>
                
            // act
                new Projeto(strNome, dataIn, dataF)
            );
            Assert.Equal("Invalid arguments.", ex.Message);
        }

        [Fact]
        public void IsColaboratorInProject_ReturnsTrue_WhenColaboratorIsFound()
        {
            // Arrange
            var projeto = new Projeto("nome", new DateOnly(2024, 01, 01), new DateOnly(2024, 01, 03));
            var colaboratorMock = new Mock<IColaborator>();
            var associationMock = new Mock<IAssociacao>();
            var associationFactoryMock = new Mock<IAssociationFactory>();

            // Configuração dos mocks
            associationFactoryMock.Setup(af => af.NewAssociation(colaboratorMock.Object)).Returns(associationMock.Object);
            associationMock.Setup(a => a.isContainedColaborator(colaboratorMock.Object)).Returns(true);

            projeto.addAssociacao(associationFactoryMock.Object, colaboratorMock.Object);
            // Act
            var result = projeto.isColaboratorInProject(colaboratorMock.Object);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void isColaboratorInProject_ReturnFalse_IfColaboratorIsntAssociated()
        {
            // Arrange
            var associationDouble = new Mock<IAssociacao>();
            var project = new Projeto("nome", new DateOnly(2024, 01, 01), new DateOnly(2024, 01, 03));
            var colabDouble = new Mock<IColaborator>();
            var colabDouble2 = new Mock<IColaborator>();
            var associationFactoryDouble = new Mock<IAssociationFactory>();
 
            // Configuração dos mocks
            associationFactoryDouble.Setup(af => af.NewAssociation(colabDouble.Object)).Returns(associationDouble.Object);
 
            associationDouble.Setup(a => a.isContainedColaborator(colabDouble.Object)).Returns(true);
            project.addAssociacao(associationFactoryDouble.Object, colabDouble.Object);
 
            // Act
            var result = project.isColaboratorInProject(colabDouble2.Object);
 
            // Assert
            Assert.False(result);
        }


         [Fact]
        public void AddAssociacao_WhenColaboratorIsValid_AddsAssociation()
        {
            // Arrange
            var associationFactoryMock = new Mock<IAssociationFactory>();
            var associationMock = new Mock<IAssociacao>();
            var colaboratorMock = new Mock<IColaborator>().Object;
            var projeto = new Projeto("nome", new DateOnly(2024, 01, 01), new DateOnly(2024, 01, 03));

            associationFactoryMock.Setup( af => af.NewAssociation(colaboratorMock)).Returns(associationMock.Object);

            // Configura o mock para retornar true quando isColaboratorAssociated for chamado com o colaborador correto
            associationMock.Setup(a => a.isContainedColaborator(colaboratorMock)).Returns(true);
 
            projeto.addAssociacao(associationFactoryMock.Object, colaboratorMock);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => projeto.addAssociacao(associationFactoryMock.Object, colaboratorMock));
        }

        [Fact]
        public void AddAssociation_ShouldAddNewAssociation_WhenColaboratorIsNotAssociated()
        {
            // Arrange
            var colabDouble = new Mock<IColaborator>().Object;
            var associationFactoryDouble = new Mock<IAssociationFactory>();
            var project = new Projeto("nome", new DateOnly(2024, 01, 01), new DateOnly(2024, 01, 03));
            var associationDouble = new Mock<IAssociacao>();
 
            associationFactoryDouble.Setup(af => af.NewAssociation(colabDouble)).Returns(associationDouble.Object);
 
            associationDouble.Setup(a => a.isContainedColaborator(colabDouble)).Returns(false);
 
            // Act
            project.addAssociacao(associationFactoryDouble.Object, colabDouble);
 
            // Assert
 
        }

        [Fact]
        public void AddAssociation_ShouldThrowException_WhenColaboratorIsAlreadyAssociated()
        {
            // Arrange
            var colabMock = new Mock<IColaborator>().Object;
            var associationFactoryMock = new Mock<IAssociationFactory>();
            var associationMock = new Mock<IAssociacao>();
            var project = new Projeto("nome", new DateOnly(2024, 01, 01), new DateOnly(2024, 01, 03));
 
            // Configuração dos mocks
            associationFactoryMock.Setup(af => af.NewAssociation(colabMock)).Returns(associationMock.Object);
 
            // Configura o mock para retornar true quando isColaboratorAssociated for chamado com o colaborador correto
            associationMock.Setup(a => a.isContainedColaborator(colabMock)).Returns(true);
 
            project.addAssociacao(associationFactoryMock.Object, colabMock);
 
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => project.addAssociacao(associationFactoryMock.Object, colabMock));
            Assert.Equal("Colaborador ja esta associado ao projeto (Parameter 'colaborator')", ex.Message);
        }
 
        [Fact]
        public void AddAssociation_ShouldThrowArgumentNullException_WhenColaboratorIsNull()
        {
            // Arrange
            var associationFactoryDouble = new Mock<IAssociationFactory>();
            var project = new Projeto("nome", new DateOnly(2024, 01, 01), new DateOnly(2024, 01, 03));
 
            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => project.addAssociacao(associationFactoryDouble.Object, null));
            Assert.Equal("Colaborador nao pode ser nulo. (Parameter 'colaborator')", ex.Message);
        }



    [Fact]
    public void IsColaboratorInProject_ReturnsFalse_WhenColaboratorIsNotFound()
    {
        // Arrange
        var projeto = new Projeto("nome", new DateOnly(2024, 01, 01), new DateOnly(2024, 01, 03));
        var colaboratorMock1 = new Mock<IColaborator>();
        var colaboratorMock2 = new Mock<IColaborator>();
        var associationMock = new Mock<IAssociacao>();
        var associationFactoryMock = new Mock<IAssociationFactory>();


        associationMock.Setup(a => a.isContainedColaborator(colaboratorMock1.Object)).Returns(true);

        associationFactoryMock.Setup(af => af.NewAssociation(colaboratorMock1.Object)).Returns(associationMock.Object);

        projeto.addAssociacao(associationFactoryMock.Object, colaboratorMock1.Object);

        // Act
        var result = projeto.isColaboratorInProject(colaboratorMock2.Object);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsColaboratorInProject_ReturnsFalse_WhenNoAssociationsExist()
    {
        // Arrange
        var project = new Projeto("nome", new DateOnly(2024, 01, 01), new DateOnly(2024, 01, 03));
        var colaboratorMock = new Mock<IColaborator>();
        var associationMock = new Mock<IAssociacao>();
        associationMock.Setup(a => a.isContainedColaborator(colaboratorMock.Object)).Returns(false);

        // Act
        var result = project.isColaboratorInProject(colaboratorMock.Object);

        // Assert
        Assert.False(result);
    }
    }

}

