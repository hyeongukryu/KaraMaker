using System;
using System.Collections.Generic;
using System.ComponentModel;
using Contents;

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

        private void LoadRests()
        {
            Action<string, string, string, string,
                int, int, string, string, string> addRest =
                (key, displayName, probModel, statusUpdater, stressChange, goldChange,
                    begin, success, end) =>
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
                };
            addRest("Rest", "자유 행동", "ScheduleProbSuccess", "ListStatusUpdater", -5, 0, "RestBegin", "RestSuccess", "RestEnd");
            addRest("Vacation", "바캉스", "ScheduleProbSuccess", "ListStatusUpdater", -10, -20, "VacationBegin", "VacationSuccess", "VacationEnd");
        }

        private void LoadEducations()
        {
        }

        private void LoadWorks()
        {
        }
    }
}