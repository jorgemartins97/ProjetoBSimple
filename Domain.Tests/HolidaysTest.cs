using Domain.interfaces;

namespace Domain.Tests
{
    public class HolidaysTest
    {
        [Fact]
        public void addHolidayIntoList()
        {
            var holidayDouble = new Mock<IHoliday>();
            var holidays = new Holidays();

            holidays.AddHoliday(holidayDouble.Object);

        }
 
        [Fact]
        public void WhenPassingNullHoliday_ThenThrowsException()
        {
            var hls = new Holidays();
            Assert.Throws<ArgumentNullException>(() => hls.AddHoliday(null));
        }


    }

}