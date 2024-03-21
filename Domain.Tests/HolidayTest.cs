namespace Domain.Tests;

public class HolidayTest
{

    [Fact]
    public void WhenPassingAColaborator_ThenHolidayIsInstantiated()
    {
        //Mock<Colaborator> colabDouble = new Mock<Colaborator>("a", "b@b.pt");
        Mock<IColaborator> colabDouble = new Mock<IColaborator>();

        new Holiday(colabDouble.Object);

        // isto não é um tewste unitário a Holiday, porque não isola do Colaborator
        // Colaborator colab = new Colaborator("a", "a@b.c");
        // IColaborator colab = new Colaborator("a", "a@b.c");
        // new Holiday(colab);
    }


    [Fact]
    public void WhenPassingNullAsColaborator_ThenThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Holiday(null));
    }


    [Fact]
    public void WhenRequestingName_ThenReturnColaboratorName()
    {
        // arrange
        string NOME = "nome";
        Mock<IColaborator> colabDouble = new Mock<IColaborator>();
        colabDouble.Setup(p => p.getName()).Returns(NOME);

        Holiday holiday = new Holiday(colabDouble.Object); // SUT/OUT

        // act
        string nameResult = holiday.getName();

        // assert
        Assert.Equal(NOME, nameResult);
    }

}