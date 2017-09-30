using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    partial class MainSceneManager
    {
        public List<GameObject> StatusIndicators { get; set; } = new List<GameObject>();
        public List<float> StatusIndicatorBarOriginals { get; set; } = new List<float>();

        public string[] StatusIndicatorKeys { get; set; } =
        {
            "EffectiveHealth", "EffectiveStrength", "EffectiveIntelligence", "EffectiveElegance", "EffectiveCharm",
            "EffectiveMorality", "EffectiveReligiosity", "EffectiveSin", "EffectiveCharacter", "EffectiveStress",
            "EffectiveCombat", "EffectiveAttack", "EffectiveDefend", "EffectiveMagic", "EffectiveSpell",
            "EffectiveAntispell", "EffectiveCourtesy", "EffectiveArt", "EffectiveTalk", "EffectiveCooking",
            "EffectiveCleaning", "EffectivePersonality", "CombatFame", "MagicFame", "SocialFame", "HouseworkFame"
        };

        public string[] StatusIndicatorDisplayNames { get; set; } =
        {
            "체력", "근력", "지능", "기품", "매력",
            "도덕성", "신앙", "인과", "감수성", "스트레스",
            "전투기술", "공격력", "방어력", "마법기술", "마력",
            "항마력", "예의범절", "예술", "화술", "요리",
            "청소세탁", "성품",
            "전사평가", "마법평가", "사교평가", "가사평가"
        };

        private void StartStatusesSubsystem()
        {
            MakeAllStatusesPanels();
        }

        private void MakeAllStatusesPanels()
        {
            var makeStatusesPanel = new Action<string, int>((panelName, count) =>
            {
                var panel = GameObject.Find(panelName);
                var first = GetChildGameObject(panel, "StatusIndicator");
                StatusIndicators.Add(first);
                StatusIndicatorBarOriginals.Add(((RectTransform)first.transform).rect.size.x);
                for (var i = 1; i < count; i++)
                {
                    var last = StatusIndicators.Last();
                    var next = Instantiate(last, last.transform.parent);
                    next.transform.localPosition += new Vector3(0, -50);
                    StatusIndicators.Add(next);
                    StatusIndicatorBarOriginals.Add(((RectTransform)next.transform).rect.size.x);
                }
            });

            makeStatusesPanel("StatusesPanelA", 10);
            makeStatusesPanel("StatusesPanelB", 6);
            makeStatusesPanel("StatusesPanelC", 6);
            makeStatusesPanel("StatusesPanelD", 4);
        }

        private void UpdateStatusesSubsystem()
        {
            if (!ActivateIfAndOnlyIfRouteMatches(StatusesSubsystem, "Statuses"))
            {
                return;
            }

            for (var i = 0; i < StatusIndicators.Count; i++)
            {
                var displayName = StatusIndicatorDisplayNames[i];
                var value = StatusService.GetRealValue(StatusIndicatorKeys[i]);
                var e = StatusService.Get(StatusIndicatorKeys[i]).Entity;
                var progress =
                    (double)(StatusService.GetFixedValue(StatusIndicatorKeys[i]) - e.Min) / (e.Max - e.Min);

                var si = StatusIndicators[i];

                GetComponent<Text>(si, "StatusName").text = displayName;
                GetComponent<Text>(si, "StatusValue").text = value.ToString("F1");

                var childSize = StatusIndicatorBarOriginals[i];
                var childRt = (RectTransform)GetChildGameObject(si, "StatusBar").transform;
                childRt.offsetMax = new Vector2((float)(childSize * ((progress - 1.0) * 0.5)), childRt.offsetMax.y);
            }
        }
    }
}