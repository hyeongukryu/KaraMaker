using System;

namespace Game.Calendar
{
    interface ICalendarService
    {
        void NextDay();
        string GetDayText();
        event EventHandler NewDay;
        void Genesis();
    }
}
