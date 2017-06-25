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
			case 0:
			SetParameter(11, 12, 0, 0, 0);
			break;
			case 1:
			SetParameter(18, 19, 20, 0, 0);
			break;
			case 2:
			SetParameter(11, 20, 0, 0, 0);
			break;
			case 3:
			SetParameter(8, 9, 0, 0, 0);
			break;
			case 4:
			SetParameter(1, 2, 9, 11, 0);
			break;
			case 5:
			SetParameter(11, 12, 0, 0, 0);
			break;
			case 6:
			SetParameter(3, 4, 8, 0, 0);
			break;
			case 7:
			SetParameter(7, 11, 16, 9, 18);
			break;
			case 8:
			SetParameter(11, 12, 0, 0, 0);
			break;
			case 9:
			SetParameter(1, 2, 3, 0, 0);
			break;
			case 10:
			SetParameter(19, 0, 0, 8, 12);
			break;
			case 11:
			SetParameter(3, 13, 0, 0, 8);
			break;
			case 12:
			SetParameter(4, 11, 15, 0, 18);
			break;
			case 13:
			SetParameter(0, 0, 0, 0, 0);
			break;
			case 14:
			SetParameter(4, 8, 0, 0, 0);
			break;
			case 15:
			SetParameter(11, 12, 0, 0, 0);
			break;
			case 16:
			SetParameter(4, 11, 15, 0, 0);
			break;
			case 17:
			SetParameter(5, 6, 0, 0, 0);
			break;
			case 18:
			SetParameter(12, 14, 16, 0, 0);
			break;
			case 19:
			SetParameter(5, 6, 13, 0, 0);
			break;
			case 20:
			SetParameter(17, 0, 0, 0, 0);
			break;
			case 21:
			SetParameter(4, 10, 0, 0, 0);
			break;
			case 22:
			SetParameter(13, 0, 0, 0, 0);
			break;
			case 23:
			SetParameter(3, 13, 14, 0, 0);
			break;
			case 24:
			SetParameter(13, 19, 20, 0, 0);
			break;
			case 25:
			SetParameter(0, 0, 0, 0, 0);
			break;
			case 26:
			SetParameter(0, 0, 0, 0, 0);
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
			case 0:
			ChangeParameter(0, 4);
			ChangeParameter(11, 2);
			ChangeParameter(12, 2);
			break;
			case 1:
			ChangeParameter(0, 2);
			ChangeParameter(18, 2);
			ChangeParameter(19, 2);
			ChangeParameter(20, 2);
			break;
			case 2:
			ChangeParameter(0, 2);
			ChangeParameter(11, 2);
			ChangeParameter(20, 2);
			break;
			case 3:
			ChangeParameter(0, 3);
			ChangeParameter(8, 2);
			ChangeParameter(9, 2);
			break;
			case 4:
			ChangeParameter(0, 1);
			ChangeParameter(1, 2);
			ChangeParameter(2, 2);
			ChangeParameter(9, 2);
			ChangeParameter(11, 1);
			break;
			case 5:
			ChangeParameter(0, 5);
			ChangeParameter(11, 3);
			ChangeParameter(12, 3);
			break;
			case 6:
			ChangeParameter(0, 4);
			ChangeParameter(3, 3);
			ChangeParameter(4, 3);
			ChangeParameter(8, 2);
			break;
			case 7:
			ChangeParameter(0, 3);
			ChangeParameter(7, 3);
			ChangeParameter(11, 2);
			ChangeParameter(16, 3);
			ChangeParameter(9, -4);
			ChangeParameter(18, -4);
			break;
			case 8:
			ChangeParameter(0, 5);
			ChangeParameter(11, 4);
			ChangeParameter(12, 3);
			break;
			case 9:
			ChangeParameter(0, 3);
			ChangeParameter(1, 3);
			ChangeParameter(2, 2);
			ChangeParameter(3, 1);
			break;
			case 10:
			ChangeParameter(0, 4);
			ChangeParameter(19, 2);
			ChangeParameter(8, -4);
			ChangeParameter(12, -4);
			break;
			case 11:
			ChangeParameter(0, 3);
			ChangeParameter(3, 2);
			ChangeParameter(13, 3);
			ChangeParameter(8, -4);
			break;
			case 12:
			ChangeParameter(0, 5);
			ChangeParameter(4, 3);
			ChangeParameter(11, 2);
			ChangeParameter(15, 3);
			ChangeParameter(18, -4);
			break;
			case 13:
			ChangeParameter(0, 20);
			break;
			case 14:
			ChangeParameter(0, 1);
			ChangeParameter(4, 8);
			ChangeParameter(8, 8);
			break;
			case 15:
			ChangeParameter(0, 2);
			ChangeParameter(11, 8);
			ChangeParameter(12, 8);
			break;
			case 16:
			ChangeParameter(0, 2);
			ChangeParameter(4, 11);
			ChangeParameter(11, 11);
			ChangeParameter(15, 11);
			break;
			case 17:
			ChangeParameter(0, 1);
			ChangeParameter(5, 9);
			ChangeParameter(6, 9);
			break;
			case 18:
			ChangeParameter(0, 2);
			ChangeParameter(12, 15);
			ChangeParameter(14, 15);
			ChangeParameter(16, 15);
			break;
			case 19:
			ChangeParameter(0, 1);
			ChangeParameter(5, 8);
			ChangeParameter(6, 8);
			ChangeParameter(13, 8);
			break;
			case 20:
			ChangeParameter(0, 1);
			ChangeParameter(17, 8);
			break;
			case 21:
			ChangeParameter(0, 1);
			ChangeParameter(4, 13);
			ChangeParameter(10, 13);
			break;
			case 22:
			ChangeParameter(0, 1);
			ChangeParameter(13, 6);
			break;
			case 23:
			ChangeParameter(0, 2);
			ChangeParameter(3, 15);
			ChangeParameter(13, 15);
			ChangeParameter(14, 15);
			break;
			case 24:
			ChangeParameter(0, 1);
			ChangeParameter(13, 8);
			ChangeParameter(19, 8);
			ChangeParameter(20, 8);
			break;
			case 25:
			ChangeParameter(0, -5);
			break;
			case 26:
			ChangeParameter(0, -10);
			break;
			default:
				Debug.Log("Something is Wrong at UpdateParameter in RunningSchedule");
				break;
		}
	}

	private void SetParameter(int P1, int P2, int P3, int P4, int P5)
	{
		List<int> parameters = new List<int> {
			P1, P2, P3, P4, P5
		};

		for (int i = 0; i < 5; i++)
		{
			int parameter = parameters[i];
			int visualIndex = i+1;
			if (parameter != 0)
			{
				LoadParameter(visualIndex, parameter);
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

	private void ChangeParameter(int WhichParameter, int ChangeAmount)
	{
		KaramatsuManager.Status[WhichParameter] = KaramatsuManager.Status[WhichParameter] + ChangeAmount;

		if(KaramatsuManager.Status[WhichParameter] < 0)
			KaramatsuManager.Status[WhichParameter] = 0;
		else if(KaramatsuManager.Status[WhichParameter] > 999)
			KaramatsuManager.Status[WhichParameter] = 999;
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
										"우오오! 야구할래? 야구? 에? 야구하는거 아니야!? 시무룩......",
										"오늘은 sunshine을 맞으면서 열심히 곡식을 키웠다.",
										"인간은 가끔 고독을 즐기고 싶을 때가 있다.",
										"가보로 삼아야제~~~!!!"};
				break;
			case 1:
				textData = new string[4] {
										"청소하다가 땡땡이 치지나 말라구! 내가 계속 감시하고 있을 테니까~!",
										"성당 청소를 깨끗이 하는….오레!",
										"성당에 있는 거울에 비친 내가 너무 멋있어서 그만 땡땡이쳤다.",
										"와~ 다시 봤어! 진짜! 다음에도 잘 부탁해~♡ 고마워서 조금 더 넣었으니까 감사히 여기라구~!"};
				break;
			case 2:
				textData = new string[4] {
										"올라오느라 고생 많으셨죠? 청소 잘 부탁드립니다.",
										"신사의 정취를 맡으며 청소를 열심히 했다.",
										"신사의 정취가 아름다워 지붕에 올라가서 자작곡을 한 곡 뽑았다.",
										"감사합니다, 덕분에 한 시름 놓았어요. 얼마 안 되지만 이건 추가금입니다."};
				break;
			case 3:
				textData = new string[4] {
										"아이가 울거나 하면 빨리 우릴 불러야 해!",
										"아이가 내 말을 잘 들었다. 역시 매력적인 오레!",
										"아이가 울고불고 난리를 쳐서 급하게 사람을 부르러 갔다......",
										"아이들이 카라마츠 군을 참 좋아하는 것 같아! 약간 더 넣어줬으니까 자주 와!"};
				break;
			case 4:
				textData = new string[4] {
										"제가 하라는 대로 하시면 됩니다!",
										"집안일을 열심히 도왔다.",
										"평생 부양받으면서 살고 싶다......",
										"와~ 도련님 이제 진짜 집안일 마스터라고 불러도 되겠는데요! 덕분에 경비를 아낄 수 있었어요~"};
				break;
			case 5:
				textData = new string[4] {
										"누구든지 노력하면 석유왕이 될 수 있습니다!",
										"일확천금의 꿈...!",
										"금수저에게 그런 말 들어봤자......",
										"오 판타스틱~~! 이건 추가 수당입니다! 다시 와 주시기를."};
				break;
			case 6:
				textData = new string[4] {
										"어머어머~~! 어서와~~!",
										"오늘은 손님들의 머리를 열심히 잘라주었다.",
										"너무나도 어려운 예술의 세계......",
										"아앙~! 쥬시코 너무 감동했어~! 이건 약간이지만 팁~!"};
				break;
			case 7:
				textData = new string[4] {
										"어렵지 않아~~용~~~!!",
										"훗, 영혼들에게 구원을......",
										"내가 사냥을 하는 건지 사냥을 당하는 건지......",
										"훗, 대단하군 이것은 추가 보상이다."};
				break;
			case 8:
				textData = new string[4] {
										"우효효효효~ 택배회사에 어서오쌈바!",
										"오늘도 택배를 주인들에게 전달해주었다.",
										"택배가 주인들을 스스로 찾아갔으면 좋겠다......",
										"우효효효~! 덕분에 수익이 엄청 늘... 흠흠, 여기는 추가 수당이쌈바!"};
				break;
			case 9:
				textData = new string[4] {
										"어서 와. 호텔 일도 어렵진 않을 거야.",
										"오늘도 호텔은 뷰티풀하군...!",
										"호텔 침대가 너무 따뜻해보여서 잠들어버리고 말았다.",
										"좋아, 이 정도면 휴가 딸 수 있겠어! 이건 추가 수당이야."};
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
										"타케시의 강속구! 받아낼 수 있다!",
										"공이 내 뒤를 지나가더니 폭발했다.",
										"오늘은 정말 재밌었어요! 다음에도 함께 해요!"};
				break;
			case 12:
				textData = new string[4] {
										"내 오뎅은 세계 제일이라고! 알겠냐!",
										"오뎅을 열심히 만들었다. 세계 최고 하이브리드 오뎅!",
										"내 꿈이 오뎅을 만드는 건 아니었는데......",
										"오~~ 대단한데 짜샤! 제자로 받아도 되겠어!"};
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
										"흐흥~ 미술의 세계는 너무 아름답지. 오늘도 저 사람이랑 저 사람이... 후후후...",
										"아름다운 미술의 세계... 마치 나와 같군...",
										"ERROR",
										"다음 수업에도 멋진 작품 부탁한다구요~~~!"};
				break;
			case 15:
				textData = new string[4] {
										"너희들이 내 스파르타 교육을 따라올 수 있을까?",
										"원 투 원 투",
										"ERROR",
										"내 수업에 잘 따라오다니, 합격!"};
				break;
			case 16:
				textData = new string[4] {
										"다들 잘 왔다냐-!",
										"이걸로 나도 인기있을 수 있는 걸까?",
										"ERROR",
										"무용을 열심히 하면 인기있을 수 있다냐-!"};
				break;
			case 17:
				textData = new string[4] {
										"예절은 모든 것의 기본입니다. 오늘도 힘내요~",
										"이걸 견디는 것도 멋진 사람이 되기 위한 한 걸음...",
										"ERROR",
										"다들 다리가 저릴 텐데 적당히 풀어주고 가세요~"};
				break;
			case 18:
				textData = new string[4] {
										"어서와아~ 오늘도 친구들이 잔뜩 왔어어~",
										"나무 인형을... 열심히 쑤셨다..!!",
										"ERROR",
										"다음에도 같이 놀자아~~!"};
				break;
			case 19:
				textData = new string[4] {
										"문학은 말이지 모든 사람의 기초 교양이라구!",
										"아름다운 문학에 눈물을 흘릴 수밖에 없었다....",
										"ERROR",
										"자, 다음 범위는 여기까지니까 한 번씩 읽어보고 와!"};
				break;
			case 20:
				textData = new string[4] {
										"에~ 수업하기 귀찮은데...... 파칭코 치러 가면 안 될까......",
										"선생은 좀 못 미덥지만 실력은 출중한 것 같다.....!",
										"ERROR",
										"에? 끝났어? 나 이제 파칭코 치러 가도 되는거지?"};
				break;
			case 21:
				textData = new string[4] {
										"자, 다들 주목주목~! 수업 시작할거에요~!",
										"내 뜨거운 러브송.....!",
										"ERROR",
										"음, 쟤는 목소리는 좋은데 가사 영문을 모르겠네..."};
				break;
			case 22:
				textData = new string[4] {
										"호에호에, 다들 제가 만든 신약을 감상하실 시간이다스!",
										"오오, 이 약은.....!",
										"ERROR",
										"호에호에, 다음에는 더 멋진 걸 보여드리겠다스!"};
				break;
			case 23:
				textData = new string[4] {
										"알겠나, 연기를 통해서 몸과 마음을 갈고 닦을 수 있다!",
										"훗, 이 선생님과는 영혼의 파장이 맞는 것 같다..!",
										"ERROR",
										"오늘은 너무 뷰티풀한 모습들이었다... 다음에도 기대하도록 하지!"};
				break;
			case 24:
				textData = new string[4] {
										"신님은 반드시 존재한다구요!",
										"신이란 무엇일까?",
										"ERROR",
										"신님에 대한 믿음이 좀 생기셨나요?"};
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
}