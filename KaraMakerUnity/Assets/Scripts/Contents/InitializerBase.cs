using Game;

namespace Contents
{
    abstract class InitializerBase : IInitializer
    {
        public GameConfiguration GameConfiguration { get; }
        public PlayState PlayState { get; }

        public InitializerBase(GameConfiguration gameConfiguration, PlayState playState)
        {
            GameConfiguration = gameConfiguration;
            PlayState = playState;
        }

        public abstract void Initialize();
    }
}
