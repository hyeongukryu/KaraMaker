using System;
using Contents;
using UnityEngine.VR.WSA;

namespace Loading.HardcodedLoaders
{
    partial class HardcodedLoader
    {
        public void LoadEndings()
        {
            Action<int, string, string, int> addEnding = (number, key, name, priority) =>
            {
                var e = new Entity
                {
                    Key = key,
                    EndingNumber = number,
                    DisplayName = name,
                    EndingPriority = priority
                };
                AddEntity(e);
            };

            var index = 0;
            addEnding(++index, "Ending1", "왕", 5);
            addEnding(++index, "Ending2", "변호사", 5);
            addEnding(++index, "Ending3", "변호사?", 5);
            addEnding(++index, "Ending4", "신부", 5);
            addEnding(++index, "Ending5", "파일럿", 5);
            addEnding(++index, "Ending6", "의사", 5);
            addEnding(++index, "Ending7", "마피아", 5);
            addEnding(++index, "Ending8", "마피아 (스페셜)", 5);
            addEnding(++index, "Ending9", "현상금 사냥꾼", 5);
            addEnding(++index, "Ending10", "야쿠자", 5);
            addEnding(++index, "Ending11", "스파이", 5);
            addEnding(++index, "Ending12", "기사", 5);
            addEnding(++index, "Ending13", "드래곤 연구가", 6);
            addEnding(++index, "Ending14", "마법소녀", 6);
            addEnding(++index, "Ending15", "마법사", 6);
            addEnding(++index, "Ending16", "괴도", 6);
            addEnding(++index, "Ending17", "락 가수", 4);
            addEnding(++index, "Ending18", "아이돌", 4);
            addEnding(++index, "Ending19", "카메라맨", 4);
            addEnding(++index, "Ending20", "사진사", 4);
            addEnding(++index, "Ending21", "부호", 7);
            addEnding(++index, "Ending22", "카지노 오너", 7);
            addEnding(++index, "Ending23", "요리사", 8);
            addEnding(++index, "Ending24", "마왕 벨제부브", 2);
            addEnding(++index, "Ending25", "칠복신", 2);
            addEnding(++index, "Ending26", "포세이돈", 2);
            addEnding(++index, "Ending27", "텐구", 2);
            addEnding(++index, "Ending28", "청행등", 2);
            addEnding(++index, "Ending29", "드라큘라", 2);
            addEnding(++index, "Ending30", "영어선생", 9);
            addEnding(++index, "Ending31", "벨보이", 9);
            addEnding(++index, "Ending32", "바텐더", 9);
            addEnding(++index, "Ending33", "농구선수", 9);
            addEnding(++index, "Ending34", "평사원", 1);
            addEnding(++index, "Ending35", "평사원?", 1);
            addEnding(++index, "Ending36", "백수", 3);
            addEnding(index, "EndingDefault", "백수", 999);
        }
    }
}
