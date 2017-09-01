using System;
using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;

namespace Contents
{
    class StatusesInitializer : InitializerBase
    {
        public StatusesInitializer(GameConfiguration gameConfiguration, PlayState playState) : base(gameConfiguration, playState)
        {
        }

        public IEnumerable<IStatus> CreateAllSources()
        {
            var sourceStatuses = GameConfiguration.SourceStatuses;
            foreach (var s in sourceStatuses)
            {
                yield return new SourceStatus(s);
            }
        }

        public IEnumerable<IStatus> CreateAllComputed()
        {
            IStatusService serv = new StatusService(PlayState);

            var sourceStatuses = GameConfiguration.SourceStatuses.ToList();
            var computedStatuses = GameConfiguration.ComputedStatuses.ToList();
            var allStatuses = sourceStatuses.Union(computedStatuses).ToList();

            var getStatusByKey = new Func<string, Entity>(
                    key => allStatuses.Where(e => e.Key == key).Select(e => e).First());

            var createIdentity = new Func<string, Func<int>, IStatus>(
                (key, computeValue) => new ComputedStatus(getStatusByKey(key), computeValue));

            var list = new[]
            {
                "Health",
                "Strength",
                "Intelligence",
                "Elegance",
                "Charm",
                "Morality",
                "Religiosity",
                "Sin",
                "Character",
                "Stress",
                "Combat",
                "Attack",
                "Defend",
                "Magic",
                "Spell",
                "Antispell",
                "Courtesy",
                "Art",
                "Talk",
                "Cooking",
                "Cleaning",
                "Personality"
            };

            foreach (var l in list)
            {
                yield return createIdentity("Effective" + l, () => serv.GetValue(l));
            }

            yield return new ComputedStatus(getStatusByKey("CombatFame"), () =>
                serv.GetValue("EffectiveCombat") +
                serv.GetValue("EffectiveAttack") +
                serv.GetValue("EffectiveDefend"));

            yield return new ComputedStatus(getStatusByKey("MagicFame"), () =>
                serv.GetValue("EffectiveMagic") +
                serv.GetValue("EffectiveSpell") +
                serv.GetValue("EffectiveAntispell"));

            yield return new ComputedStatus(getStatusByKey("SocialFame"), () =>
                serv.GetValue("EffectiveCourtesy") +
                serv.GetValue("EffectiveArt") +
                serv.GetValue("EffectiveTalk"));

            yield return new ComputedStatus(getStatusByKey("HouseworkFame"), () =>
                serv.GetValue("EffectiveCooking") +
                serv.GetValue("EffectiveCleaning") +
                serv.GetValue("EffectivePersonality"));

            yield return new ComputedStatus(getStatusByKey("Misdeed"), () =>
                {
                    var a = serv.GetValue("EffectiveStress") -
                            serv.GetValue("EffectiveMorality");
                    var b = serv.GetValue("EffectiveStress") -
                            serv.GetValue("EffectiveReligiosity");

                    return Math.Min(a, b);
                }
            );
            yield return new ComputedStatus(getStatusByKey("Illness"), () =>
                serv.GetValue("EffectiveStress") -
                serv.GetValue("EffectiveHealth"));

            yield return new ComputedStatus(getStatusByKey("Age"), () => PlayState.Year - 625 + 12);
        }

        public override void Initialize()
        {
            PlayState.Statuses.AddRange(CreateAllSources());
            PlayState.Statuses.AddRange(CreateAllComputed());
        }
    }
}
