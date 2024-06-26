using Domain.interfaces;

namespace Domain.Tests
{
    public class AssociationTest
    {
        [Fact]
        public void WhenPassingCorrectData_ThenAssociacaoIsInstantiated()
        {
            Mock<IColaborator> colabDouble = new Mock<IColaborator>();
 
            new Associacao(colabDouble.Object);
        }
 
        [Fact]
        public void WhenPassingNullAsColaborator_ThenThrowsException()
        {
            Mock<IColaborator> colabDouble = new Mock<IColaborator>();
            var ex = Assert.Throws<ArgumentException>(() => new Associacao(null));
            Assert.Equal("Invalid argument: colaborator must be non null", ex.Message);
        }
 
        [Fact]
        public void isColaboratorAssociated_ReturnTrue_IfColaboratorIsCorrect()
        {
            // Arrange
            var colabDouble = new Mock<IColaborator>().Object;
            var association = new Associacao(colabDouble);
 
            // Act
            var result = association.isContainedColaborator(colabDouble);
 
            // Assert
            Assert.True(result);
        }
 
        [Fact]
        public void isColaboratorAssociated_ReturnFalse_IfColaboratorIsDifferent()
        {
            // Arrange
            var colabDouble1 = new Mock<IColaborator>().Object;
            var colabDouble2 = new Mock<IColaborator>().Object;
            var association = new Associacao(colabDouble1);
 
            // Act
            var result = association.isContainedColaborator(colabDouble2);
 
            // Assert
            Assert.False(result);
        }
 
        [Fact]
        public void GetColaborator_ReturnsCorrectColaborator()
        {
            // Arrange
            Mock<IColaborator> colabDouble = new Mock<IColaborator>();
            Associacao association = new Associacao(colabDouble.Object);

            // Act
            var result = association.getColaborador();

            // Assert
            Assert.Equal(colabDouble.Object, result);
        }
    }
}