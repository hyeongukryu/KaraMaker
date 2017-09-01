namespace KaraMakerSheetTools
{
    public class Entity
    {
        public string Key { get; set; }
        public string ParentKey { get; set; }
        
        public string Tag { get; set; }
        
        public string DisplayName { get; set; }

        public int MinimumAge { get; set; }

        public int Min { get; set; }
        public int Max { get; set; }
        public int Init { get; set; }
        
        public string ProbModelKey { get; set; }

        public string ChangeKey { get; set; }
        public int ChangeAmount { get; set; }
        
        public int Gold { get; set; }
        
        public string DialogText { get; set; }
        public bool ShowChanges { get; set; }

        public string Comment { get; set; }
        
        public string ImageIdentifier { get; set; }
        public int AnimationDuration  { get; set; }

        // 스토리 진행
        public string NextKey { get; set; }
    }
}
