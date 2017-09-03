using Game;
using UnityEngine.UI;

namespace Main
{
    partial class MainSceneManager
    {
        private void StartTalkSelectorSubsystem()
        {
            CalendarService.NewDay += (sender, e) => RootState.PlayState.TalkedToday = false;
        }

        private void UpdateTalkSelectorSubsystem()
        {
            if (!ActivateIfAndOnlyIfRouteMatches(TalkSelectorSubsystem, "TalkSelector"))
            {
                return;
            }

            GetComponent<Button>("BasicTalkButton").interactable = TalkService.GetAvailableTalk("BasicTalk") != null;
            GetComponent<Button>("LectureTalkButton").interactable = TalkService.GetAvailableTalk("LectureTalk") != null;
            GetComponent<Button>("MoneyTalkButton").interactable = TalkService.GetAvailableTalk("MoneyTalk") != null;
        }

        private void RunTalk(string tag)
        {
            PopRoute();
            RootState.PlayState.TalkedToday = true;
            TalkService.RunTalk(TalkService.GetAvailableTalk(tag));
        }

        public void BasicTalk()
        {
            RunTalk("BasicTalk");
        }

        public void LectureTalk()
        {
            RunTalk("LectureTalk");
        }

        public void MoneyTalk()
        {
            RunTalk("MoneyTalk");
        }
    }
}
