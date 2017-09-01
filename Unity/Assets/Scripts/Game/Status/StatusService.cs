using System.Linq;

namespace Game
{
    class StatusService : IStatusService
    {
        public PlayState PlayState { get; }

        public StatusService(PlayState playState)
        {
            PlayState = playState;
        }

        public IStatus Get(string key)
        {
            return (from s in PlayState.Statuses
                where s.Entity.Key == key
                select s).First();
        }

        public int GetValue(string key) => Get(key).Value;
    }
}