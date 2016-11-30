namespace CodingPeasantHotelClock
{
    public abstract class Clock
    {
        protected int _utcOffset;
        public abstract int GetTime();
    }
}