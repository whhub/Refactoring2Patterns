using System.Collections.Generic;

namespace CodingPeasantHotelClock
{
    public class HotelWorldClockSystem
    {
        private readonly IList<CityClock> _clocks = new List<CityClock>();

        public IEnumerable<CityClock> Clocks
        {
            get { return _clocks; }
        }

        public void Attach(CityClock clock)
        {
            _clocks.Add(clock);
        }
    }
}