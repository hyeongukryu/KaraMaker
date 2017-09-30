using System;
using System.Collections.Generic;
using System.Linq;
using Contents;
using Game.Random;

namespace Game.Schedule
{
    class ScheduleService : IScheduleService
    {
        public PlayState PlayState { get; }
        public IStatusService StatusService { get; }
        public IRandomService RandomService { get; }

        public ScheduleService(PlayState playState, IStatusService statusService, IRandomService randomService)
        {
            PlayState = playState;
            StatusService = statusService;
            RandomService = randomService;
        }

        public int GetBracket(Entity s)
        {
            if (s.BracketSize == 0)
            {
                return 0;
            }
            var count = PlayState.GetScheduleCount(s.Key);
            var bracket = count / s.BracketSize;
            bracket = Math.Min(bracket, s.GoldChanges.Count - 1);
            return bracket;
        }

        public int GetGoldChange(Entity s)
        {
            return s.GoldChanges[GetBracket(s)];
        }

        public double GetAvility(Entity s)
        {
            if (s.ProbModel == "ScheduleProbSuccess")
            {
                return 1.0;
            }
            if (s.ProbModel == "ScheduleProbModel50")
            {
                var a = StatusService.GetRealValue(s.ScheduleRelatedStatusKey) - 50.0;
                var b = StatusService.GetRealValue(s.ScheduleRelatedStatusKey) +
                        StatusService.GetRealValue("Stress");
                var v = a / b;
                v = Math.Min(v, 1.0);
                v = Math.Max(v, 0.01);
                return v;
            }
            if (s.ProbModel == "ScheduleProbModel3")
            {
                var v = StatusService.GetRealValue(s.ScheduleRelatedStatusKey) * 3.0;
                v = Math.Min(v, 1.0);
                v = Math.Max(v, 0.01);
                return v;
            }
            return 0;
        }

        private void PrepareForChanges(Entity e)
        {
            if (e.ChangeKeys == null)
            {
                e.ChangeKeys = new List<string>();
            }
            if (e.ChangeAmounts == null)
            {
                e.ChangeAmounts = new List<int>();
            }
        }

        private Entity CloneEntityForDialog(Entity e)
        {
            var entity = new Entity
            {
                DialogText = e.DialogText,
                ArtworkImages = e.ArtworkImages,
                ArtworkImagesTimePerFrame = e.ArtworkImagesTimePerFrame,
                PortraitImage = e.PortraitImage,
                PortraitBodyImage = e.PortraitBodyImage,
                PortraitFaceImage = e.PortraitFaceImage,
                PortraitDressImage = e.PortraitDressImage,
                ShowChanges = e.ShowChanges,
                ClickedYesKey = e.ClickedYesKey,
                ClickedNoKey = e.ClickedNoKey,
                SkipKey = e.SkipKey,
                NextScene = e.NextScene,
                IsGameOver = e.IsGameOver,
                IsDayOver = e.IsDayOver,
                NextKey = e.NextKey
            };
            PrepareForChanges(entity);
            return entity;
        }

        private void ApplyBracketAdvantage(List<int> amounts, int amount)
        {
            for (var i = 0; i < amounts.Count; i++)
            {
                if (amounts[i] < 0)
                {
                    amounts[i] -= amount;
                }
                else
                {
                    amounts[i] += amount;
                }
            }
        }

        public List<Entity> BuildEntity(Entity schedule, int length)
        {
            var result = new List<Entity>();
            Action<Entity> push = e => result.Add(CloneEntityForDialog(e));
            Func<Entity> last = () => result.Last();

            if (schedule.BeginSeriesDialogKey != null)
            {
                push(GameConfiguration.Root.FindByKey(schedule.BeginSeriesDialogKey));
            }

            var totalGold = 0;
            double lastAbility = 0;
            bool eligible = schedule.IsWorkSchdule;

            for (var dayCount = 0; dayCount < length; dayCount++)
            {
                if (dayCount != 0)
                {
                    last().IsDayOver = true;
                }

                var ability = GetAvility(schedule);
                lastAbility = ability;
                var rand = RandomService.NextDouble(dayCount);
                var success = rand <= ability;
                if (success)
                {
                    push(GameConfiguration.Root.FindByKey(schedule.DaySuccessDialogKey));
                    var gold = GetGoldChange(schedule);

                    ApplyListChanges(schedule, last());
                    ApplyBlackFactoryChangesIfNeeded(schedule, last());

                    last().ChangeKeys.Add("Gold");
                    last().ChangeAmounts.Add(gold);
                    totalGold += gold;

                    PlayState.AddScheduleCount(schedule.Key);
                }
                else
                {
                    eligible = false;
                    push(GameConfiguration.Root.FindByKey(schedule.DayFailDialogKey));

                    ApplyListChanges(schedule, last());
                    ApplyBlackFactoryChangesIfNeeded(schedule, last());
                }
            }

            if (schedule.EndSeriesDialogKey != null)
            {
                for (var i = 0; i < schedule.EndSeriesDialogKey.Count; i++)
                {
                    if (schedule.EndSeriesThresholds[i] <= lastAbility)
                    {
                        push(GameConfiguration.Root.FindByKey(schedule.EndSeriesDialogKey[i]));
                        break;
                    }
                }
            }
            if (eligible)
            {
                last().ChangeKeys.Add("Gold");
                last().ChangeAmounts.Add(totalGold / 2);
            }
            last().IsDayOver = true;
            return result;
        }

        private void ApplyListChanges(Entity schedule, Entity last)
        {
            if (schedule.ChangeKeys == null)
            {
                return;
            }
            last.ChangeKeys.AddRange(schedule.ChangeKeys);
            last.ChangeAmounts.AddRange(schedule.ChangeAmounts);
            var bracket = GetBracket(schedule);
            ApplyBracketAdvantage(last.ChangeAmounts, bracket * schedule.BracketAdvantage);
        }

        public string[] BlackFactoryStatusKeys { get; set; } =
        {
            "Health", "Strength", "Intelligence", "Elegance", "Charm",
            "Morality", "Religiosity", "Sin", "Character", "Stress",
            "Combat", "Attack", "Defend", "Magic", "Spell",
            "Antispell", "Courtesy", "Art", "Talk", "Cooking",
            "Cleaning", "Personality"
        };

        private void ApplyBlackFactoryChangesIfNeeded(Entity schedule, Entity last)
        {
            if (schedule.StatusUpdater != "BlackfactoryStatusUpdater")
            {
                return;
            }

            foreach (var k in BlackFactoryStatusKeys)
            {
                var e = GameConfiguration.Root.FindByKey(k);
                if (e.Max >= 999)
                {
                    last.ChangeKeys.Add(k);
                    last.ChangeAmounts.Add(-1 * GameConfiguration.Root.RealToFixed);
                }
                else
                {
                    last.ChangeKeys.Add(k);
                    last.ChangeAmounts.Add((int)(-0.25 * GameConfiguration.Root.RealToFixed));
                }
            }
        }

        public int GoldChanges(Entity schedule)
        {
            if (schedule.GoldChanges == null)
            {
                return 0;
            }
            return schedule.GoldChanges.Max() * 11;
        }

        public List<Entity> GetAvailableSchedules(Predicate<Entity> predicate)
        {
            Predicate<Entity> isSchedule = e => e.IsWorkSchdule || e.IsEducationSchedule || e.IsRestSchedule;
            Predicate<Entity> // TODO 돈 계산
        }

        public List<Entity> GetAvailableWorks()
        {
            return GetAvailableSchedules(e => e.IsWorkSchdule);
        }

        public List<Entity> GetAvailableEducations()
        {
            return GetAvailableSchedules(e => e.IsEducationSchedule);
        }

        public List<Entity> GetAvailableRests()
        {
            return GetAvailableSchedules(e => e.IsRestSchedule);
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
    }
}