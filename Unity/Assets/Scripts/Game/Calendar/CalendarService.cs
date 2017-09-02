using System;

namespace Game.Calendar
{
    class CalendarService : ICalendarService
    {
        public PlayState PlayState { get; }

        public CalendarService(PlayState playState)
        {
            PlayState = playState;
        }

        public event EventHandler NewDay;

        public void NextDay()
        {
            PlayState.Day++;
            if (PlayState.Day > 7)
            {
                PlayState.Day = 1;
            }

            PlayState.Date++;
            if (PlayState.Date > GetDaysInMonth(PlayState.Year, PlayState.Month))
            {
                PlayState.Date = 1;
                PlayState.Month++;
            }

            if (PlayState.Month > 12)
            {
                PlayState.Month = 1;
                PlayState.Year++;
            }

            OnNewDay();
        }

        private readonly string[] _dayLookup = { "", "월", "화", "수", "목", "금", "토", "일" };
        public string GetDayText()
        {
            return _dayLookup[PlayState.Day];
        }

        private static bool IsLeapYear(int year)
        {
            if (year % 4 != 0)
            {
                return false;
            }
            if (year % 100 != 0)
            {
                return true;
            }
            if (year % 400 != 0)
            {
                return false;
            }
            return true;
        }

        private static int GetDaysInMonth(int year, int month)
        {
            if (month == 2)
            {
                return IsLeapYear(year) ? 29 : 28;
            }
            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                return 30;
            }
            return 31;
        }

        public void Genesis()
        {
            PlayState.Year = 625;
            PlayState.Month = 1;
            PlayState.Date = 1;
            PlayState.Day = 2;

            OnNewDay();
        }

        protected virtual void OnNewDay()
        {
            NewDay?.Invoke(this, EventArgs.Empty);
        }
    }
}