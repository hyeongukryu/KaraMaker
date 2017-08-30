using UnityEngine;

namespace Main
{
    [System.Serializable]
    public class AnimationInfo
    {
        public string ScheduleName;
        public int ScheduleNumber;
        public Sprite[] SuccessAni;
        public Sprite[] FailAni;
        public float IntervalTime;
    }
}