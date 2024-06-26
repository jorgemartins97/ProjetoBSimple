namespace Domain.Tests;

public class ColaboradorTest
{
    [Theory]
    [InlineData("Catarina Moreira", "catarinamoreira@email.pt")]
    [InlineData("a", "catarinamoreira@email.pt")]
    [InlineData("qqqqqqqqqqwwwwwwwwwweeeeeeeeeerrrrrrrrrrtttttttttt", "catarinamoreira@email.pt")]
    public void WhenPassingCorrectData_ThenColaboradorIsInstantiated(string strName, string strEmail)
    {

        var colab = new Colaborator( strName, strEmail);

         Assert.NotNull(colab);
         Assert.Equal(strName, colab._strName);
         Assert.Equal(strEmail, colab._strEmail);
    }
    

    [Theory]
    [InlineData("", "catarinamoreira@email.pt")]
    [InlineData("abasdfsc 12", "catarinamoreira@email.pt")]
    [InlineData("kasdjflkadjf lkasdfj laksdjf alkdsfjv alkdsfjv asldkfj asldkfvj asdlkvj asdlkfvj asdlkfvj asdflkfvj asfldkjfv jasdflkvj lasf", "catarinamoreira@email.pt")]
    [InlineData(null, "catarinamoreira@email.pt")]
    public void WhenPassingInvalidName_ThenThrowsException(string strName, string strEmail)
    {
        // arrange

        // assert
        var ex = Assert.Throws<ArgumentException>(() =>
        
            // act
            new Colaborator(strName, strEmail)
        );
        Assert.Equal("Invalid arguments.", ex.Message);
    }

    [Theory]
    [InlineData("Catarina Moreira", "")]
    [InlineData("Catarina Moreira", null)]
    [InlineData("Catarina Moreira", "catarinamoreira.pt")]
    public void WhenPassingInvalidEmail_ThenThrowsException(string strName, string strEmail)
    {
        // assert
        var ex = Assert.Throws<ArgumentException>(() =>
        
            // act
            new Colaborator(strName, strEmail)
        );
        Assert.Equal("Invalid arguments.", ex.Message);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData("", null)]
    [InlineData(null, "")]
    [InlineData("", "catarinamoreira.pt")]
    public void WhenPassingInvalidNameAndInvalidEmail_Thenz(string strName, string strEmail)
    {
        Assert.Throws<ArgumentException>(() => new Colaborator(strName, strEmail));
    }
}