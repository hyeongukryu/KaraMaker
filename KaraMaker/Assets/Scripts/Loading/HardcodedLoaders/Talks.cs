using System;
using System.Collections.Generic;
using Contents;

namespace Loading.HardcodedLoaders
{
    partial class HardcodedLoader
    {
        private void AddTalk(string key, string type, string dominantStatus, int minAge, int maxAge,
            string changeStatus, int? changeAmount, int? gold, string dialogBody)
        {
            var e = new Entity
            {
                Tag = type + "Talk",
                IsTalk = true,
                Key = key,
                DialogText = dialogBody,
                MinimumAge = minAge,
                MaximumAge = maxAge,
                DominantStatusKey = dominantStatus,
                ShowChanges = true
            };
            if (changeStatus != null)
            {
                e.ChangeKeys = new List<string> { changeStatus };
                e.ChangeAmounts = new List<int> { changeAmount.Value * GameConfiguration.RealToFixed };
            }
            if (gold != null)
            {
                e.GoldChanges = new List<int> { gold.Value * GameConfiguration.RealToFixed };
            }
            AddEntity(e);
        }

        private void LoadTalks()
        {
            var index = 0;
            var addTalk = new Action<string, string, int, int, string, int?, int?, string>(
                (type, dominantStatus, minAge, maxAge, changeStatus, changeAmount, gold, dialogBody) =>
                {
                    var key = "Talk" + index++;
                    AddTalk(key, type, dominantStatus, minAge, maxAge, changeStatus, changeAmount, gold, dialogBody);
                });

            addTalk("Basic", "CombatFame", 12, 14, "Health", 10, null, "운동하는 건 즐거워.");
            addTalk("Basic", "CombatFame", 12, 14, null, null, null, "검술을 제대로 배워보고 싶어. 멋있을 것 같지 않아? 무기를 휘두르는 내 모습!");
            addTalk("Basic", "CombatFame", 12, 14, "Strength", 10, null, "좀 더 근육이 붙었으면 좋겠어.....");
            addTalk("Basic", "MagicFame", 12, 14, null, null, null, "마법에 재능이 있다는 소리를 들었어!");
            addTalk("Basic", "MagicFame", 12, 14, "Intelligence", 10, null,
                "마법을 잘 하기 위해선, 자연을 잘 이해해야 하나 봐. 근데 무슨... 원소...? 그건 무슨 소리인지....");
            addTalk("Basic", "MagicFame", 12, 14, "Character", 10, null, "언젠가는 하늘을 날아보고 싶어,");
            addTalk("Basic", "SocialFame", 12, 14, null, null, null, "사람 만나는 건 즐거운 거 같아.");
            addTalk("Basic", "SocialFame", 12, 14, "Stress", -10, null, "언젠간 멋진 옷을 입고 성에서 춤춰보고 싶어!");
            addTalk("Basic", "SocialFame", 12, 14, "Charm", 10, null, "흥~흐흥~ (카라마츠는 거울을 보고 있다.)");
            addTalk("Basic", "HouseworkFame", 12, 14, "Morality", 10, null, "집안일을 도와준다는 거, 생각보다 어려운 거 같아.");
            addTalk("Basic", "HouseworkFame", 12, 14, null, null, null, "저 손재주가 좋은 편인가요? 이불 같은 건 잘 꼬맬 수 있는데!");
            addTalk("Basic", "HouseworkFame", 12, 14, "Health", 10, null,
                "쵸로마츠가 나한테 아직 멀었다고 했어요. 언젠간 그 말을 한 걸 후회하게 해 주지!");
            addTalk("Basic", "EffectiveSin", 12, 14, null, null, null, "신사 말인데, 그곳에 가면 왠지 편안하단 말이지.");
            addTalk("Basic", "EffectiveSin", 12, 14, null, null, null, "신사에 여우 동상이 있어. 근데 그거, 움직인다더라!?");
            addTalk("Basic", "EffectiveSin", 12, 14, null, null, null, "신사에 있는 사람 되게 친절한 것 같아.");
            addTalk("Basic", "CombatFame", 15, 17, "Morality", 10, null, "최근에 곤경에 처한 사람을 도와줬다. 정말로 고마워하더군. 뿌듯했다!");
            addTalk("Basic", "CombatFame", 15, 17, null, null, null, "새 검이 하나 사고 싶군... 아, 아니 혼잣말이다.");
            addTalk("Basic", "CombatFame", 15, 17, "Personality", 5, null, "검술 실력이 늘 수록, 이 힘을 좀 더 조심히 사용해야겠다는 생각이 든다.");
            addTalk("Basic", "MagicFame", 15, 17, null, null, null, "마법의 길은 아직도 멀고 멀었다는 생각이 든다.....");
            addTalk("Basic", "MagicFame", 15, 17, "Intelligence", 10, null, "이젠 원소에 대해 좀 알 것 같다!");
            addTalk("Basic", "MagicFame", 15, 17, "Character", 10, null, "언젠가 마법을 더 잘하게 되면 여러 곳에 여행을 다니고 싶다!");
            addTalk("Basic", "SocialFame", 15, 17, "Stress", -5, null, "최근에 사람 좋다는 소리를 들었다. 왠지 부끄럽군....");
            addTalk("Basic", "SocialFame", 15, 17, null, null, null, "더 많은 사람과 만나보고 싶다.");
            addTalk("Basic", "SocialFame", 15, 17, "Health", 10, null, "요즘은 사람을 이끄는 것도 꽤 해 볼 만한 경험이라는 생각이 든다.");
            addTalk("Basic", "HouseworkFame", 15, 17, "Stress", -10, null, "요즘은 나도 집안일을 잘 하지 않나~? 흐흥~?");
            addTalk("Basic", "HouseworkFame", 15, 17, null, null, null, "쵸로마츠가 아직도 갈 길이 멀었다고 했다. 집사란 대단한 직업이군.....");
            addTalk("Basic", "HouseworkFame", 15, 17, "Character", 10, null, "최근에 찰흙으로 상어 동상을 만들었다만, 꽤 리얼리티하지 않나?");
            addTalk("Basic", "EffectiveSin", 15, 17, null, null, null, ".....아, 불렀나? 미안하군. 잠시 딴 생각하고 있었다.");
            addTalk("Basic", "EffectiveSin", 15, 17, null, null, null, "(카라마츠는 먼 곳을 보고 있다.)");
            addTalk("Basic", "EffectiveSin", 15, 17, null, null, null, "더 이상 신사에 가지 않는 편이 좋을 지도 모르겠다.....");
            addTalk("Basic", "CombatFame", 18, 20, "Stress", -10, null, "길 가다가 건달을 만났다. 물론 내가 훌륭하게 제압했지!");
            addTalk("Basic", "CombatFame", 18, 20, null, null, null, "미래에 지금까지 배운 검술 실력을 활용할 수 있는 날이 올까?");
            addTalk("Basic", "CombatFame", 18, 20, "Strength", 10, null, "검을 깨끗하게 닦는 것이 하루의 시작! 검은 내 동반자니까 말이다.");
            addTalk("Basic", "MagicFame", 18, 20, "Character", 10, null, "빗자루가 갖고 싶군. 그게 있으면 어디든지 갈 수 있을 텐데.");
            addTalk("Basic", "MagicFame", 18, 20, null, null, null, "드래곤이라는 생물이 존재한다고 들었다. 한 번 그 존재를 눈으로 새기고 싶군.");
            addTalk("Basic", "MagicFame", 18, 20, "Stress", -10, null, "아무래도 내 특기는 얼음마법인 것 같다. 여름에는 시원하게 지낼 수 있겠어!");
            addTalk("Basic", "SocialFame", 18, 20, "Stress", -10, null, "사람 앞에 나서서 잘 이끌 수 있는 인물, 그건 나라는 존재겠지~! 흐흥~?");
            addTalk("Basic", "SocialFame", 18, 20, "Morality", 10, null,
                "나중엔 사람과 대화하면서 그 사람들의 이야기를 들어주는, 그런 일이 하고 싶다.");
            addTalk("Basic", "SocialFame", 18, 20, null, null, null, "인간관계는 참 복잡한 것 같다.");
            addTalk("Basic", "HouseworkFame", 18, 20, "Stress", -10, null, "쵸로마츠가 드디어 날 인정해준 것 같다!");
            addTalk("Basic", "HouseworkFame", 18, 20, null, null, null,
                "카라아게란... 인간이 발명한 최고의 음식.... 아침 점심 저녁 전부 카라아게만 먹고 싶군!");
            addTalk("Basic", "HouseworkFame", 18, 20, "Health", 10, null, "집안일에도 체력이 필요한 것 같다. 다 끝나고 나면 엄청 피곤하거든.");
            addTalk("Basic", "EffectiveSin", 18, 20, null, null, null, "...................... (불러도 반응이 없다.)");
            addTalk("Basic", "EffectiveSin", 18, 20, null, null, null,
                "곧.... 작별인사를 해야 할 지도 모르겠군..... (혼잣말을 중얼거리고 있지만, 잘 들리지 않는다.)");
            addTalk("Basic", "EffectiveSin", 18, 20, null, null, null,
                "아, 불렀나? 못 들었다, 미안하군. (3번 부르고 나서야 이 쪽을 돌아봤다.)");
            addTalk("Lecture", null, 12, 14, "Stress", 10, null, "...........");
            addTalk("Lecture", null, 12, 14, "Personality", 5, null, "제가 뭘 잘못했....나요?");
            addTalk("Lecture", null, 12, 14, "Morality", 10, null, "죄송합니다.....");
            addTalk("Lecture", null, 15, 17, "Stress", 10, null, "........");
            addTalk("Lecture", null, 15, 17, "Morality", 10, null, "다음부터는 그러지 않겠....습니다.");
            addTalk("Lecture", null, 15, 17, "Stress", 10, null, "내가 뭘 잘못했다는 건가?");
            addTalk("Lecture", null, 18, 20, "Stress", 10, null, ".........................................");
            addTalk("Lecture", null, 18, 20, "Stress", 10, null, "나도 이제 다 컸다만... 너무 신경쓰는 게 아닌가?");
            addTalk("Lecture", null, 18, 20, "Morality", 10, null, "으음.... 미안하다. 다시는 안 그러도록 하지.");
            addTalk("Money", null, 12, 12, "Stress", -20, -10, "헉, 용돈...! 감사합니다!");
            addTalk("Money", null, 13, 13, "Stress", -20, -20, "헉, 용돈...! 감사합니다!");
            addTalk("Money", null, 14, 14, "Stress", -20, -30, "헉, 용돈...! 감사합니다!");
            addTalk("Money", null, 15, 15, "Stress", -20, -40, "오오, 이걸로 새 옷을 살 수 있겠군!");
            addTalk("Money", null, 16, 16, "Stress", -20, -50, "오오, 이걸로 새 옷을 살 수 있겠군!");
            addTalk("Money", null, 17, 17, "Stress", -20, -60, "오오, 이걸로 새 옷을 살 수 있겠군!");
            addTalk("Money", null, 18, 18, "Stress", -20, -70, "마침 조금 부족한 참이었는데... 고맙다. 아껴서 쓰도록 하지.");
            addTalk("Money", null, 19, 19, "Stress", -20, -80, "마침 조금 부족한 참이었는데... 고맙다. 아껴서 쓰도록 하지.");
            addTalk("Money", null, 20, 20, "Stress", -20, -90, "마침 조금 부족한 참이었는데... 고맙다. 아껴서 쓰도록 하지.");
        }
    }
}