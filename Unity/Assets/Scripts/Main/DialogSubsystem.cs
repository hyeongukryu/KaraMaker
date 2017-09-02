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
            
            DialogSubsystem.SetActive(e?.DialogText != null);
            if (DialogSubsystem.activeInHierarchy == false)
            {
                return;
            }

            SetRoute("Dialog");

            GetComponent<Text>("DialogText").text = GetDialogText(e);
            KaraResources.LoadSprite(GetComponent<Image>("PortraitFaceImage"), e, n => n.PortraitFaceImage);
            KaraResources.LoadSprite(GetComponent<Image>("PortraitBodyImage"), e, n => n.PortraitBodyImage);
            KaraResources.LoadSprite(GetComponent<Image>("PortraitDressImage"), e, n => n.PortraitDressImage);

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

            ClearRoute();

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
                RootState.PlayState.ActiveEntity = null;
                CalendarService.NextDay();
                return;
            }
            if (e.NextKey != null)
            {
                RootState.PlayState.ActiveEntity = GameConfiguration.Root.FindByKey(e.NextKey);
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
