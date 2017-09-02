using UnityEngine;

namespace Main
{
    public class DayManager : MonoBehaviour
    {
        static public int Year;
        static public int Month;
        static public int Date;
        static public int Day;

        private void Start()
        {
            if (!(PlayerPrefs.HasKey("Year")))
            {
                PlayerPrefs.SetInt("Year", 625);
                PlayerPrefs.SetInt("Month", 5);
                PlayerPrefs.SetInt("Date", 1);
                Debug.Log("No PlayerPrefs at Year! So assign 625 \n No PlayerPrefs at Month! So assign 5 \n No PlayerPrefs at Date! So assign 1");
            }

            GetDateInfoFromPlayerPrefs();
        }

        private void Update()
        {
            OverDigit();
            CalculateDay();
        }

        private void GetDateInfoFromPlayerPrefs()
        {
            Year = PlayerPrefs.GetInt("Year");
            Month = PlayerPrefs.GetInt("Month");
            Date = PlayerPrefs.GetInt("Date");
        }

        private void OverDigit()
        {
            if (Year < 625)
            {
                Debug.Log("Something is Wrong at DayManager, Year is under 625!");
            }
            if (Date >= 31)
            {
                Month = Month + 1;
                Date = Date - 30;
            }
            if (Month > 12)
            {
                Year = Year + 1;
                Month = Month - 12;
            }
        }

        private void CalculateDay()
        {
            int DateGap;

            DateGap = 3 * Year + 2 * Month + Date - 3;

            Day = DateGap % 7;
        }
    }
}
