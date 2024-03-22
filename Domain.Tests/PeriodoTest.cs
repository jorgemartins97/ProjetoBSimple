namespace Domain.Tests
{
    public class PeriodoTest
    {
        public static readonly object [][] CorrectPeriodCasesTest1 = [
        [new DateOnly(2023, 12, 01), new DateOnly(2024, 12, 01)],
        [new DateOnly(2024, 12, 10), new DateOnly(2024, 12, 12)]
        ];

        [Theory, MemberData(nameof(CorrectPeriodCasesTest1))]

        public void WhenPassingCorrectPeriod_ThenFormacaoIsInstantiated(DateOnly dataInicio, DateOnly dataFim)
        {
            new Periodo(dataInicio, dataFim);
        }

        public static readonly object [][] IncorrectPeriodCasesTest2 = [
            [new DateOnly(2023, 12, 01), new DateOnly(2022, 12, 01)],
            [new DateOnly(2024, 12, 10), new DateOnly(2024, 12, 09)]
        ];
        [Theory, MemberData(nameof(IncorrectPeriodCasesTest2))]

        public void WhenPassingInvalidPeriod_ThenThrowsexception(DateOnly dataInicio, DateOnly dataFim)
        {
            // assert
            Assert.Throws<ArgumentException>(() =>
                //act
                new Periodo(dataInicio, dataFim)
                );
        }
    }

}