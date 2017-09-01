using Contents;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Basic
{
    class BasicSceneManager : MonoBehaviour
    {
        private void Start()
        {
            DialogText = GameObject.Find("DialogText").GetComponent<Text>();
            PortraitBodyImage = GameObject.Find("Speaker").GetComponent<Image>();
            PortraitFaceImage = GameObject.Find("Face").GetComponent<Image>();
            PortraitDressImage = GameObject.Find("Dress").GetComponent<Image>();
            BackgroudImage = GameObject.Find("Background").GetComponent<Image>();
            SkipButton = GameObject.Find("Skip").GetComponent<Button>();
            NextButton = GameObject.Find("DialogArea").GetComponent<Button>();
            YesButton = GameObject.Find("YesButton").GetComponent<Button>();
            NoButton = GameObject.Find("NoButton").GetComponent<Button>();
        }

        public Text DialogText { get; set; }
        public Image PortraitFaceImage { get; set; }
        public Image PortraitDressImage { get; set; }
        public Image PortraitBodyImage { get; set; }
        public Image BackgroudImage { get; set; }
        public Button SkipButton { get; set; }
        public Button NextButton { get; set; }
        public Button YesButton { get; set; }
        public Button NoButton { get; set; }
        
        private void Update()
        {
            if (RootState.PlayState == null)
            {
                SceneManager.LoadScene("Loading");
                return;
            }
            if (RootState.PlayState?.ActiveEntity == null)
            {
                SceneManager.LoadScene("Main");
                return;
            }

            var e = RootState.PlayState.ActiveEntity;

            DialogText.text = e?.DialogText ?? "";
            KaraResources.LoadSprite(PortraitFaceImage, e, n => n.PortraitFaceImage);
            KaraResources.LoadSprite(PortraitBodyImage, e, n => n.PortraitBodyImage);
            KaraResources.LoadSprite(PortraitDressImage, e, n => n.PortraitDressImage);
            KaraResources.ChangeSprite(BackgroudImage, e, n => n.ChangeBackgroundImage);

            SkipButton.gameObject.SetActive(e.SkipKey != null);

            var yesNo = e.ClickedYesKey != null;
            NextButton.interactable = !yesNo;
            YesButton.gameObject.SetActive(yesNo);
            NoButton.gameObject.SetActive(yesNo);
        }

        public void DialogSkip()
        {
            RootState.PlayState.ActiveEntity =
                GameConfiguration.Root.FindByKey(RootState.PlayState.ActiveEntity.SkipKey);
        }

        public void DialogNext()
        {
            var e = RootState.PlayState.ActiveEntity;
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
            if (e.NextKey != null)
            {
                RootState.PlayState.ActiveEntity = GameConfiguration.Root.FindByKey(e.NextKey);
            }
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
