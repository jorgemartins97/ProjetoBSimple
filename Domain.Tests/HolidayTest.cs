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
        var ex = Assert.Throws<ArgumentException>(() => new Holiday(null));
        Assert.Equal("Invalid argument: colaborator must be non null", ex.Message);
    }

    [Fact]
    public void HasColaborador_ShouldReturnTrue_WhenColaboratorEquals()
    {
        // Arrange
        var colaboratorMock = new Mock<IColaborator>();
        var holiday = new Holiday(colaboratorMock.Object);
 
        // Act
        var result = holiday.HasColaborador(colaboratorMock.Object);
 
        // Assert
        Assert.True(result);
    }
 
    [Fact]
    public void HasColaborador_ShouldReturnFalse_WhenColaboratorNotEquals()
    {
        // Arrange
        var colaboratorMock1 = new Mock<IColaborator>();
        var colaboratorMock2 = new Mock<IColaborator>();
        var holiday = new Holiday(colaboratorMock1.Object);
 
        // Act
        var result = holiday.HasColaborador(colaboratorMock2.Object);
 
        // Assert
        Assert.False(result);
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
        var actual = holiday.GetHolidayPeriodsForColaborator(startDate, endDate);
 
        // Assert
        Assert.Collection(actual,
            item => Assert.Equal(holidayPeriod1.Object, item), // Verifica se o primeiro período de férias está na lista
            item => Assert.Equal(holidayPeriod2.Object, item)); // Verifica se o segundo período de férias está na lista
        
        }

        [Fact]
        public void GetColaboratorWithHolidaysLongerThan_Should_Return_Colaborator_When_Holidays_Longer_Than_Specified() {
        
        // Arrange
        var colabDouble = new Mock <IColaborator>();
        var holiday = new Holiday(colabDouble.Object);
        var holidayPeriodFactory = new Mock<IHolidayPeriodFactory>();

        var holidayPeriod1 = new Mock<IHolidayPeriod>();

        holidayPeriodFactory.Setup(hpF => hpF.NewHolidayPeriod(It.IsAny<DateOnly>(),It.IsAny<DateOnly>())).Returns(holidayPeriod1.Object);
        holidayPeriod1.Setup(hp => hp.CalcularNumeroDias()).Returns(10);

        holiday.addHolidayPeriod(holidayPeriodFactory.Object, It.IsAny<DateOnly>(),It.IsAny<DateOnly>());
        //Act
        var cDays = holiday.GetColaboratorsWithHolidaysLongerThan(5);

        //Assert
        Assert.NotNull(cDays);
        Assert.Equal(colabDouble.Object, cDays); 
    }

    [Fact]
        public void GetColaboratorWithHolidaysLongerThan_ShouldThrowException_WhenColaboratorNull() {
        
        // Arrange
        var colabDouble = new Mock <IColaborator>();
        var holiday = new Holiday(colabDouble.Object);
        var holidayPeriodFactory = new Mock<IHolidayPeriodFactory>();

        var holidayPeriod1 = new Mock<IHolidayPeriod>();

        holidayPeriodFactory.Setup(hpF => hpF.NewHolidayPeriod(It.IsAny<DateOnly>(),It.IsAny<DateOnly>())).Returns(holidayPeriod1.Object);

        holidayPeriod1.Setup(hp => hp.CalcularNumeroDias()).Returns(5);

        holiday.addHolidayPeriod(holidayPeriodFactory.Object, It.IsAny<DateOnly>(),It.IsAny<DateOnly>());

        //Assert
        var ex = Assert.Throws<ArgumentException>(() => holiday.GetColaboratorsWithHolidaysLongerThan(5));
        Assert.Equal("Colaborator must be non-null", ex.Message);
    }

    [Fact]
    public void CalculateTotalHolidayForColaborator_ReturnsCorrectTotalDays_WhenColaboratorHasHolidays()
    {
        // Arrange
        var startDate = new DateOnly(2024, 03, 1);
        var endDate = new DateOnly(2024, 03, 10);
        var colaborator = new Mock<IColaborator>().Object;
        var holiday = new Holiday(colaborator);
 
        // Mock de períodos de férias
        var hpFactory = new Mock<IHolidayPeriodFactory>();
        var holidayPeriod1 = new Mock<IHolidayPeriod>();
        var holidayPeriod2 = new Mock<IHolidayPeriod>();
 
        // Configuração dos mocks
        hpFactory.SetupSequence(hf => hf.NewHolidayPeriod(It.IsAny<DateOnly>(), It.IsAny<DateOnly>()))
                 .Returns(holidayPeriod1.Object)
                 .Returns(holidayPeriod2.Object);
 
        holidayPeriod1.Setup(hp => hp.CalculateTotalDays(It.IsAny<DateOnly>(), It.IsAny<DateOnly>())).Returns(1); // Simula 5 dias de férias
        holidayPeriod2.Setup(hp => hp.CalculateTotalDays(It.IsAny<DateOnly>(), It.IsAny<DateOnly>())).Returns(3); // Simula 3 dias de férias
 
 
        // Adicionando os períodos de férias simulados à instância de Holiday
        holiday.addHolidayPeriod(hpFactory.Object, startDate, endDate);
        holiday.addHolidayPeriod(hpFactory.Object, startDate, endDate);
 
        // Act
        var totalDays = holiday.getDaysColaboratorHolidayPeriod(colaborator, startDate, endDate);
 
        // Assert
        Assert.Equal(4, totalDays);
    }
    
    
    

    }