using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingPeasantHotelClock
{
    public class PhoneClock
    {
        public PhoneClock(int utcOffset)
        {
            _utcOffset = utcOffset;
        }

        //TODO-Working-on: Set time to multiple city clocks
        private CityClock _cityClock;
        private int _utcOffset;

        public CityClock CityClock
        {
            set { _cityClock = value; }
        }

        public void SetTime(int time)
        {
            _cityClock.UtcZeroTime = time - _utcOffset;
        }
    }
}
