using System;
using Game;

namespace Contents
{
    class OpeningInitializer : InitializerBase
    {
        public OpeningInitializer(GameConfiguration gameConfiguration, PlayState playState) : base(gameConfiguration, playState)
        {
        }

        public override void Initialize()
        {
            PlayState.ActiveEntity = GameConfiguration.FindByKey("OpeningSequence0");
        }
    }
}
