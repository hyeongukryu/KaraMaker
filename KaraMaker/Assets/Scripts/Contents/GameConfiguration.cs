using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Contents
{
    class GameConfiguration
    {
        public static GameConfiguration Root { get; private set; }

        public static void SetInstance(GameConfiguration gameConfiguration)
        {
            Root = gameConfiguration;
        }

        public List<Entity> Entities { get; set; } = new List<Entity>();

        public double FixedToReal { get; } = 0.01;
        public int RealToFixed { get; } = 100;

        public Entity FindByKey(string key)
        {
            var result = Select(e => e.Key == key).FirstOrDefault();
            if (result == null)
            {
                Debug.LogError("FindByKey " + key);
            }
            return result;
        }

        public IEnumerable<Entity> Select(Predicate<Entity> predicate) => from e in Entities
                                                                          where predicate(e)
                                                                          select e;

        public IEnumerable<Entity> WorkSchedules => Select(e => e.IsWorkSchdule);
        public IEnumerable<Entity> EducationSchedules => Select(e => e.IsEducationSchedule);
        public IEnumerable<Entity> RestSchedules => Select(e => e.IsRestSchedule);

        public IEnumerable<Entity> SourceStatuses => Select(e => e.IsSourceStatus);
        public IEnumerable<Entity> ComputedStatuses => Select(e => e.IsComputedStatus);
    }
}
