using System;
using Contents;

namespace Loading.HardcodedLoaders
{
    partial class HardcodedLoader
    {
        private void LoadScheduleDialogs()
        {
            Action<string, string, string, string> addScheduleDialog = (key, body, artwork, portrait) =>
            {
                var e = new Entity
                {
                    Key = key,
                    DialogText = body,
                    PortraitImage = portrait,

                };
            };

            addScheduleDialog("ArtBegin", "흐흐.... 저 남자랑 저 남자랑... 이렇게...", null, "ArtPortrait");
            addScheduleDialog("ArtEnd", "히히.. 그리고 저 남자랑 이 남자랑....", null, "ArtPortrait");
            addScheduleDialog("ArtSuccess", "너무나도 어려운 미술의 세계...", "ArtArtwork", null);
            addScheduleDialog("AthleticBegin", "너희들, 날 따라올 수 있을까?", null, "AthleticPortrait");
            addScheduleDialog("AthleticEnd", "오오~ 잘 따라오는데~ 합격!", null, "AthleticPortrait");
            addScheduleDialog("AthleticSuccess", "열심히 농구를 했다.", "AthleticArtwork", null);
            addScheduleDialog("BarBegin", "안녕~ 오늘도 손님들 열심히 상대해 줘~", null, "BarPortrait");
            addScheduleDialog("BarEndA", "손님들이 엄청 좋아하더라! 저 재능 있는데? 일단 조금 더 넣어줬어~!", null, "BarPortrait");
            addScheduleDialog("BarEndB", "수고 많았어~ 실수만 조금 더 주의해줘~!", null, "BarPortrait");
            addScheduleDialog("BarEndC", "손님들이 많이 화내던데, 무슨 일 있었어?", null, "BarPortrait");
            addScheduleDialog("BarFail", "손님들 상대하기 너무 힘들다....", "BarFailArtwork", null);
            addScheduleDialog("BarSuccess", "손님들이 기뻐하는 것 같다!", "BarSuccessArtwork", null);
            addScheduleDialog("BlackfactoryBegin", "...에- 일단 이게 오늘의 작업 일지. 에? 완전 까맣다고? 기분 탓이에요.", null, "BlackfactoryPortrait");
            addScheduleDialog("BlackfactoryEnd", "빨리 그만두는 게 좋을 거예요....", null, null);
            addScheduleDialog("BlackfactorySuccess", "어른이 되어라 - 어른이 되어라 -", "BlackfactoryArtwork", null);
            addScheduleDialog("ChurchBegin", "청소하다가 땡땡이 치면 안 돼! 내가 계속 감시하고 있을 테니까~!", null, "ChurchPortrait");
            addScheduleDialog("ChurchEndA", "와~ 다시 봤어! 진짜! 다음에도 잘 부탁해♡ 고마워서 조금 더 넣었으니까 감사히 여기라구~!", null, "ChurchPortrait");
            addScheduleDialog("ChurchEndB", "수고했어, 이건 약속했던 봉사금!", null, "ChurchPortrait");
            addScheduleDialog("ChurchEndC", "오히려 더 더러워졌잖아~~~!!!!", null, "ChurchPortrait");
            addScheduleDialog("ChurchFail", "성당 거울에 비치는 내 모습이 너무 아름다워서 그만....", "ChurchFailArtwork", null);
            addScheduleDialog("ChurchSuccess", "성당 청소를 열심히 하는 오레!", "ChurchSuccessArtwork", null);
            addScheduleDialog("DanceBegin", "자, 열심히 따라해보라냥!", null, "DancePortrait");
            addScheduleDialog("DanceEnd", "수고했다냐~ 정리 깨끗하게 하고 가라냐!", null, "DancePortrait");
            addScheduleDialog("DanceSuccess", "원투쓰리포, 원투쓰리포.", "DanceArtwork", null);
            addScheduleDialog("DeliveryBegin", "우효효효효~ 택배회사에 어서오잔스!", null, "DeliveryPortrait");
            addScheduleDialog("DeliveryEndA", "우효효효~~! 덕분에 돈을 많이 벌었... 크흠, 크흐흠. 수고했잔스. 조금이지만 수고비를 주겠잔스!", null, "DeliveryPortrait");
            addScheduleDialog("DeliveryEndB", "흥, 꽤 쓸만하잔스.", null, "DeliveryPortrait");
            addScheduleDialog("DeliveryEndC", "정말 도움도 안 되는 게 왔잔스.....", null, "DeliveryPortrait");
            addScheduleDialog("DeliveryFail", "택배가 주인들을 스스로 찾아갔으면 좋겠다......", "DeliveryFailArtwork", null);
            addScheduleDialog("DeliverySuccess", "오늘도 택배를 주인들에게 전달해주었다.", "DeliverySuccessArtwork", null);
            addScheduleDialog("EtiquetteBegin", "예의는 모든 것의 기본이랍니다.", null, "EtiquettePortrait");
            addScheduleDialog("EtiquetteEnd", "앉아있느라 고생 많으셨습니다. 다리는 저리지 않나요?", null, "EtiquettePortrait");
            addScheduleDialog("EtiquetteSuccess", "다리가 좀 저리는 것 같지만 멋진 인간이 되기 위해선...!", "EtiquetteArtwork", null);
            addScheduleDialog("FarmBegin", "(우오오-! 야구할래? 야구? 에? 야구 아니야?", null, "FarmPortrait");
            addScheduleDialog("FarmEndA", "와이이-!! 가보로 삼아야제---!!", null, "FarmPortrait");
            addScheduleDialog("FarmEndB", "수고했사요나라홈런-!", null, "FarmPortrait");
            addScheduleDialog("FarmEndC", "시무룩.....", null, "FarmPortrait");
            addScheduleDialog("FarmFail", "sunshine...을 맞고 있는 나..!", "FarmFailArtwork", null);
            addScheduleDialog("FarmSuccess", "sunshine을 맞으며 곡식을 열심히 키웠다", "FarmSuccessArtwork", null);
            addScheduleDialog("FenceBegin", "깃발을 잘 쑤시는 게 검술의 기초다죠~!", null, "FencePortrait");
            addScheduleDialog("FenceEnd", "다들 깃발과 하나가 되서 기쁘다죠-!", null, "FencePortrait");
            addScheduleDialog("FenceSuccess", "이 깃발로 다 뚫어버리겠어.", "FenceArtwork", null);
            addScheduleDialog("GraveyardBegin", "뭐야, 빌빌되게 생겨선. 기절하는 거 아냐?", null, "GraveyardPortrait");
            addScheduleDialog("GraveyardEndA", "으하하하, 겁쟁이인 줄 알았는데 쓸만하구만. 옛다, 보너스다!", null, "GraveyardPortrait");
            addScheduleDialog("GraveyardEndB", "뭐, 이 정도면 훌륭한 편이지, 키키킥. 잘 가라고, 꼬맹아.", null, "GraveyardPortrait");
            addScheduleDialog("GraveyardEndC", "사실은 기절한 횟수가 더 많은 게 아니냐~?", null, "GraveyardPortrait");
            addScheduleDialog("GraveyardFail", "(기절한 것 같다....)", "GraveyardFailArtwork", null);
            addScheduleDialog("GraveyardSuccess", "귀신 따위..무섭지...않다!", "GraveyardSuccessArtwork", null);
            addScheduleDialog("HotelBegin", "할 일은 많지 않으니까 걱정 마.", null, "HotelPortrait");
            addScheduleDialog("HotelEndA", "덕분에 휴가 딸 수 있을 것 같아. 고마우니 이건 보너스.", null, "HotelPortrait");
            addScheduleDialog("HotelEndB", "수고했어. 별 일은 없었나 보네.", null, "HotelPortrait");
            addScheduleDialog("HotelEndC", "무슨 일 있었어? 표정이 안 좋네.", null, "HotelPortrait");
            addScheduleDialog("HotelFail", "손님, 대낮부터 뜨거우시네요.....", "HotelFailArtwork", null);
            addScheduleDialog("HotelSuccess", "흥~흐흐흥~ 흐흥~", "HotelSuccessArtwork", null);
            addScheduleDialog("HouseworkBegin", "제가 하라는 대로 하시면 되세요!", null, "HouseworkPortrait");
            addScheduleDialog("HouseworkEndA", "와~ 덕분에 한시름 놓았어요! 덕분에 집안 경비를 아낄 수 있었답니다~", null, "HouseworkPortrait");
            addScheduleDialog("HouseworkEndB", "도련님, 고생하셨어요! 이제 가서 쉬세요!", null, "HouseworkPortrait");
            addScheduleDialog("HouseworkEndC", "으, 음... 수고하셨어요. 제가 마무리할 테니 가서 쉬세요.", null, "HouseworkPortrait");
            addScheduleDialog("HouseworkFail", "평생 부양받으면서 살고 싶네....", "HouseworkFailArtwork", null);
            addScheduleDialog("HouseworkSuccess", "집안일의 신이 날 부르고 있다", "HouseworkSuccessArtwork", null);
            addScheduleDialog("HunterBegin", "어서오라~~용~~! 어려운 거 아니라~~용!", null, "HunterPortrait");
            addScheduleDialog("HunterEndA", "훗, 수고 많았다. 이건 수고비다.", null, "HunterPortrait");
            addScheduleDialog("HunterEndB", "수고많았다~~용~~~!", null, "HunterPortrait");
            addScheduleDialog("HunterEndC", "밉다~~용~~~! 집에 가라~~용~~~!", null, "HunterPortrait");
            addScheduleDialog("HunterFail", "내가 사냥을 하는 건지 사냥을 당하는 건지......", "HunterFailArtwork", null);
            addScheduleDialog("HunterSuccess", "훗, 영혼들에게 구원을......", "HunterSuccessArtwork", null);
            addScheduleDialog("IzakayaBegin", "내 오뎅은 세계 제일이라고! 알겠냐!", null, "IzakayaPortrait");
            addScheduleDialog("IzakayaEndA", "오오~ 대단한데, 너 혹시 제자로 들어올 생각 없냐!?", null, "IzakayaPortrait");
            addScheduleDialog("IzakayaEndB", "수고많았다 짜샤, 다음에도 잘 부탁한다고!", null, "IzakayaPortrait");
            addScheduleDialog("IzakayaEndC", "네가 깨먹은 컵이 몇 갠 줄 아냐 짜샤~~~!", null, "IzakayaPortrait");
            addScheduleDialog("IzakayaFail", "화려한 스탭으로 앞구르기를 했다.", "IzakayaFailArtwork", null);
            addScheduleDialog("IzakayaSuccess", "세계 최고 오뎅, 열심히 서빙을 했다!", "IzakayaSuccessArtwork", null);
            addScheduleDialog("LiteratureBegin", "자~ 책 빨리 피렴~ 수업 시작한다!", null, "LiteraturePortrait");
            addScheduleDialog("LiteratureEnd", "오늘 수업은 여기까지~", null, "LiteraturePortrait");
            addScheduleDialog("LiteratureSuccess", "흑... 너무나도 아름다운 글이군...", "LiteratureArtwork", null);
            addScheduleDialog("MagicBegin", "아~ 파칭코 가고 싶다~ 빨리 시작하자~", null, "MagicPortrait");
            addScheduleDialog("MagicEnd", "아아~~ 수업 끝~! 그럼 난 파칭코하러 간다~!", null, "MagicPortrait");
            addScheduleDialog("MagicSuccess", "손에서 얼음을 발사하는 마법을 배웠다.", "MagicArtwork", null);
            addScheduleDialog("MineBegin", "언젠간 석유를 발견할 수 있을 겁니다!", null, "MinePortrait");
            addScheduleDialog("MineEndA", "오오, 덕분에 새로운 광맥을 찾았습니다. 이건 사례비입니다.", null, "MinePortrait");
            addScheduleDialog("MineEndB", "수고하셨습니다. 조심해서 들어가십시오.", null, "MinePortrait");
            addScheduleDialog("MineEndC", "으, 으음, 이건 대체....", null, "MinePortrait");
            addScheduleDialog("MineFail", "알고 있어? 석유왕은 사실 금수저라는 것을....", "MineFailArtwork", null);
            addScheduleDialog("MineSuccess", "언젠간 나도 석유왕이 될거야!", "MineSuccessArtwork", null);
            addScheduleDialog("ParentingBegin", "아이가 울거나 하면 빨리 저흴 불러주세요!", null, "ParentingPortrait");
            addScheduleDialog("ParentingEndA", "아이들이 참 좋아하는 것 같아요! 약간 더 넣어드렸으니 자주 와 주세요.", null, "ParentingPortrait");
            addScheduleDialog("ParentingEndB", "슬슬 일은 익숙해지셨나요?", null, "ParentingPortrait");
            addScheduleDialog("ParentingEndC", "아이 다루기 참 힘들죠? 자주 하면 익숙해지실거에요.", null, "ParentingPortrait");
            addScheduleDialog("ParentingFail", "내 자장가가 마음에 안 드는 것인가...", "ParentingFailArtwork", null);
            addScheduleDialog("ParentingSuccess", "아이들이 내 말을 잘 들었다", "ParentingSuccessArtwork", null);
            addScheduleDialog("RestBegin", "도련님, 오늘은 쉬는 날이신가요?", null, "RestPortrait");
            addScheduleDialog("RestEnd", "푹 쉬셨나 보네요.", null, "RestPortrait");
            addScheduleDialog("RestSuccess", "집에서 뒹굴뒹굴거렸다.", "RestArtwork", null);
            addScheduleDialog("SalonBegin", "어서 와~~~ 오늘도 화 이 팅!", null, "SalonPortrait");
            addScheduleDialog("SalonEndA", "대박이다 어머 어쩌니~~ 진짜 취직해도 되겠어~~", null, "SalonPortrait");
            addScheduleDialog("SalonEndB", "수고많이했어~ 집 가서 푹 쉬어!", null, "SalonPortrait");
            addScheduleDialog("SalonEndC", "으음~~~ 네 센스엔 좀 문제가 있는 게 아닐까~~?", null, "SalonPortrait");
            addScheduleDialog("SalonFail", "내 미적 감각에 mistake....", "SalonFailArtwork", null);
            addScheduleDialog("SalonSuccess", "내 센스는 세계 제일이지.", "SalonSuccessArtwork", null);
            addScheduleDialog("ScienceBegin", "호에호에, 과학은 아름다운 것이다스.", null, "SciencePortrait");
            addScheduleDialog("ScienceEnd", "호에호에, 고생했다스. 다음에는 더 대단한 걸 배우겠다스!", null, "SciencePortrait");
            addScheduleDialog("ScienceSuccess", "이 시약과 이 시약을 섞어서....", "ScienceArtwork", null);
            addScheduleDialog("ShrineBegin", "올라오느라 힘들지는 않으셨나요?", null, "ShrinePortrait");
            addScheduleDialog("ShrineEndA", "감사합니다, 덕분에 한 시름 놓았어요. 얼마 안 되지만 이건 추가금입니다.", null, "ShrinePortrait");
            addScheduleDialog("ShrineEndB", "수고하셨습니다, 다음에 또 와주세요.", null, "ShrinePortrait");
            addScheduleDialog("ShrineEndC", "괜찮아요, 다음에 더 잘 하면 되죠.", null, "ShrinePortrait");
            addScheduleDialog("ShrineFail", "신사의 정취를 맡으며 딴 짓을 했다.", "ShrineFailArtwork", null);
            addScheduleDialog("ShrineSuccess", "신사의 정취를 맡으며 청소를 열심히 했다.", "ShrineSuccessArtwork", null);
            addScheduleDialog("TheologyBegin", "신에 대해서 배우면 신께서 소원을 들어주실 거에요.", null, "TheologyPortrait");
            addScheduleDialog("TheologyEnd", "다음에도 신에 대해 배워보도록 해요.", null, "TheologyPortrait");
            addScheduleDialog("TheologySuccess", "정말로 소원을 들어줄까?", "TheologyArtwork", null);
            addScheduleDialog("TutorBegin", "우리 아이가 마구를 던져서.... 꼭 잘 부탁드리겠습니다.", null, "TutorPortrait");
            addScheduleDialog("TutorEndA", "오오, 우리 아들의 마구를...! 덕분에 아들도 기뻐하는 것 같군요. 이건 보너스입니다. 정말 감사드립니다.", null, "TutorPortrait");
            addScheduleDialog("TutorEndB", "수고하셨습니다. 몸은 괜찮으세요?", null, "TutorPortrait");
            addScheduleDialog("TutorEndC", "허허.... 혹시 다치거나 하진 않으셨습니까?", null, "TutorPortrait");
            addScheduleDialog("TutorFail", "날 죽이려는 셈이지!? 그런거지!?!?", "TutorFailArtwork", null);
            addScheduleDialog("TutorSuccess", "강속구! 받아낼 수 있다!", "TutorSuccessArtwork", null);
            addScheduleDialog("VacationBegin", "준비는 다 되셨나요? 그럼 출발하겠습니다!", null, "VacationPortrait");
            addScheduleDialog("VacationEnd", "즐거웠죠?", null, "VacationPortrait");
            addScheduleDialog("VacationSuccess", "피서를 즐겼다!", "VacationArtwork", null);
        }
    }
}
