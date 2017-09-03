using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Contents;
using UnityEngine;

namespace Loading.HardcodedLoaders
{
    partial class HardcodedLoader
    {
        private void LoadSchedules()
        {
            LoadWorks();
            LoadEducations();
            LoadRests();
        }

        private void AddRest(string key, string displayName, string probModel, string statusUpdater,
            int stressChange, int goldChange,
            string begin, string success, string end)
        {
            stressChange *= GameConfiguration.RealToFixed;
            goldChange *= GameConfiguration.RealToFixed;
            var e = new Entity
            {
                IsRestSchedule = true,
                Key = key,
                DisplayName = displayName,
                ProbModel = probModel,
                StatusUpdater = statusUpdater,
                ChangeKeys = new List<string> { "Stress" },
                ChangeAmounts = new List<int> { stressChange },
                GoldChanges = new List<int> { goldChange },
                BeginSeriesDialogKey = begin,
                EndSeriesDialogKey = new List<string> { end },
                EndSeriesThresholds = new List<double> { 1.0 },
                DaySuccessDialogKey = success
            };
            AddEntity(e);
        }

        private void LoadRests()
        {
            AddRest("Rest", "자유 행동", "ScheduleProbSuccess", "ListStatusUpdater", -5, 0, "RestBegin", "RestSuccess", "RestEnd");
            AddRest("Vacation", "바캉스", "ScheduleProbSuccess", "ListStatusUpdater", -10, -20, "VacationBegin", "VacationSuccess", "VacationEnd");
        }

        private void LoadEducations()
        {

        }

        private void AddWork(string key, string displayName,
            int minAge, string relatedStatus,
            string probModel, string statusUpdater,
            int stressChange,
            List<string> changeKeys, List<double> changeAmounts,
            List<int> goldChanges, int bracketSize)
        {
            changeKeys.Add("Stress");
            changeAmounts.Add(stressChange);
            for (var i = 0; i < goldChanges.Count; i++)
            {
                goldChanges[i] *= GameConfiguration.RealToFixed;
            }
            for (var i = 0; i < changeAmounts.Count; i++)
            {
                changeAmounts[i] *= GameConfiguration.RealToFixed;
            }
            if (changeKeys.Count != changeAmounts.Count)
            {
                Debug.LogError("changeKeys.Count != changeAmounts.Count");
            }
            var e = new Entity
            {
                IsWorkSchdule = true,
                MinimumAge = minAge,
                ScheduleRelatedStatusKey = relatedStatus,
                Key = key,
                DisplayName = displayName,
                ProbModel = probModel,
                StatusUpdater = statusUpdater,
                ChangeKeys = changeKeys,
                ChangeAmounts = changeAmounts.Select(d => (int)d).ToList(),
                GoldChanges = goldChanges,
                BeginSeriesDialogKey = key + "Begin",
                EndSeriesDialogKey = new List<string> { key + "EndA", key + "EndB", key + "EndC", },
                EndSeriesThresholds = new List<double> { 1.0, 0.5, 0 },
                DaySuccessDialogKey = key + "Success",
                DayFailDialogKey = key + "Fail",
                BracketAdvantage = 0,
                BracketSize = bracketSize
            };
            AddEntity(e);
        }

        private void LoadWorks()
        {
            AddWork("Housework", "집안일", 12, "EffectiveHealth",
                "ScheduleProbModel50", "ListStatusUpdater", 1,
                new List<string> { "Cooking", "Cleaning", "Character" },
                new List<double> { 0.5, 0.5, -1 },
                new List<int> { 1, 1, 1, 1, 1 }, 10);
            AddWork("Parenting", "보모", 12, "EffectiveHealth",
                "ScheduleProbModel50", "ListStatusUpdater", 3,
                new List<string> { "Personality", "Character", "Charm" },
                new List<double> { 0.5, 1, -1 },
                new List<int> { 12, 15, 18, 21, 24 }, 10);
            AddWork("Hotel", "호텔", 12, "EffectiveHealth",
                "ScheduleProbModel50", "ListStatusUpdater", 2,
                new List<string> { "Cleaning", "Talk", "Combat" },
                new List<double> { 0.5, 0.5, -0.5 },
                new List<int> { 10, 12, 14, 16, 18 }, 10);
            AddWork("Farm", "농장", 12, "EffectiveHealth",
                "ScheduleProbModel50", "ListStatusUpdater", 3,
                new List<string> { "Health", "Strength", "Elegance" },
                new List<double> { 1, 1, -1 },
                new List<int> { 20, 24, 28, 32, 36 }, 10);
            AddWork("Church", "성당", 12, "EffectiveReligiosity",
                "ScheduleProbModel50", "ListStatusUpdater", 1,
                new List<string> { "Religiosity", "Morality", "Sin" },
                new List<double> { 2, 1, -1 },
                new List<int> { 4, 5, 6, 7, 8 }, 10);
            AddWork("Shrine", "신사", 12, "EffectiveReligiosity",
                "ScheduleProbModel50", "ListStatusUpdater", 2,
                new List<string> { "Sin" },
                new List<double> { 2 },
                new List<int> { 8, 11, 14, 17, 20 }, 10);
            AddWork("Mine", "광부", 13, "EffectiveStrength",
                "ScheduleProbModel50", "ListStatusUpdater", 4,
                new List<string> { "Strength", "Elegance", "Cleaning" },
                new List<double> { 2, -1, -0.5 },
                new List<int> { 24, 28, 32, 36, 40 }, 10);
            AddWork("Salon", "미용실", 13, "EffectiveCharacter",
                "ScheduleProbModel50", "ListStatusUpdater", 3,
                new List<string> { "Character", "Elegance", "Strength" },
                new List<double> { 1, 1, -1 },
                new List<int> { 20, 24, 28, 32, 36 }, 10);
            AddWork("Delivery", "택배", 14, "EffectiveStrength",
                "ScheduleProbModel50", "ListStatusUpdater", 3,
                new List<string> { "Health", "Elegance" },
                new List<double> { 2, -1 },
                new List<int> { 13, 16, 19, 21, 24 }, 10);
            AddWork("Hunter", "사냥꾼", 14, "EffectiveIntelligence",
                "ScheduleProbModel50", "ListStatusUpdater", 3,
                new List<string> { "Health", "Combat", "Sin", "Elegance", "Personality" },
                new List<double> { 1, 1, 0.5, -1, -0.5 },
                new List<int> { 15, 18, 21, 24, 27 }, 10);
            AddWork("Graveyard", "묘지기", 15, "EffectiveReligiosity",
                "ScheduleProbModel50", "ListStatusUpdater", 4,
                new List<string> { "Character", "Morality", "Charm" },
                new List<double> { 1, 1, -1 },
                new List<int> { 15, 18, 21, 24, 27 }, 5);
            AddWork("Bar", "호스트바", 15, "EffectiveCharm",
                "ScheduleProbModel50", "ListStatusUpdater", 4,
                new List<string> { "Charm", "Morality", "Intelligence" },
                new List<double> { 2, -1, -0.5 },
                new List<int> { 18, 21, 24, 27, 30 }, 5);
            AddWork("Tutor", "가정 교사", 16, "EffectiveIntelligence",
                "ScheduleProbModel50", "ListStatusUpdater", 5,
                new List<string> { "Morality", "Intelligence", "Charm" },
                new List<double> { 1, 1, -1 },
                new List<int> { 20, 24, 28, 32, 36 }, 5);
            AddWork("Izakaya", "주점", 16, "EffectiveTalk",
                "ScheduleProbModel50", "ListStatusUpdater", 4,
                new List<string> { "Cooking", "Talk", "Intelligence" },
                new List<double> { 0.5, 0.5, -1 },
                new List<int> { 16, 19, 21, 24, 27 }, 5);
            AddWork("Blackfactory", "블랙 공장", 17, "",
                "ScheduleProbSuccess", "BlackfactoryStatusUpdater", 15,
                new List<string>(), new List<double>(),
                new List<int> { 50, 60, 70, 80, 90 }, 10);
        }
    }
}