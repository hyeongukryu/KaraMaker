using Contents;
using Game;
using Game.Appearance;
using Game.Calendar;
using Game.Random;
using Game.Talk;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    partial class MainSceneManager : MonoBehaviour
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

            StartCommonSubsystem();
            StartStatusesSubsystem();
            StartTalkSelectorSubsystem();
            StartScheduleSelectorSubsystem();

            CalendarService.Genesis();
        }

        private void BuildAllServices()
        {
            RandomService = new RandomService(RootState.PlayState);
            StatusService = new StatusService(RootState.PlayState);
            CalendarService = new CalendarService(RootState.PlayState);
            AppearanceService = new AppearanceService(RootState.PlayState, StatusService);
            TalkService = new TalkService(RootState.PlayState, StatusService, RandomService);
        }

        private void FindAllSubsystems()
        {
            DialogSubsystem = GameObject.Find("DialogSubsystem");
            CharacterSubsystem = GameObject.Find("CharacterSubsystem");
            ControlSubsystem = GameObject.Find("ControlSubsystem");
            StatusesSubsystem = GameObject.Find("StatusesSubsystem");
            TalkSelectorSubsystem = GameObject.Find("TalkSelectorSubsystem");
            ScheduleSelectorSubsystem = GameObject.Find("ScheduleSelectorSubsystem");
        }

        public IStatusService StatusService { get; set; }
        public ICalendarService CalendarService { get; set; }
        public IAppearanceService AppearanceService { get; set; }
        public ITalkService TalkService { get; set; }
        public IRandomService RandomService { get; set; }

        public GameObject DialogSubsystem { get; set; }
        public GameObject CharacterSubsystem { get; set; }
        public GameObject ControlSubsystem { get; set; }
        public GameObject StatusesSubsystem { get; set; }
        public GameObject TalkSelectorSubsystem { get; set; }
        public GameObject ScheduleSelectorSubsystem { get; set; }

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
            UpdateScheduleSelectorSubsystem();
        }

        public void Cheat()
        {
            Debug.Log("Cheat");
            CalendarService.NextYearCheat();
        }
    }
}
