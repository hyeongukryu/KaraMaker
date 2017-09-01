using System;
using System.Linq;
using Contents;

namespace Loading
{
    class HardcodedLoader : LoaderBase
    {
        public HardcodedLoader(Bundle bundle, GameConfiguration gameConfiguration) : base(bundle, gameConfiguration)
        {
        }

        private void AddEntity(Entity entity)
        {
            GameConfiguration.Entities.Add(entity);
        }

        public override void Load()
        {
            LoadStatuses();
            LoadOpening();
            LoadSchedules();
        }

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

        private void LoadOpening()
        {
            var faceLookup = new[]
            {
                "Portraits/Choro/Face1Idle",
                "Portraits/Choro/Face2Smile",
                "Portraits/Choro/Face3Happy",
                "Portraits/Choro/Face4NoWords",
                "Portraits/Choro/Face5Surprise",
                "Portraits/Choro/Face6Sad",
                "Portraits/Choro/Face7Serious",
                "Portraits/Choro/Face8Angry"
            };

            var dressLookup = new[]
            {
                "Portraits/Choro/DressGoddess",
                "Portraits/Choro/DressButler"
            };

            const string prefix = "OpeningSequence";
            var index = 0;

            var addOpeningSequence = new Func<string, int, int, Entity>((text, face, dress) =>
            {
                var faceImage = face < 0 ? null : faceLookup[face];
                var bodyImage = face < 0 ? null : "Portraits/Choro/Body";
                var dressImage = face < 0 || dress < 0 ? null : dressLookup[dress];

                var backgroundImage = "Backgrounds/Black";
                if (index < 7)
                {
                    backgroundImage = "Backgrounds/OpeningA";
                }
                else if (index >= 7 && index < 34)
                {
                    backgroundImage = "Backgrounds/OpeningB";
                }
                else if (index >= 34 && index < 36)
                {
                    backgroundImage = "Backgrounds/OpeningC";
                }
                else if (index >= 36 && index <= 37)
                {
                    backgroundImage = "Backgrounds/OpeningB";
                }

                var e = new Entity
                {
                    Key = prefix + index,
                    DialogText = text,
                    ChangeBackgroundImage = backgroundImage,
                    PortraitFaceImage = faceImage,
                    PortraitBodyImage = bodyImage,
                    PortraitDressImage = dressImage,
                    NextKey = prefix + (index + 1)
                };
                if (index < 27)
                {
                    e.SkipKey = "OpeningSequence27";
                }
                AddEntity(e);
                index++;
                return e;
            });

            addOpeningSequence("예전에는 잘 나가는 용사였지만 마지막으로 싸운 전투에서 다리에 큰 부상을 입어", -1, 0);
            addOpeningSequence("더 이상 용사로서는 활약하지 못하게 되었다.", -1, 0);
            addOpeningSequence("그리하여 나는 지금까지 이루었던 업적을 인정받아 괜찮은 집을 받고, 1년에 한 번씩 나오는 연금으로 편하게 놀고먹으면서 살고 있었다.", -1, 0);
            addOpeningSequence("매일 놀고 먹는 건 물론 즐거웠지만 그... 약간의 스파이스가 부족하다고 할까", -1, 0);
            addOpeningSequence("뭔가 일상의 변화가 일어났으면 좋겠다는 생각을 하게 되었다.", -1, 0);
            addOpeningSequence("그러던 어느 날 밤, 마을에 있는 뒷산에 등산을 갔다.", -1, 0);
            addOpeningSequence("날씨가 너무나도 좋았고 평소에는 가지 않은 곳까지 산을 타고 말았다.", -1, 0);
            addOpeningSequence("이런 곳이 있었나? 라고 생각이 들은 것과 동시에 샘에서 갑자기 빛이 났다.", -1, 0);
            addOpeningSequence("......", 6, 0);
            addOpeningSequence("...뭐 뭐야?!", -1, 0);
            addOpeningSequence("음... 나쁘지 않네", 1, 0);
            addOpeningSequence("거기 당신 , 아이를 키워보실 생각 없으신가요?", 1, 0);
            addOpeningSequence("예?", -1, 0);
            addOpeningSequence("갑자기 저희가 곤란한 일이 생겨서 말입니다.", 5, 0);
            addOpeningSequence("원래는 죽어서는 안 되는 영혼을 사신이 실수로 죽이는 바람에 하늘로 올라오고 말았어요.", 5, 0);
            addOpeningSequence("이대로 내려보내자니 이미 장례도 다 치뤄버린 상태고, 그렇다고 다음 생으로 넘어가기까지엔 수명이 너무 많이 남았고......", 5, 0);
            addOpeningSequence("귀찮게 됐어요. 정말... 그러니까 누가 이따이하다고 죽이래?", 5, 0);
            addOpeningSequence("... 본론은, 이 아이를 키워주셨으면 합니다.", 0, 0);
            addOpeningSequence("성인이 되어서 스스로 살 수 있을 때까지면 됩니다.", 0, 0);
            addOpeningSequence("당신, 어차피 할 일 없다고 생각하고 계셨죠?", 0, 0);
            addOpeningSequence("뭔진 모르지만 정곡을 찔렸다.", -1, 0);
            addOpeningSequence("아이는 이렇게 생겼습니다.", 0, 0);
            addOpeningSequence("이미 전적이 있으니 조금만 잘못 키워도 이따이해질 것 같긴 하지만...", 0, 0);
            addOpeningSequence("당신이라면 잘 할 수 있을 거라고 생각합니다.", 0, 0);
            addOpeningSequence("이름은 카라마츠. 나이는 12살", 0, 0);
            addOpeningSequence("중요한 건 사신이 다시 죽이질 못하도록 이따이하지 않게 키우는 것입니다.", 0, 0);
            addOpeningSequence("어떤가요? 할 수 있으시겠나요?", 0, 0);
            var yesNo = addOpeningSequence("이따이한 게 뭔지는 잘 모르겠지만, 나는 대답했다. \n\n >네.\t\t\t\t\t\t\t\t >아니요.", -1, 0);

            addOpeningSequence("휴우 다행이에요. 한숨 놨네요.", 1, 0);
            addOpeningSequence("그래도 아이를 한 번도 키워본 적 없는 당신이 갑자기 양육을 한다는 게 좀 걱정이기도 하고,", 0, 0);
            addOpeningSequence("아이가 이따이하지 않으려면 지도도 좀 필요할 것 같으니...", 0, 0);
            addOpeningSequence("그래. 제 분신을 내려보내 집사로 쓸 수 있게 해 드리겠습니다.", 0, 0);
            addOpeningSequence("아, 그리고 오늘 가벼운 산사태가 일어날 예정이라서 집으로 바로 내려보내도록 하지요. 카라마츠와 함께.", 0, 0);
            addOpeningSequence("자, 그럼 당신의 앞날에 축복이 있기를....", 0, 0);
            addOpeningSequence("안녕 아빠! 오늘은 뭘 할까?", -1, 0);

            var last = addOpeningSequence("안녕하세요. 앞으로 당신을 모시게 된 쵸로마츠입니다. 잘 부탁드립니다, 주인님.", 2, 1);
            last.NextKey = null;
            last.NextScene = "Main";

            var bad = addOpeningSequence("...으, 으음 그렇군요... 알겠습니다.", 0, -1);
            yesNo.ClickedYesKey = yesNo.NextKey;
            yesNo.NextKey = null;
            yesNo.ClickedNoKey = bad.Key;

            addOpeningSequence("어쩔 수 없군요. 제가 사람을 잘못 봤나 보군요....", 5, -1);
            addOpeningSequence("그렇게 여신(?)은 사라졌다.", -1, -1);
            addOpeningSequence("그리고 난 산을 내려오는 길에 갑자기 발생한 산사태에 발을 헛디뎌 굴러떨어져 죽고 말았다.", -1, -1);
            addOpeningSequence("그러니까 누가 거절하래?", 7, -1);
            var over = addOpeningSequence("Game Over......", -1, -1);
            over.NextKey = null;
            over.IsGameOver = true;
        }

        private void LoadSchedules()
        {
        }
    }
}
