using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningSchedule : MonoBehaviour
{
	public GameObject[] Parameter;
	public GameObject[] ScrollBar;
	public Text[] ParameterName;
	public Text[] ParameterValue;
	public Sprite[] NPCImageList;
	public Text NPCText;
	public Image NPCProfile;

	public int[] ScheduleList;

	private string workIs;
	private float GameTime;
	private bool? isSuccess;

	private void Start()
	{
		GetComponent<UIManager>().EndWork();

		for(int i = 0; i < 6; i++)
		{
			Parameter[i].SetActive(false);
		}

		GameTime = 0;
		isSuccess = null;
		workIs = "Start";
	}

	private void Update()
	{
		SetNPC();

		if(workIs == "Start")
		{
			BeforeSchedule();
		}
		else if(workIs == "Doing")
		{
			RunSchedule();
		}
		else if(workIs == "Done")
		{
			AfterSchedule();
		}
	}

	private void BeforeSchedule() //텍스트 바꾸는 역할
	{
		int schedule;
		int level; // 나중에 그 알바/교육의 단계를 가져와야 할 것

		if(DayManager.Day == 1)
			schedule = ScheduleList[0];
		else if (DayManager.Day == 11)
			schedule = ScheduleList[1];
		else if (DayManager.Day == 21)
			schedule = ScheduleList[2];
	}

	private void RunSchedule()
	{
		GameTime = GameTime + Time.deltaTime;

		int ScheduleListNum = (DayManager.Date - 1) / 10; // 그 달의 몇번째 스케쥴인지 알려주는 번호

		RunSchedule_10Day(ScheduleListNum);
	}

	private void RunSchedule_10Day(int ScheduleListNum) // 10일치의 스케쥴을 실행시키는 녀석
	{
		SettingParameter(ScheduleList[ScheduleListNum]);

		if(GameTime >= 1f)
		{
			UpdateParameter(ScheduleList[ScheduleListNum]);

			GameTime = 0;
			if(DayManager.Date == (ScheduleListNum + 1) * 10)
			{
				workIs = "Done";
				return;
			}

			DayManager.Date = DayManager.Date + 1;
			isSuccess = null;
		}
	}

	private void AfterSchedule()
	{
		GetComponent<UIManager>().EndWork();
	}

	private void SettingParameter(int Schedule)
	{
		LoadParameter(0, 0);

		switch(Schedule)
		{
			case 0: //집안일
			SetParameter("요리", "성품", "청소세탁", "None", "감수성");
			break;
			case 1: //보모
			SetParameter("성품", "감수성", "None", "None", "매력");
			break;
			case 2: //호텔
			SetParameter("청소세탁", "화술", "None", "None", "전투기술");
			break;
			case 3: //농장
			SetParameter("체력", "근력", "None", "None", "기품");
			break;
			case 4: //성당
			SetParameter("신앙", "도덕", "None", "None", "인과");
			break;
			case 5: //신사
			SetParameter("인과", "None", "None", "None", "전투기술");
			break;
			case 6: //광부
			SetParameter("근력", "None", "None", "None", "기품");
			break;
			case 7: //미용실
			SetParameter("감수성", "None", "None", "None", "근력");
			break;
			case 8: //택배
			SetParameter("체력", "None", "None", "None", "매력");
			break;
			case 9: //사냥꾼
			SetParameter("체력", "전투기술", "인과", "기품", "성품");
			break;
			case 10: //묘지기
			SetParameter("감수성", "항마력", "None", "None", "매력");
			break;
			case 11: //가정교사
			SetParameter("도덕심", "None", "None", "None", "매력");
			break;
			case 12: //주점
			SetParameter("요리", "화술", "None", "None", "지능");
			break;
			case 13: //블랙공장
			SetParameter("None", "None", "None", "None", "None");
			break;
			case 14: //마법
			SetParameter("마법기술", "마력", "None", "None", "None");
			break;
			case 15: //검술
			SetParameter("전투기술", "공격력", "None", "None", "None");
			break;
			case 16: //예절
			SetParameter("기품", "도덕심", "예의범절", "None", "None");
			break;
			case 17: //무용
			SetParameter("체력", "매력", "예술", "None", "None");
			break;
			case 18: //과학
			SetParameter("지능", "None", "None", "None", "신앙심");
			break;
			case 19: //신학
			SetParameter("지능", "신앙심", "항마력", "None", "None");
			break;
			case 20: //미술
			SetParameter("감수성", "예술", "None", "None", "None");
			break;
			case 21: //체육
			SetParameter("체력", "전투기술", "방어력", "None", "None");
			break;
			case 22: //문학
			SetParameter("지능", "기품", "감수성", "None", "None");
			break;
			case 23: //자유행동
			SetParameter("None", "None", "None", "None", "None");
			break;
			case 24: //바캉스
			SetParameter("None", "None", "None", "None", "None");
			break;
			default:
				Debug.Log("Something is Wrong at SettingParameter in RunningSchedule");
				break;
		}
	}

	private void UpdateParameter(int Schedule)
	{
		switch(Schedule)
		{
			case 0: //집안일, Housework
			ChangeParameter("요리", 0.5f);
			ChangeParameter("성품", 0.5f);
			ChangeParameter("청소세탁", 0.5f);
			ChangeParameter("감수성", -2f);
			ChangeParameter("스트레스", 1);
			GoldChage(1);
			break;
			case 1: //보모, Parenting
			ChangeParameter("성품", 0.5f);
			ChangeParameter("감수성", 1f);
			ChangeParameter("매력", -1f);
			ChangeParameter("스트레스", 3);
			GoldChage(1);
			break;
			case 2: //호텔, Hotel
			ChangeParameter("청소세탁", 0.5f);
			ChangeParameter("화술", 0.5f);
			ChangeParameter("전투기술", -0.5f);
			ChangeParameter("스트레스", 2);
			GoldChage(1);
			break;
			case 3: //농장, Farm
			ChangeParameter("체력", 1f);
			ChangeParameter("근력", 1f);
			ChangeParameter("기품", -1f);
			ChangeParameter("스트레스", 3);
			GoldChage(4);
			break;
			case 4: //성당, Church
			ChangeParameter("신앙심", 2f);
			ChangeParameter("도덕심", 1f);
			ChangeParameter("인과", -2f);
			ChangeParameter("스트레스", 1);
			GoldChage(0);
			break;
			case 5: //신사, Shrine
			ChangeParameter("인과", 2f);
			ChangeParameter("전투기술", -0.5f);
			ChangeParameter("스트레스", 2);
			GoldChage(30);
			break;
			case 6: //광부, Mine
			ChangeParameter("근력", 2f);
			ChangeParameter("기품", -2f);
			ChangeParameter("스트레스", 4);
			GoldChage(20);
			break;
			case 7: //미용실, Salon
			ChangeParameter("감수성", 1f);
			ChangeParameter("근력", -1f);
			ChangeParameter("스트레스", 3);
			GoldChage(8);
			break;
			case 8: //택배, Delivery
			ChangeParameter("체력", 2f);
			ChangeParameter("매력", -1f);
			ChangeParameter("스트레스", 3);
			GoldChage(10);
			break;
			case 9: //사냥꾼, Hunter
			ChangeParameter("체력", 1f);
			ChangeParameter("전투기술", 1f);
			ChangeParameter("인과", 0.5f);
			ChangeParameter("기품", -1f);
			ChangeParameter("성품", -0.5f);
			ChangeParameter("스트레스", 3);
			GoldChage(8);
			break;
			case 10: //묘지기, Graveyard
			ChangeParameter("감수성", 1f);
			ChangeParameter("항마력", 0.5f);
			ChangeParameter("매력", -1f);
			ChangeParameter("스트레스", 5);
			GoldChage(8);
			break;
			case 11: //가정교사, Tutor
			ChangeParameter("도덕심", 1f);
			ChangeParameter("매력", -1f);
			ChangeParameter("스트레스", 7);
			GoldChage(10);
			break;
			case 12: //주점, Izakaya
			ChangeParameter("요리", 0.5f);
			ChangeParameter("화술", 0.5f);
			ChangeParameter("지능", -2f);
			ChangeParameter("스트레스", 5);
			GoldChage(12);
			break;
			case 13: //블랙공장, BlackFactory
			ChangeParameter("스트레스", 20);
			GoldChage(50);
			break;
			case 14: //마법, Magic
			ChangeParameter("마법기술", 1);
			ChangeParameter("마력", 1);
			ChangeParameter("스트레스", 1);
			GoldChage(-30);
			break;
			case 15: //검술, Fence
			ChangeParameter("전투기술", 1.5f);
			ChangeParameter("공격력", 1);
			ChangeParameter("스트레스", 1);
			GoldChage(-40);
			break;
			case 16: //예절, Etiquette
			ChangeParameter("기품", 1);
			ChangeParameter("도덕심", 1);
			ChangeParameter("예의범절", 0.5f);
			ChangeParameter("스트레스", 1);
			GoldChage(-40);
			break;
			case 17: //무용, Dance
			ChangeParameter("체력", 1);
			ChangeParameter("매력", 1);
			ChangeParameter("예술", 0.5f);
			ChangeParameter("스트레스", 1);
			GoldChage(-40);
			break;
			case 18: //과학, Science
			ChangeParameter("지능", 2.5f);
			ChangeParameter("신앙심", -1);
			ChangeParameter("스트레스", 1);
			GoldChage(-40);
			break;
			case 19: //신학, Theology
			ChangeParameter("지능", 0.5f);
			ChangeParameter("신앙심", 1);
			ChangeParameter("항마력", 0.5f);
			ChangeParameter("스트레스", 1);
			GoldChage(-30);
			break;
			case 20: //미술, Art
			ChangeParameter("감수성", 1);
			ChangeParameter("예술", 1.5f);
			ChangeParameter("스트레스", 1);
			GoldChage(-40);
			break;
			case 21: //체육, Athletic
			ChangeParameter("체력", 1);
			ChangeParameter("전투기술", 0.5f);
			ChangeParameter("방어력", 0.5f);
			ChangeParameter("스트레스", 1);
			GoldChage(-30);
			break;
			case 22: //문학, Literature
			ChangeParameter("지능", 1);
			ChangeParameter("기품", 0.5f);
			ChangeParameter("감수성", 1);
			ChangeParameter("스트레스", 1);
			GoldChage(-40);
			break;
			case 23: //자유행동, Rest
			ChangeParameter("스트레스", -3);
			GoldChage(-10);
			break;
			case 24: //바캉스, Vacation
			ChangeParameter("스트레스", -10);
			GoldChage(-50);
			break;
			default:
				Debug.Log("Something is Wrong at UpdateParameter in RunningSchedule");
				break;
		}
	}

	private void SetParameter(string P1, string P2, string P3, string P4, string P5)
	{
		List<string> parameters = new List<string> {
			P1, P2, P3, P4, P5
		};

		for (int i = 0; i < 5; i++)
		{
			string parameter = parameters[i];
			int visualIndex = i + 1;
			if (parameter != "None")
			{
				LoadParameter(visualIndex, GetStatusNum(parameter));
			}
			else
			{
				Parameter[visualIndex].SetActive(false);
			}
		}
	}

	private void LoadParameter(int i, int WhichParameter)
	{
		Parameter[i].SetActive(true);
		ParameterName[i].text = KaramatsuManager.StatusName_Kr[WhichParameter];
		ParameterValue[i].text = KaramatsuManager.Status[WhichParameter].ToString();
		
		float Value = KaramatsuManager.Status[WhichParameter];
		float ScrollBarSize = Value/999;

		ScrollBar[i].GetComponent<Scrollbar>().size = ScrollBarSize;
	}

	private void ChangeParameter(string StatusName, float ChangeAmount)
	{
		KaramatsuManager.Status[GetStatusNum(StatusName)] = KaramatsuManager.Status[GetStatusNum(StatusName)] + ChangeAmount;

		if(KaramatsuManager.Status[GetStatusNum(StatusName)] < 0)
			KaramatsuManager.Status[GetStatusNum(StatusName)] = 0;
		else if(KaramatsuManager.Status[GetStatusNum(StatusName)] > 999)
			KaramatsuManager.Status[GetStatusNum(StatusName)] = 999;
	}

	private void GoldChage(int earn)
	{
		KaramatsuManager.Gold += earn;
	}

	public void ScheduleText()//텍스트를 누르면 스케쥴이 시작함을 알리거나 스케쥴이 끝났음을 알리는 역할
	{
		if(DayManager.Date == 1 || DayManager.Date == 11 || DayManager.Date == 21)
		{
			GetComponent<UIManager>().StartWork();

			workIs = "Doing";
		}
		if(DayManager.Date == 10 || DayManager.Date == 20 || DayManager.Date == 30)
		{
			workIs = "Start";
			
			if(DayManager.Date == 30)
			{
				GetComponent<RunningSchedule>().enabled = false;
				GetComponent<UIManager>().Start();
			}
			
			DayManager.Date = DayManager.Date + 1;
		}
	}

	private void isScheduleSuccess(int whatSchedule) //알바가 성공했는지 알려주는 함수
	{
		if(isSuccess != null)
		{
			return;
		}
		if(whatSchedule >= 13)
		{
			isSuccess = true;
			return;
		}
		else
		{
			int num = Random.Range (0, 2);
			if(num == 1)
			isSuccess = true;
			else isSuccess = false;
			return;
		}
	}

	private void SetNPC() // 스케쥴에 따른 NPC 대사와 프로필 이미지 변경 함수
	{
		int i = 0;

		if(DayManager.Date >= 1 && DayManager.Date <= 10)
		{
			i = 0;
		}
		else if(DayManager.Date >= 11 && DayManager.Date <= 20)
		{
			i = 1;
		}
		else if(DayManager.Date >= 21 && DayManager.Date <= 30)
		{
			i = 2;
		}

		isScheduleSuccess(ScheduleList[i]);
		NPCText.text = GetNPCText(ScheduleList[i], workIs, isSuccess);
		NPCProfile.sprite = NPCImageList[ScheduleList[i]];
	}

	private string GetNPCText(int scheduleNum, string state, bool? isSuccess) // NPC 대사 정보 여기서 수정 가능
	{
		string text = "Error";
		string[] textData = new string[4];

		switch(scheduleNum)
		{
			case 0:
				textData = new string[4] {
										"제가 하라는 대로 하시면 되세요!",
										"집안일의 신이 날 부르고 있다.",
										"평생 부양받으면서 살고 싶네....",
										"도련님, 고생하셨어요! 이제 가서 쉬세요!"};
				break;
			case 1:
				textData = new string[4] {
										"아이가 울거나 하면 빨리 저흴 불러주세요!",
										"아이들이 내 말을 잘 들었다.",
										"내 자장가가 마음에 안 드는 것인가...",
										"슬슬 일은 익숙해지셨나요?"};
				break;
			case 2:
				textData = new string[4] {
										"할 일은 많지 않으니까 걱정 마.",
										"흥~흐흐흥~ 흐흥~",
										"손님, 대낮부터 뜨거우시네요.....",
										"수고했어. 별 일은 없었나 보네."};
				break;
			case 3:
				textData = new string[4] {
										"우오오-! 야구할래? 야구? 에? 야구 아니야?",
										"Sunshine을 맞으며 곡식을 열심히 키웠다.",
										"Sunshine을... 맞고 있는 나...!",
										"수고했사요나라홈런-!"};
				break;
			case 4:
				textData = new string[4] {
										"청소하다가 땡땡이 치면 안 돼! 내가 계속 감시하고 있을 테니까~!",
										"성당 청소를 열심히 하는 오레!",
										"성당 거울에 비치는 내 모습이 너무 아름다워서 그만....",
										"수고했어. 이건 약속했던 봉사금!"};
				break;
			case 5:
				textData = new string[4] {
										"올라오느라 힘들지는 않으셨나요?",
										"신사의 정취를 맡으며 청소를 열심히 했다.",
										"신사의 정취를 맡으며 딴 짓을 했다.",
										"수고하셨습니다. 다음에 또 와주세요."};
				break;
			case 6:
				textData = new string[4] {
										"언젠간 석유를 발견할 수 있을 겁니다!",
										"언젠간 나도 석유왕이 될거야!",
										"알고 있어? 석유왕은 사실 금수저라는 것을......",
										"수고하셨습니다. 조심해서 들어가십시오."};
				break;
			case 7:
				textData = new string[4] {
										"어머어머 어서 와~~~! 미용실 일은 처음이야~~~?",
										"오늘도 내 미적 감각을 마음껏 발휘했다.",
										"내 미적 감각에 mistake....",
										"오늘은 수고 많았어~~~ 이건 보. 상.!"};
				break;
			case 8:
				textData = new string[4] {
										"우효효효효~ 택배회사에 어서오쌈바!",
										"오늘도 택배를 주인들에게 전달해주었다.",
										"택배가 주인들을 스스로 찾아갔으면 좋겠다......",
										"흥, 꽤 쓸만하잔스."};
				break;
			case 9:
				textData = new string[4] {
										"어렵지 않아~~용~~~!!",
										"훗, 영혼들에게 구원을......",
										"내가 사냥을 하는 건지 사냥을 당하는 건지......",
										"수고했다~~~~용~~~!!"};
				break;
			case 10:
				textData = new string[4] {
										"뭐야, 빌빌되게 생겨선. 기절하는 거 아냐?",
										"귀신 따위..무섭지...않다!",
										"...... (기절한 것 같다.)",
										"이제 겁은 좀 줄었나? 으하하하, 재밌구만."};
				break;
			case 11:
				textData = new string[4] {
										"가정교사들이 다들 금방 그만둬서... 감사합니다.",
										"강속구! 받아낼 수 있다!",
										"공이 내 뒤를 지나가더니 폭발했다.",
										"오늘은 우리 아이 강속구를 잘 받아주셔서 감사드립니다."};
				break;
			case 12:
				textData = new string[4] {
										"내 오뎅은 세계 제일이라고! 알겠냐!",
										"오뎅을 열심히 만들었다. 세계 최고 하이브리드 오뎅!",
										"내 꿈이 오뎅을 만드는 건 아니었는데......",
										"수고 많았다 짜샤! 빨리 집 돌아가서 씻어!"};
				break;
			case 13:
				textData = new string[4] {
										"...에- 일단 이게 오늘의 작업 일지. 에? 완전 까맣다고? 기분 탓이에요.",
										"어른이 되어라- 어른이 되어라-",
										"ERROR",
										"....돌이킬 수 없게 되기 전에 빨리 나가는 게 좋을거에요."};
				break;
			case 14:
				textData = new string[4] {
										"아~ 파칭코 가고 싶다~ 빨리 시작하자~",
										"손에서 얼음을 발사하는 마법을 배웠다.",
										"ERROR",
										"아아~~ 수업 끝~! 그럼 난 파칭코하러 간다~!"};
				break;
			case 15:
				textData = new string[4] {
										"깃발을 잘 쑤시는 게 검술의 기초다죠~!",
										"이 깃발로 다 뚫어버리겠어.",
										"ERROR",
										"다들 깃발과 하나가 되서 기쁘다죠-!"};
				break;
			case 16:
				textData = new string[4] {
										"예의는 모든 것의 기본이랍니다.",
										"다리가 좀 저리는 것 같지만 멋진 인간이 되기 위해선...!",
										"ERROR",
										"앉아있느라 고생 많으셨습니다. 다리는 저리지 않나요?"};
				break;
			case 17:
				textData = new string[4] {
										"자, 열심히 따라해보라냥!",
										"원투쓰리포, 원투쓰리포.",
										"ERROR",
										"수고했다냐~ 정리 깨끗하게 하고 가라냐!"};
				break;
			case 18:
				textData = new string[4] {
										"호에호에, 과학은 아름다운 것이다스.",
										"이 시약과 이 시약을 섞어서....",
										"ERROR",
										"호에호에, 고생했다스. 다음에는 더 대단한 걸 배우겠다스!"};
				break;
			case 19:
				textData = new string[4] {
										"신에 대해서 배우면 신께서 소원을 들어주실 거에요.",
										"정말로 소원을 들어줄까?",
										"ERROR",
										"다음에도 신에 대해 배워보도록 해요."};
				break;
			case 20:
				textData = new string[4] {
										"흐흐.... 저 남자랑 저 남자랑... 이렇게...",
										"너무나도 어려운 미술의 세계...",
										"ERROR",
										"히히.. 그리고 저 남자랑 이 남자랑...."};
				break;
			case 21:
				textData = new string[4] {
										"너희들, 날 따라올 수 있을까?",
										"열심히 농구를 했다.",
										"ERROR",
										"오오~ 잘 따라오는데~ 합격!"};
				break;
			case 22:
				textData = new string[4] {
										"자~ 책 빨리 피렴~ 수업 시작한다!",
										"흑... 너무나도 아름다운 글이군...",
										"ERROR",
										"오늘 수업은 여기까지~"};
				break;
			case 23:
				textData = new string[4] {
										"오늘은 뭘 하면서 놀지? 고민이군....",
										"집에서 뒹굴뒹굴거렸다.",
										"ERROR",
										"푹 쉬었군!"};
				break;
			case 24:
				textData = new string[4] {
										"준비는 다 되셨나요? 그럼 출발하겠습니다!",
										"피서를 즐겼다!",
										"ERROR",
										"즐거웠죠?"};
				break;
		}

		if(isSuccess.HasValue)
			return TextChooser(textData, state, text, isSuccess.Value);
		
		return TextChooser(textData, state, text, true);
	}

	private string TextChooser(string[] textData, string state, string text, bool isSuccess)
	{
		switch (state)
		{
			case "Start":
				return textData[0];
			case "Doing":
				if(isSuccess == true)
				{
					return textData[1];
				}
				else
				{
					return textData[2];
				}
			case "Done":
				return textData[3];
		}

		return "Error at TextChooser";
	}

	private int GetStatusNum(string StatusName)
	{
		for(int i = 0; i < KaramatsuManager.StatusName_Kr.Length; i++)
		{
			if(KaramatsuManager.StatusName_Kr[i] == StatusName)
				return i;
		}

		return 0;
	}
}