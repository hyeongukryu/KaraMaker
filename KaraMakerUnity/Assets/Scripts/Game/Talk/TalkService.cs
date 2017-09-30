using System;
using System.Linq;
using System.Text;
using Contents;
using Game.Random;
using UnityEngine;

namespace Game.Talk
{
    class TalkService : ITalkService
    {
        public PlayState PlayState { get; }
        public IStatusService StatusService { get; }
        public IRandomService RandomService { get; }

        public TalkService(PlayState playState, IStatusService statusService, IRandomService randomService)
        {
            PlayState = playState;
            StatusService = statusService;
            RandomService = randomService;
        }

        public Entity GetAvailableTalk(string tag)
        {
            Predicate<Entity> filterTag = e => e.Tag == tag;

            var age = StatusService.GetFixedValue("Age");
            Predicate<Entity> filterAge = e => e.MinimumAge <= age && age <= e.MaximumAge;

            var balance = StatusService.GetFixedValue("Gold");
            Predicate<Entity> filterGold = e => e.GoldChanges == null || balance + e.GoldChanges.First() >= 0;

            Func<Entity, int> extractOrder = e =>
            {
                if (e.DominantStatusKey == null)
                {
                    return 0;
                }
                return StatusService.GetFixedValue(e.DominantStatusKey);
            };
            
            Func<Entity, int> tieBreaker = e => RandomService.Next(e.SerialId);

            var result = from e in GameConfiguration.Root.Entities
                         where filterTag(e) && filterAge(e) && filterGold(e)
                         orderby extractOrder(e) descending, tieBreaker(e) descending 
                         select e;

            return result.FirstOrDefault();
        }

        public void RunTalk(Entity talk)
        {
            PlayState.ActiveEntity = talk;
        }
    }
}
