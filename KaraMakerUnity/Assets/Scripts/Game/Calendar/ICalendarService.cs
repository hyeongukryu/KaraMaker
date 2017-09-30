using System;
using System.Collections.Generic;

namespace Game.Calendar
{
    interface ICalendarService
    {
        void NextDay();
        string GetDayText();
        event EventHandler NewDay;
        void Genesis();
        int GetDaysInMonth(int year, int month);
        List<int> GetScheduleLengths();
        void NextYearCheat();
    }
}
