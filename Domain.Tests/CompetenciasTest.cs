namespace Domain.Tests
{
    public class CompetenciasTest
    {
        [Theory]
        [InlineData("Competencia A", 1)]
        [InlineData("Competencia B", 3)]

        public void WhenPassingCorrectData_ThenCompetenciasIsInstantiated(string strDescriçao, int nivel)
        {
        new Competencias( strDescriçao, nivel);
        }

        [Theory]
        [InlineData("",4)]
        [InlineData("competencia 20", 5)]
        [InlineData("       ", 2)]
        [InlineData(null, 5)]

        public void WhenPassingInvalidDescriçao(string strDescriçao, int nivel)
        {
            // arrange

            //assert
            var desc = Assert.Throws<ArgumentException>(() => 
            
                // act
                new Competencias(strDescriçao, nivel)
            );
            Assert.Equal(desc.Message,"Invalid arguments");

        }

        [Theory]
        [InlineData("competencia", 6)]
        public void WhenPassingInvalidNivel_ThenThrowsException(string strDescriçao, int nivel)
        {
            //assert 
            var niv = Assert.Throws<ArgumentException>(() =>
                //act
                new Competencias(strDescriçao, nivel)
            );
            Assert.Equal(niv.Message,"Invalid arguments");
        }

        [Theory]
        [InlineData("",10)]
        [InlineData(null,-1)]
        [InlineData("c23",7)]
        public void WhenPassingInvalidDescriçaoAndInvalidNivel_Then(string strDescriçao, int nivel)
        {
            Assert.Throws<ArgumentException>(() => new Competencias(strDescriçao, nivel));
        }

    }

}