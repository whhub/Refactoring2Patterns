namespace CodingPeasantHotelClock
{
    public class CityClock
    {
        private int _utcZeroTime;
        private readonly int _utcOffset;

        public CityClock(int utcOffset)
        {
            _utcOffset = utcOffset;
        }

        public int Time
        {
            get { return (_utcZeroTime + _utcOffset + 24) % 24; }
        }

        public int UtcZeroTime
        {
            set { _utcZeroTime = value; }
        }
    }
}