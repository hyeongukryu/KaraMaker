using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class CalendarMonthShower : MonoBehaviour
    {
        private int month;

        private void Update()
        {
            month = DayManager.Month;

            GetComponent<Text>().text = month.ToString();
        }
    }
}