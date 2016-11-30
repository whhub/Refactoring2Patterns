namespace CodingPeasantHotelClock
{
    public class PhoneClock
    {
        private HotelWorldClockSystem _hotelWorldClockSystem;
        private readonly int _utcOffset;

        public PhoneClock(int utcOffset)
        {
            _utcOffset = utcOffset;
        }

        public HotelWorldClockSystem HotelWorldClockSystem
        {
            set { _hotelWorldClockSystem = value; }
        }

        public void SetTime(int time)
        {
            var utcZeroTime = time - _utcOffset;
            foreach (var clock in _hotelWorldClockSystem.Clocks)
            {
                clock.UtcZeroTime = utcZeroTime;
            }
        }
    }
}