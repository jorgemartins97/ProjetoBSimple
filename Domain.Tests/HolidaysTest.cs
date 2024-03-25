using Domain.interfaces;

namespace Domain.Tests
{
    public class HolidaysTest
    {

        [Fact]
        public void AddHolidays_ReturnsNewHolidays()
        {
            // Arrange
            var mockHolidayFactory = new Mock<IHolidayFactory>();
            var mockColaborator = new Mock<IColaborator>();
            var mockHoliday = new Mock<IHoliday>();

            mockHolidayFactory.Setup(f => f.NewHolidays(It.IsAny<IColaborator>())).Returns(mockHoliday.Object);

            var holiday = new Holidays();

            // Act
            holiday.AddHolidays(mockHolidayFactory.Object, mockColaborator.Object);

            
        }

    [Fact]
        public void GetHolidayPeriodsForColaborator_Should_Return_CorrectHolidayPeriods_ForGivenColaboratorAndDateRange()
        {
            // Arrange
            var colabDouble = new Mock<IColaborator>().Object;
            var startDate = new DateOnly(2024, 1, 1);
            var endDate = new DateOnly(2024, 12, 31);
            var hfactory = new Mock<IHolidayFactory>();
 
            // Criando alguns feriados conhecidos
            var holiday1 = new Mock<IHoliday>();
            var holiday2 = new Mock<IHoliday>();
 
            // Definindo comportamento dos feriados
            var periods1 = new List<IHolidayPeriod>
    {
        new HolidayPeriod(startDate, startDate.AddDays(5)),
        new HolidayPeriod(startDate.AddDays(20), startDate.AddDays(25)) // Segundo período de férias
    };
            holiday1.Setup(h => h.GetHolidayPeriodsForColaborator(startDate, endDate))
                    .Returns(periods1);
 
            var periods2 = new List<IHolidayPeriod>
    {
        new HolidayPeriod(startDate.AddDays(10), startDate.AddDays(15))
    };
            holiday2.Setup(h => h.GetHolidayPeriodsForColaborator(startDate, endDate))
                    .Returns(periods2);
 
            // Configurando que os feriados pertencem ao colaborador
            holiday1.Setup(h => h.HasColaborador(colabDouble)).Returns(true);
            holiday2.Setup(h => h.HasColaborador(colabDouble)).Returns(true);
 
            // Configurando a fábrica de feriados para retornar os feriados criados
            hfactory.SetupSequence(h => h.NewHolidays(colabDouble)).Returns(holiday1.Object).Returns(holiday2.Object);
 
            // Criando instância de Holidays
            var holidays = new Holidays();
 
            // Adicionando feriados à instância de Holidays
            holidays.AddHolidays(hfactory.Object, colabDouble);
 
            // Act
            var holidayPeriods = holidays.GetHolidayPeriodsForColab(startDate, endDate, colabDouble);
 
            // Assert
            Assert.NotNull(holidayPeriods);
            Assert.Equal(2, holidayPeriods.Count);
        }

     [Fact]
        public void GetColaboratorsWithHolidayGreaterThanXDays_Should_Return_CorrectColaborators()
        {
            // Arrange
            var daysThreshold = 5; // Defina o limite de dias
            var collaborator1 = new Mock<IColaborator>().Object;
            var collaborator2 = new Mock<IColaborator>().Object;
            var collaborator3 = new Mock<IColaborator>().Object;
            var hfactory = new Mock<IHolidayFactory>();
 
            var holiday1 = new Mock<IHoliday>();
            var holiday2 = new Mock<IHoliday>();
            var holiday3 = new Mock<IHoliday>();
 
            // Defina o comportamento dos feriados mockados
            holiday1.Setup(h => h.GetColaboratorsWithHolidaysLongerThan(daysThreshold)).Returns(collaborator1);
            holiday2.Setup(h => h.GetColaboratorsWithHolidaysLongerThan(daysThreshold)).Returns(collaborator2);
            holiday3.Setup(h => h.GetColaboratorsWithHolidaysLongerThan(daysThreshold)).Returns(collaborator3); // Agora este feriado retornará um colaborador válido
 
            hfactory.SetupSequence(h => h.NewHolidays(It.IsAny<IColaborator>())).Returns(holiday1.Object).Returns(holiday2.Object).Returns(holiday3.Object);
 
            var holidaysManager = new Holidays();
 
            // Adicione os feriados mockados à instância de Holidays
            holidaysManager.AddHolidays(hfactory.Object, collaborator1);
            holidaysManager.AddHolidays(hfactory.Object, collaborator2);
            holidaysManager.AddHolidays(hfactory.Object, collaborator3);
 
            // Act
            var result = holidaysManager.GetColaboratorsWithHolidaysLongerThanXDays(daysThreshold);
 
            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Contains(collaborator1, result);
            Assert.Contains(collaborator2, result);
            Assert.Contains(collaborator3, result);
        }
}
}