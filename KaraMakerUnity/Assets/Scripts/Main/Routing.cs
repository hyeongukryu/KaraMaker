using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Contents;
using Game;
using UnityEngine;

namespace Main
{
    partial class MainSceneManager
    {
        public Stack<string> RoutingStack { get; set; } = new Stack<string>();

        public void PopRoute()
        {
            Debug.Log("PopRoute " + RootState.PlayState.Route);
            RootState.PlayState.RouteStack.Pop();
        }

        public void PushRoute(string route)
        {
            Debug.Log("PushRoute " + route);
            RootState.PlayState.RouteStack.Push(route);
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

        public void ClickedStatusesButton() => PushRoute("Statuses");

        public void ClickedScheduleButton() => PushRoute("ScheduleSelector");

        public void ClickedTalkButton() => PushRoute("TalkSelector");

        public void ClickedScheduleWorkButton()
        {
            RootState.PlayState.PendingEntities.AddRange(
                ScheduleService.BuildEntity(GameConfiguration.Root.FindByKey("Blackfactory"), 10));
            RootState.PlayState.ActiveEntity = RootState.PlayState.PendingEntities.First();
            RootState.PlayState.PendingEntities.RemoveAt(0);

            //             PopRoute();

            // TODO
            // SetRoute("ScheduleSelectorWork");
        }


        public void ClickedScheduleEducationButton() => PushRoute("ScheduleSelectorEducation");

        public void ClickedScheduleRestButton() => PushRoute("ScheduleSelectorRest");
    }
}
