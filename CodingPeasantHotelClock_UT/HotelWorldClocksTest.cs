using CodingPeasantHotelClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingPeasantHotelClock_UT
{
    [TestClass]
    public class HotelWorldClocksTest
    {
        [TestMethod]
        public void The_time_of_clock_London_should_be_1_after_the_phone_clock_is_set_to_9_Beijing_time()
        {
            // Arrange
            var londonClock = new LondonClock();

            // Act

            // Assert
            Assert.AreEqual(1, londonClock.Time);
        }
    }
}