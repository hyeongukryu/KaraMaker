using UnityEngine.UI;

namespace Main
{
    partial class MainSceneManager
    {
        // private UpdateTalkSelector

        private void UpdateTalkSelectorSubsystem()
        {
            if (!ActivateIfAndOnlyIfRouteMatches(TalkSelectorSubsystem, "TalkSelector"))
            {
                return;
            }

            GetComponent<Button>("BasicTalkButton").interactable = false;
            GetComponent<Button>("LectureTalkButton").interactable = false;
            GetComponent<Button>("MoneyTalkButton").interactable = false;
        }
    }
}
