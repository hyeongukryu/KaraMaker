using System;
using System.Collections.Generic;
using System.Linq;
using Contents;
using Game;
using Game.Appearance;
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
            if (RootState.PlayState == null)
            {
                SceneManager.LoadScene("Loading");
                RootState.FlagsState = new FlagsState { Development = true };
                return;
            }

            RootState.PlayState.ActiveEntity = null;

            FindAllSubsystems();
            BuildAllServices();

            new MainInitializer(GameConfiguration.Root, RootState.PlayState).Initialize();

            MakeAllStatusesPanels();
        }

        private void MakeAllStatusesPanels()
        {
            var makeStatusesPanel = new Action<string, int>((panelName, count) =>
            {
                var panel = GameObject.Find(panelName);
                var first = GetChildGameObject(panel, "StatusIndicator");
                StatusIndicators.Add(first);
                StatusIndicatorBarOriginals.Add(((RectTransform)first.transform).rect.size.x);
                for (var i = 1; i < count; i++)
                {
                    var last = StatusIndicators.Last();
                    var next = Instantiate(last, last.transform.parent);
                    next.transform.localPosition += new Vector3(0, -50);
                    StatusIndicators.Add(next);
                    StatusIndicatorBarOriginals.Add(((RectTransform)next.transform).rect.size.x);
                }
            });

            makeStatusesPanel("StatusesPanelA", 10);
            makeStatusesPanel("StatusesPanelB", 6);
            makeStatusesPanel("StatusesPanelC", 6);
            makeStatusesPanel("StatusesPanelD", 4);
        }

        private void BuildAllServices()
        {
            StatusService = new StatusService(RootState.PlayState);
            CalendarService = new CalendarService(RootState.PlayState);
            AppearanceService = new AppearanceService(RootState.PlayState, StatusService);
        }

        private void FindAllSubsystems()
        {
            DialogSubsystem = GameObject.Find("DialogSubsystem");
            CharacterSubsystem = GameObject.Find("CharacterSubsystem");
            ControlSubsystem = GameObject.Find("ControlSubsystem");
            StatusesSubsystem = GameObject.Find("StatusesSubsystem");
            TalkSelectorSubsystem = GameObject.Find("TalkSelectorSubsystem");
        }

        #region 유틸리티
        public GameObject GetChildGameObject(GameObject parent, string name)
        {
            var transforms = parent.transform.GetComponentsInChildren<Transform>();
            return (from t in transforms
                    where t.gameObject.name == name
                    select t.gameObject).First();
        }

        private readonly Dictionary<string, object> _componentCache = new Dictionary<string, object>();

        private T GetComponent<T>(string objectName)
        {
            var dictionaryKey = objectName + "$" + typeof(T).FullName;
            object value;
            if (!_componentCache.TryGetValue(dictionaryKey, out value))
            {
                _componentCache[dictionaryKey] = value = GameObject.Find(objectName).GetComponent<T>();
            }
            return (T)value;
        }

        private T GetComponent<T>(GameObject gameObject, string objectName)
        {
            var dictionaryKey = gameObject.GetInstanceID() + "$" + objectName + "$" + typeof(T).FullName;
            object value;
            if (!_componentCache.TryGetValue(dictionaryKey, out value))
            {
                _componentCache[dictionaryKey] = value = GetChildGameObject(gameObject, objectName).GetComponent<T>();
            }
            return (T)value;
        }
        #endregion

        #region 능력치 설정
        public string[] StatusIndicatorKeys { get; set; } =
        {
            "EffectiveHealth", "EffectiveStrength", "EffectiveIntelligence", "EffectiveElegance", "EffectiveCharm",
            "EffectiveMorality", "EffectiveReligiosity", "EffectiveSin", "EffectiveCharacter", "EffectiveStress",
            "EffectiveCombat", "EffectiveAttack", "EffectiveDefend", "EffectiveMagic", "EffectiveSpell",
            "EffectiveAntispell", "EffectiveCourtesy", "EffectiveArt", "EffectiveTalk", "EffectiveCooking",
            "EffectiveCleaning", "EffectivePersonality", "CombatFame", "MagicFame", "SocialFame", "HouseworkFame"
        };

        public string[] StatusIndicatorDisplayNames { get; set; } =
        {
            "체력", "근력", "지능", "기품", "매력",
            "도덕성", "신앙", "인과", "감수성", "스트레스",
            "전투기술", "공격력", "방어력", "마법기술", "마력",
            "항마력", "예의범절", "예술", "화술", "요리",
            "청소세탁", "성품",
            "전사평가", "마법평가", "사교평가", "가사평가"
        };
        #endregion

        public List<GameObject> StatusIndicators { get; set; } = new List<GameObject>();
        public List<float> StatusIndicatorBarOriginals { get; set; } = new List<float>();

        public IStatusService StatusService { get; set; }
        public ICalendarService CalendarService { get; set; }
        public IAppearanceService AppearanceService { get; set; }
        public GameObject DialogSubsystem { get; set; }
        public GameObject CharacterSubsystem { get; set; }
        public GameObject ControlSubsystem { get; set; }
        public GameObject StatusesSubsystem { get; set; }
        public GameObject TalkSelectorSubsystem { get; set; }

        private void Update()
        {
            if (RootState.PlayState == null)
            {
                return;
            }

            UpdateCommonSubsystem();
            UpdateDialogSubsystem();
            UpdateCharacterSubsystem();
            UpdateStatusesSubsystem();
            UpdateControlSubsystem();
            UpdateTalkSelectorSubsystem();
        }

        private void UpdateTalkSelectorSubsystem()
        {
            if (!ActivateIfAndOnlyIfRouteMatches(TalkSelectorSubsystem, "TalkSelector"))
            {
                return;
            }
        }

        #region 라우팅
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
        #endregion

        #region 라우팅 버튼
        public void ClickedStatusesButton()
        {
            SetRoute("Statuses");
        }

        public void ClickedScheduleButton()
        {
            SetRoute("Schedule");
        }

        public void ClickedTalkButton()
        {
            SetRoute("TalkSelector");
        }
        #endregion

        private void UpdateControlSubsystem()
        {
            if (!ActivateIfAndOnlyIfRouteMatches(ControlSubsystem, null))
            {
                return;
            }
        }

        private void UpdateStatusesSubsystem()
        {
            if (!ActivateIfAndOnlyIfRouteMatches(StatusesSubsystem, "Statuses"))
            {
                return;
            }

            for (var i = 0; i < StatusIndicators.Count; i++)
            {
                var displayName = StatusIndicatorDisplayNames[i];
                var value = StatusService.GetRealValue(StatusIndicatorKeys[i]);
                var e = StatusService.Get(StatusIndicatorKeys[i]).Entity;
                var progress =
                    (double)(StatusService.GetFixedValue(StatusIndicatorKeys[i]) - e.Min) / (e.Max - e.Min);

                var si = StatusIndicators[i];

                GetComponent<Text>(si, "StatusName").text = displayName;
                GetComponent<Text>(si, "StatusValue").text = value.ToString("F1");

                var childSize = StatusIndicatorBarOriginals[i];
                var childRt = (RectTransform)GetChildGameObject(si, "StatusBar").transform;
                childRt.offsetMax = new Vector2((float)(childSize * ((progress - 1.0) * 0.5)), childRt.offsetMax.y);
            }
        }

        private void UpdateCharacterSubsystem()
        {
            AppearanceService.Update();

            KaraResources.LoadSprite(GetComponent<Image>("CharacterBody"),
                RootState.PlayState, p => p.CurrentBodyImage);
            KaraResources.LoadSprite(GetComponent<Image>("CharacterDress"),
                RootState.PlayState, p => p.CurrentDressImage);
            KaraResources.LoadSprite(GetComponent<Image>("CharacterFace"),
                RootState.PlayState, p => p.CurrentFaceImage);
        }

        private void UpdateCommonSubsystem()
        {
            UpdateBackground();
            UpdateDateIndicator();
            UpdateProfileIndicator();
        }

        private void UpdateBackground()
        {
            KaraResources.LoadSprite(GetComponent<Image>("Background"), RootState.PlayState, p => p.BackgroundImage);
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
            GetComponent<Text>("Age").text = StatusService.GetFixedValue("Age").ToString();
            GetComponent<Text>("Gold").text = StatusService.GetRealValue("Gold").ToString("F0");
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
