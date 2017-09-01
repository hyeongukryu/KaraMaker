using System;
using Game;

namespace Contents
{
    class MainInitializer : InitializerBase
    {
        public MainInitializer(GameConfiguration gameConfiguration, PlayState playState) : base(gameConfiguration, playState)
        {
        }
        
        public override void Initialize()
        {
            InitializeCalendar();
        }

        private void InitializeCalendar()
        {
            PlayState.Year = 625;
            PlayState.Month = 1;
            PlayState.Date = 1;
            PlayState.Day = 2;
            
            PlayState.BackgroundImage = "Backgrounds/Main";
        }
    }
}
