using System;

namespace DomainLayer
{
    public static class SystemTime
    {
        private static Func<DateTime> _systemClock = RealtimeClock;

        public static DateTime Now
        {
            get { return _systemClock(); }
        }

        public static void SetClock(Func<DateTime> newClock = null)
        {
            if (newClock != null)
            {
                _systemClock = newClock;
            }
            else
            {
                _systemClock = RealtimeClock;
            }
        }

        public static void ResetClock()
        {
            _systemClock = RealtimeClock;
        }

        private static DateTime RealtimeClock()
        {
            return DateTime.Now;
        }
    }
}