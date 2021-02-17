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

        public static void Init(Func<DateTime> clock = null)
        {
            if (clock != null)
            {
                _systemClock = clock;
            }
        }

        private static DateTime RealtimeClock()
        {
            return DateTime.Now;
        }
    }
}