namespace Game.Appearance
{
    class AppearanceService : IAppearanceService
    {
        public PlayState PlayState { get; }
        public IStatusService StatusService { get; }

        public AppearanceService(PlayState playState, IStatusService statusService)
        {
            PlayState = playState;
            StatusService = statusService;
        }

        public void Update()
        {
            UpdateBody();
            UpdateFace();
            UpdateDress();
        }

        private void UpdateBody()
        {
            var age = StatusService.GetFixedValue("Age");
            if (age >= 18)
            {
                age = 18;
            }
            else if (age >= 15)
            {
                age = 15;
            }
            else
            {
                age = 12;
            }
            PlayState.CurrentBodyImage = $"Character/Kara{age}/Body";
        }

        private void UpdateDress()
        {
            // TODO
            // 옷
        }

        private void UpdateFace()
        {
            // TODO
            // 상태 이상
        }
    }
}