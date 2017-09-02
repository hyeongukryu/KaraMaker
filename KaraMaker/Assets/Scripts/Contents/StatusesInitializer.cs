using System;
using System.Collections.Generic;
using System.Linq;
using Game;

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
                yield return createIdentity("Effective" + l, () => serv.GetFixedValue(l));
            }

            yield return new ComputedStatus(getStatusByKey("CombatFame"), () =>
                serv.GetFixedValue("EffectiveCombat") +
                serv.GetFixedValue("EffectiveAttack") +
                serv.GetFixedValue("EffectiveDefend"));

            yield return new ComputedStatus(getStatusByKey("MagicFame"), () =>
                serv.GetFixedValue("EffectiveMagic") +
                serv.GetFixedValue("EffectiveSpell") +
                serv.GetFixedValue("EffectiveAntispell"));

            yield return new ComputedStatus(getStatusByKey("SocialFame"), () =>
                serv.GetFixedValue("EffectiveCourtesy") +
                serv.GetFixedValue("EffectiveArt") +
                serv.GetFixedValue("EffectiveTalk"));

            yield return new ComputedStatus(getStatusByKey("HouseworkFame"), () =>
                serv.GetFixedValue("EffectiveCooking") +
                serv.GetFixedValue("EffectiveCleaning") +
                serv.GetFixedValue("EffectivePersonality"));

            yield return new ComputedStatus(getStatusByKey("Misdeed"), () =>
                {
                    var a = serv.GetFixedValue("EffectiveStress") -
                            serv.GetFixedValue("EffectiveMorality");
                    var b = serv.GetFixedValue("EffectiveStress") -
                            serv.GetFixedValue("EffectiveReligiosity");

                    return Math.Min(a, b);
                }
            );
            yield return new ComputedStatus(getStatusByKey("Illness"), () =>
                serv.GetFixedValue("EffectiveStress") -
                serv.GetFixedValue("EffectiveHealth"));

            yield return new ComputedStatus(getStatusByKey("Age"), () => PlayState.Year - 625 + 12);
        }

        public override void Initialize()
        {
            PlayState.Statuses.AddRange(CreateAllSources());
            PlayState.Statuses.AddRange(CreateAllComputed());
        }
    }
}
