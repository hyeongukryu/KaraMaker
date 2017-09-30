using System.Linq;
using Contents;
using Game;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Main
{
    partial class MainSceneManager
    {
        private void UpdateDialogSubsystem()
        {
            var e = RootState.PlayState.ActiveEntity;
            if (e?.DialogText != null && RootState.PlayState.Route != "Dialog")
            {
                PushRoute("Dialog");
            }
            if (e?.DialogText == null && RootState.PlayState.Route == "Dialog")
            {
                PopRoute();
            }
            if (!ActivateIfAndOnlyIfRouteMatches(DialogSubsystem, "Dialog"))
            {
                return;
            }
            GetComponent<Text>("DialogText").text = GetDialogText(e);
            KaraResources.LoadSprite(GetComponent<Image>("PortraitImage"), e, n => n.PortraitImage);

            GetComponent<Button>("SkipButton").gameObject.SetActive(e.SkipKey != null);

            var yesNo = e.ClickedYesKey != null;
            GetComponent<Button>("DialogArea").interactable = !yesNo;
            GetComponent<Button>("YesButton").gameObject.SetActive(yesNo);
            GetComponent<Button>("NoButton").gameObject.SetActive(yesNo);
        }

        private string GetDialogText(Entity e)
        {
            if (e?.DialogText == null)
            {
                return null;
            }
            if (e.ShowChanges)
            {
                var digest = StatusService.GetChangesDigest(e);
                if (digest.Length > 0)
                {
                    return $"{e.DialogText} ({digest})";
                }
            }
            return e.DialogText;
        }
        
        public void DialogSkip()
        {
            RootState.PlayState.ActiveEntity =
                GameConfiguration.Root.FindByKey(RootState.PlayState.ActiveEntity.SkipKey);
        }

        public void DialogNext()
        {
            var e = RootState.PlayState.ActiveEntity;
            StatusService.Commit(e);
            
            if (e.IsGameOver)
            {
                SceneManager.LoadScene("Loading");
                return;
            }
            if (e.NextScene != null)
            {
                SceneManager.LoadScene(e.NextScene);
                return;
            }
            if (e.IsDayOver)
            {
                CalendarService.NextDay();
            }
            if (e.NextKey != null)
            {
                RootState.PlayState.ActiveEntity = GameConfiguration.Root.FindByKey(e.NextKey);
                return;
            }
            if (RootState.PlayState.PendingEntities.Count > 0)
            {
                RootState.PlayState.ActiveEntity = RootState.PlayState.PendingEntities.First();
                RootState.PlayState.PendingEntities.RemoveAt(0);
                return;
            }
            RootState.PlayState.ActiveEntity = null;
        }

        public void DialogYes()
        {
            var e = RootState.PlayState.ActiveEntity;
            RootState.PlayState.ActiveEntity = GameConfiguration.Root.FindByKey(e.ClickedYesKey);
        }

        public void DialogNo()
        {
            var e = RootState.PlayState.ActiveEntity;
            RootState.PlayState.ActiveEntity = GameConfiguration.Root.FindByKey(e.ClickedNoKey);
        }
    }
}
