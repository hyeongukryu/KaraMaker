using System;
using Contents;

namespace Loading.HardcodedLoaders
{
    partial class HardcodedLoader
    {
        private void LoadStatuses()
        {
            var addSourceStatus = new Action<string, string, int, int, int>((key, name, init, min, max) =>
            {
                init *= GameConfiguration.RealToFixed;
                min *= GameConfiguration.RealToFixed;
                max *= GameConfiguration.RealToFixed;
                AddEntity(new Entity
                {
                    Tag = "SourceStatus",
                    IsSourceStatus = true,
                    Key = key,
                    DisplayName = name,
                    Init = init,
                    Min = min,
                    Max = max
                });
            });

            addSourceStatus("Health", "체력", 19, 0, 999);
            addSourceStatus("Strength", "근력", 18, 0, 999);
            addSourceStatus("Intelligence", "지능", 36, 0, 999);
            addSourceStatus("Elegance", "기품", 14, 0, 999);
            addSourceStatus("Charm", "매력", 14, 0, 999);
            addSourceStatus("Morality", "도덕성", 7, 0, 999);
            addSourceStatus("Religiosity", "신앙", 10, 0, 999);
            addSourceStatus("Sin", "인과", 0, 0, 999);
            addSourceStatus("Character", "감수성", 35, 0, 999);
            addSourceStatus("Stress", "스트레스", 0, 0, 999);
            addSourceStatus("Combat", "전투 기술", 14, 0, 100);
            addSourceStatus("Attack", "공격력", 2, 0, 100);
            addSourceStatus("Defend", "방어력", 0, 0, 100);
            addSourceStatus("Magic", "마법 기술", 18, 0, 100);
            addSourceStatus("Spell", "마력", 19, 0, 100);
            addSourceStatus("Antispell", "항마력", 15, 0, 100);
            addSourceStatus("Courtesy", "예의범절", 10, 0, 100);
            addSourceStatus("Art", "예술", 25, 0, 100);
            addSourceStatus("Talk", "화술", 30, 0, 100);
            addSourceStatus("Cooking", "요리", 8, 0, 100);
            addSourceStatus("Cleaning", "청소 세탁", 10, 0, 100);
            addSourceStatus("Personality", "성품", 11, 0, 100);

            addSourceStatus("Gold", "골드", 500, 0, 9999999);

            var addComputedStatus = new Action<string, string, int, int>((key, name, min, max) =>
            {
                min *= GameConfiguration.RealToFixed;
                max *= GameConfiguration.RealToFixed;
                AddEntity(new Entity
                {
                    Tag = "ComputedStatus",
                    IsComputedStatus = true,
                    Key = key,
                    DisplayName = name,
                    Min = min,
                    Max = max
                });
            });

            addComputedStatus("EffectiveHealth", "실질 체력", 0, 999);
            addComputedStatus("EffectiveStrength", "실질 근력", 0, 999);
            addComputedStatus("EffectiveIntelligence", "실질 지능", 0, 999);
            addComputedStatus("EffectiveElegance", "실질 기품", 0, 999);
            addComputedStatus("EffectiveCharm", "실질 매력", 0, 999);
            addComputedStatus("EffectiveMorality", "실질 도덕성", 0, 999);
            addComputedStatus("EffectiveReligiosity", "실질 신앙", 0, 999);
            addComputedStatus("EffectiveSin", "실질 인과", 0, 999);
            addComputedStatus("EffectiveCharacter", "실질 감수성", 0, 999);
            addComputedStatus("EffectiveStress", "실질 스트레스", 0, 999);
            addComputedStatus("EffectiveCombat", "실질 전투 기술", 0, 100);
            addComputedStatus("EffectiveAttack", "실질 공격력", 0, 100);
            addComputedStatus("EffectiveDefend", "실질 방어력", 0, 100);
            addComputedStatus("EffectiveMagic", "실질 마법 기술", 0, 100);
            addComputedStatus("EffectiveSpell", "실질 마력", 0, 100);
            addComputedStatus("EffectiveAntispell", "실질 항마력", 0, 100);
            addComputedStatus("EffectiveCourtesy", "실질 예의범절", 0, 100);
            addComputedStatus("EffectiveArt", "실질 예술", 0, 100);
            addComputedStatus("EffectiveTalk", "실질 화술", 0, 100);
            addComputedStatus("EffectiveCooking", "실질 요리", 0, 100);
            addComputedStatus("EffectiveCleaning", "실질 청소 세탁", 0, 100);
            addComputedStatus("EffectivePersonality", "실질 성품", 0, 100);
            addComputedStatus("CombatFame", "전사 평가", 0, 999);
            addComputedStatus("MagicFame", "마법 평가", 0, 999);
            addComputedStatus("SocialFame", "사교 평가", 0, 999);
            addComputedStatus("HouseworkFame", "가사 평가", 0, 999);
            addComputedStatus("Misdeed", "비행화 수치", 0, 999);
            addComputedStatus("Illness", "질병 수치", 0, 999);
            addComputedStatus("Age", "나이", 0, 200);
        }
    }
}