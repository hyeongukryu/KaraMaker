using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Contents;
using Game;
using Game.Calendar;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Main
{
    class MainSceneManager : MonoBehaviour
    {
        private void Start()
        {
            RootState.PlayState.ActiveEntity = null;

            DialogSubsystem = GameObject.Find("DialogSubsystem");
            CharacterSubsystem = GameObject.Find("CharacterSubsystem");

            StatusService = new StatusService(RootState.PlayState);
            CalendarService = new CalendarService(RootState.PlayState);
            
            new MainInitializer(GameConfiguration.Root, RootState.PlayState).Initialize();
        }


        private readonly Dictionary<string, object> _componentCache = new Dictionary<string, object>();
        private T GetComponent<T>(string objectName)
        {
            var dictionaryKey = objectName + typeof(T).FullName;
            object value;
            if (!_componentCache.TryGetValue(dictionaryKey, out value))
            {
                _componentCache[dictionaryKey] = value = GameObject.Find(objectName).GetComponent<T>();
            }
            return (T)value;
        }
        
        public IStatusService StatusService { get; set; }
        public ICalendarService CalendarService { get; set; }
        public GameObject DialogSubsystem { get; set; }
        public GameObject CharacterSubsystem { get; set; }
        
        private void Update()
        {
            if (RootState.PlayState == null)
            {
                SceneManager.LoadScene("Loading");
                RootState.FlagsState = new FlagsState { Development = true };
                return;
            }
            UpdateCommonSubsystem();
            UpdateDialogSubsystem();
        }

        private void UpdateCommonSubsystem()
        {
            UpdateBackground();
            UpdateDateIndicator();
            UpdateProfileIndicator();
        }

        private void UpdateBackground()
        {
            KaraResources.LoadSprite(GetComponent<Image>("Background"), RootState.PlayState, p => p.BackgroundKey);
        }

        private void UpdateDateIndicator()
        {
            var p = RootState.PlayState;
            GetComponent<Text>("Year").text = p.Year.ToString();
            GetComponent<Text>("Month").text = p.Month.ToString();
            GetComponent<Text>("Date").text = p.Date.ToString();
            GetComponent<Text>("Day").text = CalendarService.GetDayText();
        }

        private void UpdateProfileIndicator()
        {
            GetComponent<Text>("Age").text = StatusService.GetValue("Age").ToString();
            GetComponent<Text>("Gold").text = (StatusService.GetValue("Gold") / GameConfiguration.Root.FixedToReal).ToString();
        }

        private void UpdateDialogSubsystem()
        {
            var e = RootState.PlayState.ActiveEntity;

            DialogSubsystem.SetActive(e?.DialogText != null);
            if (DialogSubsystem.activeInHierarchy == false)
            {
                return;
            }
            
            GetComponent<Text>("DialogText").text = e?.DialogText ?? "";
            KaraResources.LoadSprite(GetComponent<Image>("PortraitFaceImage"), e, n => n.PortraitFaceImage);
            KaraResources.LoadSprite(GetComponent<Image>("PortraitBodyImage"), e, n => n.PortraitBodyImage);
            KaraResources.LoadSprite(GetComponent<Image>("PortraitDressImage"), e, n => n.PortraitDressImage);

            GetComponent<Button>("SkipButton").gameObject.SetActive(e.SkipKey != null);

            var yesNo = e.ClickedYesKey != null;
            GetComponent<Button>("DialogArea").interactable = !yesNo;
            GetComponent<Button>("YesButton").gameObject.SetActive(yesNo);
            GetComponent<Button>("NoButton").gameObject.SetActive(yesNo);
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
