using System;
using System.Collections.Generic;
using System.Linq;
using Contents;
using Game;
using UnityEngine;

namespace Ending
{
    class EndingService : IEndingService
    {
        public PlayState PlayState { get; }
        public IStatusService StatusService { get; }

        public EndingService(PlayState playState, IStatusService statusService)
        {
            PlayState = playState;
            StatusService = statusService;
        }

        public Entity SelectEnding()
        {
            var endings = new List<Entity>();

            Action<string, Func<bool>> testEnding = (key, check) =>
            {
                if (check())
                {
                    endings.Add(GameConfiguration.Root.FindByKey(key));
                }
            };

            var gr = new Func<string, double>(k => StatusService.GetRealValue(k));

            var maximumFame = double.MinValue;
            maximumFame = Math.Max(maximumFame, gr("CombatFame"));
            maximumFame = Math.Max(maximumFame, gr("MagicFame"));
            maximumFame = Math.Max(maximumFame, gr("SocialFame"));
            maximumFame = Math.Max(maximumFame, gr("HouseworkFame"));

            testEnding("Ending1", () => maximumFame >= 350 & gr("EffectiveElegance") >= 500 & gr("EffectiveMorality") >= 500);
            testEnding("Ending2", () => maximumFame >= 300 & gr("EffectiveIntelligence") >= 500
                & gr("EffectiveIntelligence") >= gr("EffectiveReligiosity") & gr("EffectiveIntelligence") >= gr("EffectiveMorality"));
            testEnding("Ending3", () => maximumFame >= 300 & gr("EffectiveIntelligence") >= 500 & gr("EffectiveMorality") <= 100
                & gr("EffectiveIntelligence") >= gr("EffectiveReligiosity") & gr("EffectiveIntelligence") >= gr("EffectiveMorality"));
            testEnding("Ending4", () => maximumFame >= 250 & gr("EffectiveMorality") >= 800 & gr("EffectiveReligiosity") >= 800 & gr("EffectiveIntelligence") >= 150);
            testEnding("Ending5", () => maximumFame >= 250 & gr("EffectiveIntelligence") >= 300 & gr("EffectiveMorality") >= 400);
            testEnding("Ending6", () => maximumFame >= 200 & gr("EffectiveIntelligence") >= 400 & gr("EffectiveMorality") >= 400
                & gr("EffectiveMorality") >= gr("EffectiveReligiosity") & gr("EffectiveMorality") >= gr("EffectiveIntelligence"));

            testEnding("Ending7", () => gr("CombatFame") >= 350 & gr("EffectiveElegance") >= 400 & gr("EffectiveCharm") >= 300);
            testEnding("Ending8", () => gr("CombatFame") >= 350 & gr("EffectiveElegance") >= 400 & gr("EffectiveCharm") >= 300);
            testEnding("Ending9", () => gr("CombatFame") >= 300 & gr("EffectiveIntelligence") >= 400);
            testEnding("Ending10", () => gr("CombatFame") >= 300 & gr("EffectiveElegance") >= 300 & gr("EffectiveMorality") <= 200);
            testEnding("Ending11", () => gr("CombatFame") >= 200 & gr("EffectiveMorality") <= 200 & gr("EffectiveCharacter") >= 150);
            testEnding("Ending12", () => gr("CombatFame") >= 200 & gr("CombatFame") <= 300);

            testEnding("Ending13", () => gr("MagicFame") >= 350 & gr("EffectiveIntelligence") >= 300 & gr("EffectiveCharacter") >= 500);
            testEnding("Ending14", () => gr("MagicFame") >= 300 & gr("EffectiveCharm") >= 400 & gr("EffectiveMorality") >= 500 & gr("EffectiveReligiosity") >= 300);
            testEnding("Ending15", () => gr("MagicFame") >= 250 & gr("EffectiveIntelligence") >= 300 & gr("EffectiveMorality") >= 200);
            testEnding("Ending16", () => gr("MagicFame") >= 250 & gr("EffectiveIntelligence") >= 300 & gr("EffectiveMorality") <= 200);

            testEnding("Ending17", () => gr("EffectiveIntelligence") >= 300 & gr("EffectiveCharm") >= 500);
            testEnding("Ending18", () => gr("EffectiveIntelligence") <= 299 & gr("EffectiveCharm") >= 500);
            testEnding("Ending19", () => gr("EffectiveIntelligence") >= 300 & gr("EffectiveHealth") >= 300 & gr("EffectiveCharm") <= 400);
            testEnding("Ending20", () => gr("EffectiveIntelligence") <= 299 & gr("EffectiveCharm") <= 400 & gr("EffectiveCharacter") >= 500);

            testEnding("Ending21", () => gr("SocialFame") >= 350 & gr("EffectiveCharm") <= 400 & gr("EffectiveElegance") >= 500);
            testEnding("Ending22", () => gr("SocialFame") >= 300 & gr("EffectiveCharm") >= 500 & gr("EffectiveMorality") <= 200);

            testEnding("Ending23", () => gr("HouseworkFame") >= 300 & gr("EffectiveHealth") >= 200);

            testEnding("Ending24", () => gr("CombatFame") >= 350 & gr("MagicFame") >= 350 & gr("EffectiveSin") >= 500);
            testEnding("Ending25", () => gr("EffectiveSin") >= 400 & gr("SocialFame") >= 300 & gr("EffectiveMorality") >= 400 & gr("EffectiveReligiosity") >= 400);
            testEnding("Ending26", () => gr("EffectiveSin") >= 400 & gr("CombatFame") >= 300 & gr("MagicFame") >= 300 & gr("EffectiveElegance") >= 400 & gr("EffectiveCharm") >= 200);
            testEnding("Ending27", () => gr("EffectiveSin") >= 400 & gr("CombatFame") >= 300 & gr("EffectiveMorality") >= 300);
            testEnding("Ending28", () => gr("EffectiveSin") >= 400 & gr("CombatFame") >= 300 & gr("EffectiveMorality") <= 299);
            testEnding("Ending29", () => gr("EffectiveSin") >= 300);
            testEnding("Ending30", () => false);
            testEnding("Ending31", () => false);
            testEnding("Ending32", () => false);
            testEnding("Ending33", () => false);
            testEnding("Ending34", () => false);
            testEnding("Ending35", () => false);
            testEnding("Ending36", () => gr("EffectiveMorality") <= 100 & gr("EffectivePersonality") <= 50);
            testEnding("EndingDefault", () => true);

            // TODO jitter
            var result = from e in endings
                         orderby e.EndingPriority
                         select e;
            return result.First();
        }
    }
}
