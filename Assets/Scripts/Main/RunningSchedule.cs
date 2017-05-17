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
	public Text NPCText;

	public int[] ScheduleList;

	private string workIs;
	private float GameTime;

	private void Start()
	{
		GetComponent<UIManager>().EndWork();

		for(int i = 0; i < 6; i++)
		{
			Parameter[i].SetActive(false);
		}

		GameTime = 0;
		workIs = "Start";
	}

	private void Update()
	{
		SetNPCText();

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

		if(DayManager.Date >= 1 && DayManager.Date <= 10)
		{
			SettingParameter(ScheduleList[0]);

			if(GameTime >= 1f)
			{
				UpdateParameter(ScheduleList[0]);

				GameTime = 0;
				if(DayManager.Date == 10)
				{
					workIs = "Done";
					return;
				}

				DayManager.Date = DayManager.Date + 1;
			}
		}
		else if(DayManager.Date >= 11 && DayManager.Date <= 20)
		{
			SettingParameter(ScheduleList[1]);

			if(GameTime >= 1f)
			{
				UpdateParameter(ScheduleList[1]);

				GameTime = 0;
				if(DayManager.Date == 20)
				{
					workIs = "Done";
					return;
				}

				DayManager.Date = DayManager.Date + 1;
			}
		}
		else if(DayManager.Date >= 21 && DayManager.Date <= 30)
		{
			SettingParameter(ScheduleList[2]);

			if(GameTime >= 1f)
			{
				UpdateParameter(ScheduleList[2]);

				GameTime = 0;
				if(DayManager.Date == 30)
				{
					workIs = "Done";
					return;
				}

				DayManager.Date = DayManager.Date + 1;
			}
		}
		else
		{
			Debug.Log("Date is Over 30 or Lower than 1");
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
			ChangeParameter(11, 4);
			ChangeParameter(12, 4);
			break;
			case 1:
			ChangeParameter(0, 2);
			ChangeParameter(18, 4);
			ChangeParameter(19, 4);
			ChangeParameter(20, 4);
			break;
			case 2:
			ChangeParameter(0, 2);
			ChangeParameter(11, 4);
			ChangeParameter(20, 4);
			break;
			case 3:
			ChangeParameter(0, 3);
			ChangeParameter(8, 4);
			ChangeParameter(9, 4);
			break;
			case 4:
			ChangeParameter(0, 1);
			ChangeParameter(1, 4);
			ChangeParameter(2, 4);
			ChangeParameter(9, 4);
			ChangeParameter(11, 4);
			break;
			case 5:
			ChangeParameter(0, 5);
			ChangeParameter(11, 4);
			ChangeParameter(12, 4);
			break;
			case 6:
			ChangeParameter(0, 4);
			ChangeParameter(3, 4);
			ChangeParameter(4, 4);
			ChangeParameter(8, 4);
			break;
			case 7:
			ChangeParameter(0, 3);
			ChangeParameter(7, 4);
			ChangeParameter(11, 4);
			ChangeParameter(16, 4);
			ChangeParameter(9, -4);
			ChangeParameter(18, -4);
			break;
			case 8:
			ChangeParameter(0, 5);
			ChangeParameter(11, 4);
			ChangeParameter(12, 4);
			break;
			case 9:
			ChangeParameter(0, 3);
			ChangeParameter(1, 4);
			ChangeParameter(2, 4);
			ChangeParameter(3, 4);
			break;
			case 10:
			ChangeParameter(0, 4);
			ChangeParameter(19, 4);
			ChangeParameter(8, -4);
			ChangeParameter(12, -4);
			break;
			case 11:
			ChangeParameter(0, 3);
			ChangeParameter(3, 4);
			ChangeParameter(13, 4);
			ChangeParameter(8, -4);
			break;
			case 12:
			ChangeParameter(0, 5);
			ChangeParameter(4, 4);
			ChangeParameter(11, 4);
			ChangeParameter(15, 4);
			ChangeParameter(18, -4);
			break;
			case 13:
			ChangeParameter(0, 20);
			break;
			case 14:
			ChangeParameter(0, 1);
			ChangeParameter(4, 3);
			ChangeParameter(8, 3);
			break;
			case 15:
			ChangeParameter(0, 2);
			ChangeParameter(11, 3);
			ChangeParameter(12, 3);
			break;
			case 16:
			ChangeParameter(0, 2);
			ChangeParameter(4, 3);
			ChangeParameter(11, 3);
			ChangeParameter(15, 3);
			break;
			case 17:
			ChangeParameter(0, 1);
			ChangeParameter(5, 3);
			ChangeParameter(6, 3);
			break;
			case 18:
			ChangeParameter(0, 2);
			ChangeParameter(12, 3);
			ChangeParameter(14, 3);
			ChangeParameter(16, 3);
			break;
			case 19:
			ChangeParameter(0, 1);
			ChangeParameter(5, 3);
			ChangeParameter(6, 3);
			ChangeParameter(13, 3);
			break;
			case 20:
			ChangeParameter(0, 1);
			ChangeParameter(17, 3);
			break;
			case 21:
			ChangeParameter(0, 1);
			ChangeParameter(4, 3);
			ChangeParameter(10, 3);
			break;
			case 22:
			ChangeParameter(0, 1);
			ChangeParameter(13, 3);
			break;
			case 23:
			ChangeParameter(0, 2);
			ChangeParameter(3, 3);
			ChangeParameter(13, 3);
			ChangeParameter(14, 3);
			break;
			case 24:
			ChangeParameter(0, 1);
			ChangeParameter(13, 3);
			ChangeParameter(19, 3);
			ChangeParameter(20, 3);
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

	private void SetNPCText()
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

		if(workIs == "Start")
		{
			NPCText.text = "선택한 스케쥴은 " + ScheduleList[i] + "입니다.";
		}
		else if(workIs == "Doing")
		{
			NPCText.text = ScheduleList[i] + "를 하고 있습니다.";
		}
		else if(workIs == "Done")
		{
			NPCText.text = ScheduleList[i] + "를 끝냈습니다.";
		}
	}
}