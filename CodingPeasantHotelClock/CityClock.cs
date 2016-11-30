namespace CodingPeasantHotelClock
{
    public class CityClock : Clock
    {
        private int _utcZeroTime;
        public CityClock(int utcOffset)
        {
            _utcOffset = utcOffset;
        }

        public int UtcZeroTime
        {
            set { _utcZeroTime = value; }
        }

        public override int GetTime()
        {
            return (_utcZeroTime + _utcOffset + 24)%24;
        }
    }
}