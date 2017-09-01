using Contents;

namespace Loading
{
    abstract class LoaderBase : ILoader
    {
        public Bundle Bundle { get; }
        public GameConfiguration GameConfiguration { get; }

        public LoaderBase(Bundle bundle, GameConfiguration gameConfiguration)
        {
            Bundle = bundle;
            GameConfiguration = gameConfiguration;
        }

        public abstract void Load();
    }
}