using CodingPeasantHotelClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingPeasantHotelClock_UT
{
    [TestClass]
    public class HotelWorldClocksTest
    {
        private HotelWorldClockSystem _hotelWorldClockSystem;
        private PhoneClock _phoneClock;

        [TestInitialize]
        public void SetUp()
        {
            _hotelWorldClockSystem = new HotelWorldClockSystem();
            _phoneClock = new PhoneClock(8);
        }

        [TestMethod]
        public void The_time_of_clock_London_should_be_1_after_the_phone_clock_is_set_to_9_Beijing_time()
        {
            // Arrange
            var londonClock = new CityClock(0);
            _hotelWorldClockSystem.Attach(londonClock);

            // Act
            _phoneClock.HotelWorldClockSystem = _hotelWorldClockSystem;
            _phoneClock.SetTime(9);

            // Assert
            Assert.AreEqual(1, londonClock.GetTime());
        }

        [TestMethod]
        public void The_time_of_clock_NewYork_should_be_20_after_the_phone_clock_is_set_to_9_Beijing_time()
        {
            // Arrage
            var newYorkClock = new CityClock(-5);
            _hotelWorldClockSystem.Attach(newYorkClock);

            // Act
            _phoneClock.HotelWorldClockSystem = _hotelWorldClockSystem;
            _phoneClock.SetTime(9);

            // Assert
            Assert.AreEqual(20, newYorkClock.GetTime());
        }

        [TestMethod]
        public void
            The_time_of_clock_London_and_NewYork_Should_be_1_and_20_respectively_after_the_phone_clock_is_set_to_9_Beijing_time
            ()
        {
            // Arrange
            var londonClock = new CityClock(0);
            var newYorkClock = new CityClock(-5);
            _hotelWorldClockSystem.Attach(londonClock);
            _hotelWorldClockSystem.Attach(newYorkClock);

            // Act
            _phoneClock.HotelWorldClockSystem = _hotelWorldClockSystem;
            _phoneClock.SetTime(9);

            // Assert
            Assert.AreEqual(1, londonClock.GetTime());
            Assert.AreEqual(20, newYorkClock.GetTime());
        }

        [TestMethod]
        public void The_time_of_the_phone_clock_should_be_set_correctly_after_its_setTime_method_is_invoked()
        {
            // Arrange

            // Act
            _phoneClock.SetTime(9);
            // Assert 
            Assert.AreEqual(9, _phoneClock.GetTime());
        }

        [TestMethod]
        public void The_time_of_clock_Moscow_should_be_5_after_the_phone_clock_is_set_to_9_Beijing_time()
        {
            // Arrange
            var moscowClock = new CityClock(4);
            _hotelWorldClockSystem.Attach(moscowClock);

            // Act
            _phoneClock.HotelWorldClockSystem = _hotelWorldClockSystem;
            _phoneClock.SetTime(9);

            // Assert
            Assert.AreEqual(5, moscowClock.GetTime()); ;
        }
    }
}