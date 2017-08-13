using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkWithFatherManager : MonoBehaviour
{
	public Text dialogueText;

	private int age;
	private string ConversationType;
	private float[] status; //순서대로 0번 : 전사평가, 1번 : 마법평가, 2번 : 사교평가, 3번 : 가사평가, 4번 : 인과
	private string karaText;

	private void TextSelecter(int karaAge, float[] karaStatus, string type)
	{
		int maxStatNum = GetMaxStatNum(karaStatus);
		int randomNum = Random.Range(0, 3);

		switch(type)
		{
			case "Talk": //그냥 대화하는 경우
				switch(maxStatNum)
				{
					case 0: //전사평가가 가장 높을 경우
						if(karaAge >= 12 && karaAge <= 14) //12살에서 14살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
									karaText = "운동하는 건 즐거워.\n(체력 +5)";
									KaramatsuManager.StatusChange("체력", 5);
									break;
								case 1:
									karaText = "검술을 제대로 배워보고 싶어. 멋있을 것 같지 않아? 무기를 휘두르는 내 모습!";
									break;
								case 2:
						karaText = "좀 더 근육이 붙었으면 좋겠어......\n(근력 +5)";
									KaramatsuManager.StatusChange("근력", 5);
									break;
							}
						}
						else if (karaAge >= 15 && karaAge <= 17) // 15살에서 17살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
									karaText = "최근에 곤경에 처한 사람을 도와줬다. 정말로 고마워하더군. 뿌듯했다!\n(도덕성 +10)";
									KaramatsuManager.StatusChange("도덕성", 10);
									break;
								case 1:
									karaText = "새 검이 하나 사고 싶군... 아, 아니 혼잣말이다.";
									break;
								case 2:
						karaText = "검술 실력이 늘 수록, 이 힘을 좀 더 조심히 사용해야겠다는 생각이 든다.\n(성품 +2)";
									KaramatsuManager.StatusChange("성품", 2);
									break;
							}
						}
						else if (karaAge >= 18 && karaAge <= 20) // 18살에서 20살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
						karaText = "길 가다가 건달을 만났다. 물론 내가 훌륭하게 제압했지!\n(스트레스 -10)";
									KaramatsuManager.StatusChange("스트레스", -10);
									break;
								case 1:
									karaText = "미래에 지금까지 배운 검술 실력을 활용할 수 있는 날이 올까?";
									break;
								case 2:
									karaText = "검을 깨끗하게 닦는 것이 하루의 시작! 검은 내 동반자니까 말이다.\n(근력 +5)";
									KaramatsuManager.StatusChange("근력", 5);
									break;
							}
						}
						break;
					case 1: //마법평가가 가장 높을 경우
						if(karaAge >= 12 && karaAge <= 14) //12살에서 14살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
									karaText = "마법에 재능이 있다는 소리를 들었어!";
									break;
								case 1:
						karaText = "마법을 잘 하기 위해선, 자연을 잘 이해해야 하나 봐. 근데 무슨... 원소...? 그건 무슨 소리인지...\n(지능 +5)";
									KaramatsuManager.StatusChange("지능", 5);
									break;
								case 2:
									karaText = "언젠가는 하늘을 날아보고 싶어.\n(감수성 +5)";
									KaramatsuManager.StatusChange("감수성", 5);
									break;
							}
						}
						else if (karaAge >= 15 && karaAge <= 17) // 15살에서 17살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
									karaText = "마법의 길은 아직도 멀고 멀었다는 생각이 든다......";
									break;
								case 1:
						karaText = "이젠 원소에 대해 좀 알 것 같다!\n(지능 +5)";
									KaramatsuManager.StatusChange("지능", 5);
									break;
								case 2:
						karaText = "언젠가 마법을 더 잘하게 되면 여러 곳에 여행을 다니고 싶다!\n(감수성 +5)";
									KaramatsuManager.StatusChange("감수성", 5);
									break;
							}
						}
						else if (karaAge >= 18 && karaAge <= 20) // 18살에서 20살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
						karaText = "빗자루가 가지고 싶군. 그게 있다면 어디든지 갈 수 있을 텐데.\n(감수성 +5)";
									KaramatsuManager.StatusChange("감수성", 5);
									break;
								case 1:
									karaText = "드래곤이라는 생물이 존재한다고 들었다. 한 번 그 존재를 눈으로 새기고 싶군.";
									break;
								case 2:
						karaText = "아무래도 내 특기는 얼음마법인 것 같다. 여름에는 시원하게 지낼 수 있겠어!\n(스트레스 -10)";
									KaramatsuManager.StatusChange("스트레스", -10);
									break;
							}
						}
						break;
					case 2: //사교평가가 가장 높을 경우
						if(karaAge >= 12 && karaAge <= 14) //12살에서 14살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
									karaText = "사람 만나는 건 즐거운 것 같아.";
									break;
								case 1:
									karaText = "언젠가 멋진 옷을 입고 성에서 춤춰보고 싶어!\n(스트레스 -5)";
									KaramatsuManager.StatusChange("스트레스", -5);
									break;
								case 2:
					 				karaText = "흥~흐흥~ (카라마츠는 거울을 보고 있다.)\n(매력 +5)";
									KaramatsuManager.StatusChange("매력", 5);
									break;
							}
						}
						else if (karaAge >= 15 && karaAge <= 17) // 15살에서 17살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
						karaText = "최근 사람 좋다는 소리를 들었다. 왠지 부끄럽군......\n(스트레스 -5)";
									KaramatsuManager.StatusChange("스트레스", -5);
									break;
								case 1:
									karaText = "더 많은 사람과 만나보고 싶다.";
									break;
								case 2:
						karaText = "요즘은 사람을 이끄는 것도 꽤 해볼만한 경험이라는 생각이 든다.\n(체력 +5)";
									KaramatsuManager.StatusChange("체력", 5);
									break;
							}
						}
						else if (karaAge >= 18 && karaAge <= 20) // 18살에서 20살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
						karaText = "사람 앞에 나서서 잘 이끌 수 있는 인물, 그건 나라는 존재겠지~! 흐흥~?\n(스트레스 -10)";
									KaramatsuManager.StatusChange("스트레스", -10);
									break;
								case 1:
						karaText = "나중엔 사람과 대화하면서 그 사람들의 이야기를 들어주는, 그런 일이 하고 싶다.\n(도덕성 +10)";
									KaramatsuManager.StatusChange("도덕성", 10);
									break;
								case 2:
									karaText = "인간관계는 참 복잡한 것 같다.";
									break;
							}
						}
						break;
					case 3: //가사평가가 가장 높을 경우
						if(karaAge >= 12 && karaAge <= 14) //12살에서 14살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
						karaText = "집안일을 도와주는다는 거, 생각보다 어려운 거 같아.\n(도덕성 +5)";
									KaramatsuManager.StatusChange("도덕성", 5);
									break;
								case 1:
									karaText = "저 손재주가 좋은 편인가요? 이불 같은 건 잘 꼬맬 수 있는데!";
									break;
								case 2:
									karaText = "쵸로마츠가 나한테 아직 멀었다고 했어요. 언젠간 그 말을 한 걸 후회하게 해 주지!\n(체력 +5)";
									KaramatsuManager.StatusChange("체력", 5);
									break;
							}
						}
						else if (karaAge >= 15 && karaAge <= 17) // 15살에서 17살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
									karaText = "요즘은 나도 집안일을 잘 하지 않나~? 흐흥~?\n(스트레스 -10)";
									KaramatsuManager.StatusChange("스트레스", -10);
									break;
								case 1:
									karaText = "쵸로마츠가 아직도 갈 길이 멀었다고 했다. 집사란 대단한 직업이군......";
									break;
								case 2:
									karaText = "최근에 찰흙으로 상어 동상을 만들었다만, 꽤 리얼리티하지 않나?\n(감수성 +5)";
									KaramatsuManager.StatusChange("감수성", 5);
									break;
							}
						}
						else if (karaAge >= 18 && karaAge <= 20) // 18살에서 20살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
									karaText = "쵸로마츠가 드디어 날 인정해준 것 같다!\n(스트레스 -10)";
									KaramatsuManager.StatusChange("스트레스", -10);
									break;
								case 1:
									karaText = "카라아게란… 인간이 발명한 최고의 음식...... 아침 점심 저녁 전부 카라아게만 먹고 싶군!";
									break;
								case 2:
									karaText = "집안일에도 체력이 필요한 것 같다. 다 끝나고 나면 엄청 피곤하거든.\n(체력 +5)";
									KaramatsuManager.StatusChange("체력", 5);
									break;
							}
						}
						break;
					case 4: //인과가 가장 높을 경우
						if(karaAge >= 12 && karaAge <= 14) //12살에서 14살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
									karaText = "신사 말인데, 그곳에 가면 왠지 편안하단 말이지.";
									break;
								case 1:
									karaText = "신사에 여우 동상이 있어. 근데 그거, 움직인다더라!?";
									break;
								case 2:
									karaText = "신사에 있는 사람 되게 친절한 것 같아.";
									break;
							}
						}
						else if (karaAge >= 15 && karaAge <= 17) // 15살에서 17살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
									karaText = "......아, 불렀나? 미안하군. 잠시 딴 생각하고 있었다.";
									break;
								case 1:
									karaText = "(카라마츠는 먼 곳을 보고 있다.)";
									break;
								case 2:
									karaText = "더 이상 신사에 가지 않는 편이 좋을 지도 모르겠다.....";
									break;
							}
						}
						else if (karaAge >= 18 && karaAge <= 20) // 18살에서 20살 사이 일 경우
						{
							switch(randomNum)
							{
								case 0:
									karaText = ".................. (불러도 반응이 없다.)";
									break;
								case 1:
									karaText = "곧... 작별인사를 해야 할 지도 모르겠군......(혼잣말을 중얼거리고 있지만, 잘 들리지 않는다.)";
									break;
								case 2:
									karaText = "아, 불렀나? 못 들었다, 미안하군. (3번 부르고 나서야 이 쪽을 돌아봤다.)";
									break;
							}
						}
						break;
				}
				
				break;
			case "Sermon": //설교하는 경우
				if(karaAge >= 12 && karaAge <= 14) //12살에서 14살 사이 일 경우
				{
					switch(randomNum)
					{
						case 0:
					karaText = "............\n(스트레스 +10)";
							KaramatsuManager.StatusChange("스트레스", 10);
							break;
						case 1:
					karaText = "제가 뭘 잘못했....나요?\n(성품 +2)";
							KaramatsuManager.StatusChange("성품", 2);
							break;
						case 2:
					karaText = "죄송합니다......\n(도덕성 +10)";
							KaramatsuManager.StatusChange("도덕성", 10);
							break;
					}
				}
				else if (karaAge >= 15 && karaAge <= 17) // 15살에서 17살 사이 일 경우
				{
					switch(randomNum)
					{
						case 0:
					karaText = "...........\n(스트레스 +10)";
							KaramatsuManager.StatusChange("스트레스", 10);
							break;
						case 1:
					karaText = "다음부터는 그러지 않겠...습니다.\n(도덕성 +10)";
							KaramatsuManager.StatusChange("도덕성", 10);
							break;
						case 2:
					karaText = "내가 뭘 잘못했다는 건가?\n(스트레스 +10)";
							KaramatsuManager.StatusChange("스트레스", 10);
							break;
					}
				}
				else if (karaAge >= 18 && karaAge <= 20) // 18살에서 20살 사이 일 경우
				{
					switch(randomNum)
					{
						case 0:
					karaText = ".......................................\n(스트레스 +10)";
							KaramatsuManager.StatusChange("스트레스", 10);
							break;
						case 1:
					karaText = "나도 이제 다 컸다만... 너무 신경쓰는 게 아닌가?\n(스트레스 +10)";
							KaramatsuManager.StatusChange("스트레스", 10);
							break;
						case 2:
					karaText = "으음…. 미안하다. 다시는 안 그러도록 하지.\n(도덕성 +10)";
							KaramatsuManager.StatusChange("도덕성", 10);
							break;
					}
				}
				break;
			case "Money": //용돈 주는 경우
				if(karaAge >= 12 && karaAge <= 14) //12살에서 14살 사이 일 경우
				{
				karaText = "헉, 용돈.....! 감사합니다!\n(스트레스 -20)";

					switch(karaAge)
					{
						case 12:
							KaramatsuManager.Gold -= 10;
							break;
						case 13:
							KaramatsuManager.Gold -= 20;
							break;
						case 14:
							KaramatsuManager.Gold -= 30;
							break;
					}
				}
				else if(karaAge >= 15 && karaAge <= 17) //15살에서 17살 사이 일 경우
				{
				karaText = "오오, 이걸로 새 옷을 살 수 있겠군!\n(스트레스 -20)";

					switch(karaAge)
					{
						case 15:
							KaramatsuManager.Gold -= 40;
							break;
						case 16:
							KaramatsuManager.Gold -= 50;
							break;
						case 17:
							KaramatsuManager.Gold -= 60;
							break;
					}
				}
				else if(karaAge >= 18 && karaAge <= 20) //18살에서 20살 사이 일 경우
				{
				karaText = "마침 조금 부족한 참이었는데... 고맙다. 아껴서 쓰도록 하지.\n(스트레스 -20)";

					switch(karaAge)
					{
						case 18:
							KaramatsuManager.Gold -= 70;
							break;
						case 19:
							KaramatsuManager.Gold -= 80;
							break;
						case 20:
							KaramatsuManager.Gold -= 90;
							break;
					}
				}
				break;
		}
	}

	private int GetMaxStatNum(float[] karaStatus)
	{
		int maxStatNum = 0;

		for(int i = 0; i < karaStatus.Length; i++)
		{
			if(karaStatus[maxStatNum] < karaStatus[i])
			{
				maxStatNum = i;
			}
		}

		return maxStatNum;
	}

	public void TextShower(string dialogueType)
	{
		status = new float[5] {KaramatsuManager.Status[22], KaramatsuManager.Status[23], KaramatsuManager.Status[24], KaramatsuManager.Status[25], KaramatsuManager.Status[8]};
		age = KaramatsuManager.KaraAge;
		ConversationType = dialogueType;

		TextSelecter(age, status, ConversationType);

		dialogueText.text = karaText;
	}
}