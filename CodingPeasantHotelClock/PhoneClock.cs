namespace CodingPeasantHotelClock
{
    public class PhoneClock : Clock
    {
        private HotelWorldClockSystem _hotelWorldClockSystem;
        private int _time;

        public PhoneClock(int utcOffset)
        {
            _utcOffset = utcOffset;
        }

        public HotelWorldClockSystem HotelWorldClockSystem
        {
            set { _hotelWorldClockSystem = value; }
        }

        public void SetTime(int value)
        {
            _time = value;
            if (_hotelWorldClockSystem == null) return;
            var utcZeroTime = value - _utcOffset;
            foreach (var clock in _hotelWorldClockSystem.Clocks)
            {
                clock.UtcZeroTime = utcZeroTime;
            }
        }

        public override int GetTime()
        {
            return _time;
        }
    }
}