using Domain.interfaces;

namespace Domain.Tests;

public class HolidayTest
{

    [Fact]
    public void WhenPassingAColaborator_ThenHolidayIsInstantiated()
    {
        Mock<IColaborator> colabDouble = new Mock<IColaborator>();

        new Holiday(colabDouble.Object);

    }


    [Fact]
    public void WhenPassingNullAsColaborator_ThenThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Holiday(null));
    }

    [Fact]
        public void WhenRequestingAddHolidayPeriod_ThenReturnHolidayPeriod()
        {
            // arrange
            var doubleColaborator = new Mock<IColaborator>();
            var hpFactory = new Mock<IHolidayPeriodFactory>();
            var holiday = new Holiday(doubleColaborator.Object);

            DateOnly dataInicio = new DateOnly(2024, 7, 1);
            DateOnly dataFim = new DateOnly(2024, 7, 15);
            var holidayPeriodDouble = new Mock<IHolidayPeriod>();
 
            hpFactory.Setup(hpF => hpF.NewHolidayPeriod(dataInicio, dataFim)).Returns(holidayPeriodDouble.Object);
 
            // act
            DateOnly hpDataInicio = new DateOnly(2024, 7, 1);
            DateOnly hpDataFim = new DateOnly(2024, 7, 15);
    
            var holidayPeriod = holiday.addHolidayPeriod(hpFactory.Object, hpDataInicio, hpDataFim);
 
 
            // assert
            Assert.Equal(holidayPeriodDouble.Object, holidayPeriod);

        }
    //Obter periodos de ferias de um colaborador dentro de um intervalo de datas
    [Fact]
    public void WhenRequestingGetHolidayPeriodsForColaborator()
    {
        // Arrange
        var startDate = new DateOnly(2024, 03, 21);
        var endDate = new DateOnly(2024, 03, 22);
        var colaboratorDouble = new Mock<IColaborator>();
 
        // Mock de períodos de férias
        var hpFactory = new Mock<IHolidayPeriodFactory>();
        var holidayPeriod1 = new Mock<IHolidayPeriod>();
        var holidayPeriod2 = new Mock<IHolidayPeriod>();
 
        // Configuração dos mocks
        hpFactory.SetupSequence(hf => hf.NewHolidayPeriod(It.IsAny<DateOnly>(), It.IsAny<DateOnly>()))
                 .Returns(holidayPeriod1.Object)
                 .Returns(holidayPeriod2.Object);
 
        holidayPeriod1.Setup(hp => hp.IsValidPeriod(startDate, endDate)).Returns(true);
        holidayPeriod2.Setup(hp => hp.IsValidPeriod(startDate, endDate)).Returns(true);
 
        var holiday = new Holiday(colaboratorDouble.Object);
 
        // Adicionando os períodos de férias simulados à instância de Holiday
        holiday.addHolidayPeriod(hpFactory.Object, startDate, endDate);
        holiday.addHolidayPeriod(hpFactory.Object, startDate, endDate);
 
        // Act
        var actual = holiday.GetHolidayPeriodsForColaborator(colaboratorDouble.Object, startDate, endDate);
 
        // Assert
        Assert.Collection(actual,
            item => Assert.Equal(holidayPeriod1.Object, item), // Verifica se o primeiro período de férias está na lista
            item => Assert.Equal(holidayPeriod2.Object, item)); // Verifica se o segundo período de férias está na lista
    }

    }