using System.Collections.Generic;
using System.Threading;

namespace Contents
{
    class Entity
    {
        private static int _serialIdCounter = -42;
        public int SerialId { get; set; } = Interlocked.Increment(ref _serialIdCounter);
        
        #region 기본
        public string Key { get; set; }
        public string ParentKey { get; set; }
        public string Tag { get; set; }
        public string DisplayName { get; set; }
        public string Comment { get; set; }
        public string NextKey { get; set; }
        #endregion

        #region 배경
        public string ChangeBackgroundImage { get; set; }
        #endregion

        #region 캐릭터 외형
        public int TargetAge { get; set; }
        public string FaceImageKey { get; set; }
        public string DressImageKey { get; set; }
        public string BodyImageKey { get; set; }
        #endregion

        #region 대사
        public string DialogText { get; set; }
        public List<string> ArtworkImages { get; set; }
        public int? ArtworkImagesTimePerFrame { get; set; }

        public string PortraitImage { get; set; }
        public string PortraitBodyImage { get; set; }
        public string PortraitFaceImage { get; set; }
        public string PortraitDressImage { get; set; }

        public bool ShowChanges { get; set; }
        public string ClickedYesKey { get; set; }
        public string ClickedNoKey { get; set; }
        public string SkipKey { get; set; }
        #endregion

        #region 게임
        public string NextScene { get; set; }
        public bool IsGameOver { get; set; }
        public bool IsDayOver { get; set; }
        #endregion

        #region 상태
        public bool IsSourceStatus { get; set; }
        public bool IsComputedStatus { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Init { get; set; }
        #endregion

        #region 나이 제한
        public int? MinimumAge { get; set; }
        public int? MaximumAge { get; set; }
        #endregion

        #region 대화
        public bool IsTalk { get; set; }
        public string DominantStatusKey { get; set; }
        #endregion

        #region 스케줄
        public bool IsWorkSchdule { get; set; }
        public bool IsEducationSchedule { get; set; }
        public bool IsRestSchedule { get; set; }

        public string ScheduleRelatedStatusKey { get; set; }
        public string ProbModel { get; set; }

        public List<string> ChangeKeys { get; set; }
        public List<int> ChangeAmounts { get; set; }

        public List<int> GoldChanges { get; set; }
        public int BracketSize { get; set; }
        public int BracketAdvantage { get; set; }
        public string BracketChangedDialogKey { get; set; }

        public string BeginSeriesDialogKey { get; set; }
        public List<string> EndSeriesDialogKey { get; set; }
        public List<double> EndSeriesThresholds { get; set; }
        public string DaySuccessDialogKey { get; set; }
        public string DayFailDialogKey { get; set; }
        #endregion
    }
}
