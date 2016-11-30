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
            var londonClock = new CityClock(0);
            var phoneClock = new PhoneClock(8);
            var hotelWorldClockSystem = new HotelWorldClockSystem();
            hotelWorldClockSystem.Attach(londonClock);

            // Act
            phoneClock.HotelWorldClockSystem = hotelWorldClockSystem;
            phoneClock.SetTime(9);

            // Assert
            Assert.AreEqual(1, londonClock.Time);
        }

        [TestMethod]
        public void The_time_of_clock_NewYork_should_be_20_after_the_phone_clock_is_set_to_9_Beijing_time()
        {
            // Arrage
            var newYorkClock = new CityClock(-5);
            var phoneClock = new PhoneClock(8);
            var hotelWorldClockSystem = new HotelWorldClockSystem();
            hotelWorldClockSystem.Attach(newYorkClock);

            // Act
            phoneClock.HotelWorldClockSystem = hotelWorldClockSystem;
            phoneClock.SetTime(9);

            // Assert
            Assert.AreEqual(20, newYorkClock.Time);
        }

        [TestMethod]
        public void
            The_time_of_clock_London_and_NewYork_Should_be_1_and_20_respectively_after_the_phone_clock_is_set_to_9_Beijing_time
            ()
        {
            // Arrange
            var londonClock = new CityClock(0);
            var newYorkClock = new CityClock(-5);
            var phoneClock = new PhoneClock(8);
            var hotelWorldClockSystem = new HotelWorldClockSystem();
            hotelWorldClockSystem.Attach(londonClock);
            hotelWorldClockSystem.Attach(newYorkClock);

            // Act
            phoneClock.HotelWorldClockSystem = hotelWorldClockSystem;
            phoneClock.SetTime(9);

            // Assert
            Assert.AreEqual(1, londonClock.Time);
            Assert.AreEqual(20, newYorkClock.Time);
        }
    }
}