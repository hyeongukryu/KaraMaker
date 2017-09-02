using Contents;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ending
{
    class EndingSceneManager : MonoBehaviour
    {
        private void Start()
        {
            EndingArtwork = GameObject.Find("EndingArtwork").GetComponent<Image>();
            DialogText = GameObject.Find("DialogText").GetComponent<Text>();
            // PortraitBodyImage = GameObject.Find("Speaker").GetComponent<Image>();
            // PortraitFaceImage = GameObject.Find("Face").GetComponent<Image>();
            // PortraitDressImage = GameObject.Find("Dress").GetComponent<Image>();
            BackgroudImage = GameObject.Find("Background").GetComponent<Image>();
            NextButton = GameObject.Find("DialogArea").GetComponent<Button>();
            // YesButton = GameObject.Find("YesButton").GetComponent<Button>();
            // NoButton = GameObject.Find("NoButton").GetComponent<Button>();

            StatusService = new StatusService(RootState.PlayState);
            EndingService = new EndingService(RootState.PlayState, StatusService);

            RootState.PlayState.ActiveEntity = EndingService.SelectEnding();
        }

        public IStatusService StatusService { get; set; }
        public IEndingService EndingService { get; set; }

        public Text DialogText { get; set; }
        // public Image PortraitFaceImage { get; set; }
        // public Image PortraitDressImage { get; set; }
        // public Image PortraitBodyImage { get; set; }
        public Image EndingArtwork { get; set; }
        public Image BackgroudImage { get; set; }
        public Button NextButton { get; set; }
        // public Button YesButton { get; set; }
        // public Button NoButton { get; set; }

        private void Update()
        {
            if (RootState.PlayState?.ActiveEntity == null)
            {
                SceneManager.LoadScene("Loading");
                return;
            }

            var e = RootState.PlayState.ActiveEntity;

            DialogText.text = "END " + e.EndingNumber + ". " + e.DisplayName;

            /*
            KaraResources.LoadSprite(PortraitFaceImage, e, n => n.PortraitFaceImage);
            KaraResources.LoadSprite(PortraitBodyImage, e, n => n.PortraitBodyImage);
            KaraResources.LoadSprite(PortraitDressImage, e, n => n.PortraitDressImage);
            KaraResources.LoadSprite(BackgroudImage, RootState.PlayState, p => p.BackgroundImage);
            */

            KaraResources.LoadSprite(EndingArtwork, RootState.PlayState, p => "EndingArtworks/" + e.EndingNumber);

            var yesNo = e.ClickedYesKey != null;
            NextButton.interactable = !yesNo;
            // YesButton.gameObject.SetActive(yesNo);
            // NoButton.gameObject.SetActive(yesNo);
        }

        public void DialogNext()
        {
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
