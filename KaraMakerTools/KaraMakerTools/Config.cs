using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace KaraMakerTools
{
    class Config : IConfig
    {
        private string _googleSheetKey;

        public string GoogleSheetsKey
        {
            get
            {
                while (_googleSheetKey == null)
                {
                    Console.WriteLine("GoogleSheetsKey 입력");
                    _googleSheetKey = Console.ReadLine()?.Trim();
                }
                return _googleSheetKey;
            }
        }

        public IEnumerable<Tuple<string, string>> SheetNameAndKeyTuples { get; } = new List<Tuple<string, string>>
        {
            Tuple.Create("애니메이션", "Animation"),
            Tuple.Create("대화", "Talk"),
            Tuple.Create("스케줄", "Schedule"),
            Tuple.Create("대사", "Dialog"),
            Tuple.Create("아이템", "Item"),
            Tuple.Create("캐릭터 상태", "Status"),
            Tuple.Create("아키텍처", "Architecture"),
            Tuple.Create("기본 형식", "Type"),
            Tuple.Create("상점", "Shop"),
            Tuple.Create("축제", "Festival")
        };

        public string CipherKey { get; } = "고맙습니다.";
    }
}
