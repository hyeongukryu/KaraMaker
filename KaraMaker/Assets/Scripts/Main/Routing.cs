using System;
using Game;
using UnityEngine;

namespace Main
{
    partial class MainSceneManager
    {
        public void ClearRoute()
        {
            SetRoute(null);
        }

        public void SetRoute(string route)
        {
            RootState.PlayState.Route = route;
        }

        private static bool ActivateIfAndOnlyIf(GameObject subsystem, Func<bool> predicate)
        {
            var result = predicate();
            subsystem.SetActive(result);
            return result;
        }

        private bool ActivateIfAndOnlyIfRouteMatches(GameObject subsystem, string route)
        {
            return ActivateIfAndOnlyIf(subsystem, () => RootState.PlayState.Route == route);
        }

        public void ClickedStatusesButton()
        {
            SetRoute("Statuses");
        }

        public void ClickedScheduleButton()
        {
            SetRoute("ScheduleSelector");
        }

        public void ClickedTalkButton()
        {
            SetRoute("TalkSelector");
        }
    }
}