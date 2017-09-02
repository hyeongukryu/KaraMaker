using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    partial class MainSceneManager
    {
        public List<GameObject> CalendarCells { get; set; } = new List<GameObject>();

        private void StartScheduleSelectorSubsystem()
        {
            MakeAllCells();
        }

        private void MakeAllCells()
        {
            var calendar = GameObject.Find("CalendarCells");

            var first = GetChildGameObject(calendar, "CalendarCell");
            CalendarCells.Add(first);

            var rectTransform = (RectTransform)first.transform;
            double width = rectTransform.rect.xMax - rectTransform.rect.xMin;
            double height = rectTransform.rect.yMax - rectTransform.rect.yMin;

            for (var y = 0; y < 6; y++)
            {
                for (var x = 0; x < 7; x++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    var next = Instantiate(first, first.transform.parent);
                    next.transform.localPosition += new Vector3((float)(width * x), (float)(-height * y));
                    CalendarCells.Add(next);

                    if (x == 5)
                    {
                        GetComponent<Text>(CalendarCells.Last(), "CalendarDate").color = new Color(0.5f, 0.5f, 0.8f);
                    }
                    if (x == 6)
                    {
                        GetComponent<Text>(CalendarCells.Last(), "CalendarDate").color = new Color(0.8f, 0.2f, 0.2f);
                    }
                }
            }
        }

        private void UpdateScheduleSelectorSubsystem()
        {
            var p = RootState.PlayState;

            if (!ActivateIfAndOnlyIf(ScheduleSelectorSubsystem, () =>
                p.Route != null && p.Route.StartsWith("ScheduleSelector")))
            {
                return;
            }

            ActivateIfAndOnlyIfRouteMatches(GameObject.Find("ScheduleSelectorMenu"), "ScheduleSelector");

            GetComponent<Text>("YearAndMonth").text = p.Year + "년  " + p.Month + "월";
            UpdateCalendar();
        }

        private void UpdateCalendar()
        {
            foreach (var c in CalendarCells)
            {
                KaraResources.LoadSprite(GetComponent<Image>(c, "CalendarIcon"), 0, n => "");
                GetComponent<Text>(c, "CalendarDate").text = "";
            }

            var p = RootState.PlayState;
            var j = p.Day - 1;
            var daysInMonth = CalendarService.GetDaysInMonth(p.Year, p.Month);
            for (var i = 1; i <= daysInMonth; i++)
            {
                GetComponent<Text>(CalendarCells[j], "CalendarDate").text = i.ToString();
                j++;
            }
        }
    }
}