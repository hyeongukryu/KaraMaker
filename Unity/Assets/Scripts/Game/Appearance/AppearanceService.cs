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
            var ageBracket = StatusService.GetAgeBracket();
            PlayState.CurrentBodyImage = $"Character/Kara{ageBracket}/Body";
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