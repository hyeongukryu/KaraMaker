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

                    // 추출
                    last().ChangeKeys.AddRange(schedule.ChangeKeys);
                    last().ChangeAmounts.AddRange(schedule.ChangeAmounts);
                    var bracket = GetBracket(schedule);
                    ApplyBracketAdvantage(last().ChangeAmounts, bracket * schedule.BracketAdvantage);

                    last().ChangeKeys.Add("Gold");
                    last().ChangeAmounts.Add(gold);
                    totalGold += gold;

                    PlayState.AddScheduleCount(schedule.Key);
                }
                else
                {
                    eligible = false;
                    push(GameConfiguration.Root.FindByKey(schedule.DayFailDialogKey));

                    // 추출
                    last().ChangeKeys.AddRange(schedule.ChangeKeys);
                    last().ChangeAmounts.AddRange(schedule.ChangeAmounts);
                    var bracket = GetBracket(schedule);
                    ApplyBracketAdvantage(last().ChangeAmounts, bracket * schedule.BracketAdvantage);

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

        public int GoldChanges(Entity schedule)
        {
            if (schedule.GoldChanges == null)
            {
                return 0;
            }
            return schedule.GoldChanges.Max() * 11;
        }
    }
}