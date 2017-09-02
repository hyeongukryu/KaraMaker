using Game;
using UnityEngine.UI;

namespace Main
{
    partial class MainSceneManager
    {
        private void UpdateControlSubsystem()
        {
            if (!ActivateIfAndOnlyIfRouteMatches(ControlSubsystem, null))
            {
                return;
            }

            GetComponent<Button>("TalkControlButton").interactable = !RootState.PlayState.TalkedToday;
        }
    }
}