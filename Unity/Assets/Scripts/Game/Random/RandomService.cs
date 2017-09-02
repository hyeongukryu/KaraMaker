namespace Game.Random
{
    class RandomService : IRandomService
    {
        public PlayState PlayState { get; }

        public RandomService(PlayState playState)
        {
            PlayState = playState;
        }

        private System.Random GetRandom(int salt)
        {
            long seed = PlayState.EpochHash + salt;
            return new System.Random((int)seed);
        }

        public int Next(int beginClosed, int endOpen, int salt)
        {
            return GetRandom(salt).Next(beginClosed, endOpen);
        }

        public int Next(int salt)
        {
            return GetRandom(salt).Next();
        }
    }
}