using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

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
            PlayState.Epoch++;
            UpdateEpochHash();

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

        public void NextYearCheat()
        {
            var oldYear = PlayState.Year;
            while (oldYear == PlayState.Year)
            {
                NextDay();
            }
        }

        private void UpdateEpochHash()
        {
            var inputBytesA = BitConverter.GetBytes(PlayState.Epoch);
            var inputBytesB = BitConverter.GetBytes(PlayState.BeginWalltime.Ticks);
            var inputBytes = new byte[inputBytesA.Length + inputBytesB.Length];
            Array.Copy(inputBytesA, 0, inputBytes, 0, inputBytesA.Length);
            Array.Copy(inputBytesB, 0, inputBytes, inputBytesA.Length, inputBytesB.Length);

            var result = SHA256.Create().ComputeHash(inputBytes);

            long hash = 0;
            for (var i = 0; i < result.Length; i += 8)
            {
                hash += BitConverter.ToInt64(result, i);
            }

            PlayState.EpochHash = hash;
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

        public int GetDaysInMonth(int year, int month)
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

        public List<int> GetScheduleLengths()
        {
            var daysInMonth = GetDaysInMonth(PlayState.Year, PlayState.Month);
            if (daysInMonth == 28)
            {
                return new List<int> { 9, 9, 10 };
            }
            if (daysInMonth == 29)
            {
                return new List<int> { 9, 10, 10 };
            }
            if (daysInMonth == 30)
            {
                return new List<int> { 10, 10, 10 };
            }
            return new List<int> { 10, 10, 11 };
        }

        public void Genesis()
        {
            PlayState.BeginWalltime = DateTime.Now;

            PlayState.Year = 625;
            PlayState.Month = 1;
            PlayState.Date = 1;
            PlayState.Day = 2;
            PlayState.Epoch = 0;
            UpdateEpochHash();

            OnNewDay();

            Debug.Log("Genesis " + PlayState.BeginWalltime.Ticks);
        }

        protected virtual void OnNewDay()
        {
            NewDay?.Invoke(this, EventArgs.Empty);
        }
    }
}
