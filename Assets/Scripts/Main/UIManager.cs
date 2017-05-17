using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public GameObject ScheduleIconPanel;
	public GameObject ScheduleMenu;
	public GameObject Profile;
	public GameObject DateDisplay;
	public GameObject Calendar;
	public GameObject StatusIndex;
	public GameObject PartTimeJobIndex;
	public GameObject EducationIndex;
	public GameObject RestIndex;
	public GameObject RunOrCancel;
	public GameObject RunningSchedule;
	public GameObject WorkAnimation;
	public GameObject WorkText;
	public GameObject profileImage;
	public GameObject ParameterChange;

	public Text Year;
	public Text Month;
	public Text Day;
	public Text Date;
	public Text Age;

	public void Start()
	{
		ScheduleIconPanel.SetActive(true);
		ScheduleMenu.SetActive(false);
		Profile.SetActive(true);
		DateDisplay.SetActive(true);
		Calendar.SetActive(false);
		StatusIndex.SetActive(false);
		PartTimeJobIndex.SetActive(false);
		EducationIndex.SetActive(false);
		RestIndex.SetActive(false);
		RunOrCancel.SetActive(false);
		RunningSchedule.SetActive(false);
	}

	private void Update()
	{
		Year.text = DayManager.Year.ToString();
		Month.text = DayManager.Month.ToString();
		Date.text = DayManager.Date.ToString();
		Age.text = KaramatsuManager.KaraAge.ToString();
		DayController();
	}

	public void SchedulingMode()
	{
		ScheduleIconPanel.SetActive(false);
		ScheduleMenu.SetActive(true);
		Profile.SetActive(true);
		DateDisplay.SetActive(true);
		Calendar.SetActive(true);
		StatusIndex.SetActive(false);
		PartTimeJobIndex.SetActive(false);
		EducationIndex.SetActive(false);
		RestIndex.SetActive(false);
		RunOrCancel.SetActive(false);
		RunningSchedule.SetActive(false);
	}

	public void RunOrCancelMode()
	{
		ScheduleIconPanel.SetActive(false);
		ScheduleMenu.SetActive(false);
		Profile.SetActive(true);
		DateDisplay.SetActive(true);
		Calendar.SetActive(true);
		StatusIndex.SetActive(false);
		PartTimeJobIndex.SetActive(false);
		EducationIndex.SetActive(false);
		RestIndex.SetActive(false);
		RunOrCancel.SetActive(true);
		RunningSchedule.SetActive(false);
	}

	public void RunSchedule()
	{
		ScheduleIconPanel.SetActive(false);
		ScheduleMenu.SetActive(false);
		Profile.SetActive(true);
		DateDisplay.SetActive(true);
		Calendar.SetActive(false);
		StatusIndex.SetActive(false);
		PartTimeJobIndex.SetActive(false);
		EducationIndex.SetActive(false);
		RestIndex.SetActive(false);
		RunOrCancel.SetActive(false);
		RunningSchedule.SetActive(true);
	}

	public void StartWork()
	{
		WorkAnimation.SetActive(true);
		WorkText.SetActive(true);
		profileImage.SetActive(false);
		ParameterChange.SetActive(true);
	}

	public void EndWork()
	{
		WorkAnimation.SetActive(false);
		WorkText.SetActive(true);
		profileImage.SetActive(true);
		ParameterChange.SetActive(false);
	}

	private void DayController()
	{
		switch(DayManager.Day)
		{
			case 0:
				Day.text = "월";
				break;
			case 1:
				Day.text = "화";
				break;
			case 2:
				Day.text = "수";
				break;
			case 3:
				Day.text = "목";
				break;
			case 4:
				Day.text = "금";
				break;
			case 5:
				Day.text = "토";
				break;
			case 6:
				Day.text = "일";
				break;
			default:
				Debug.Log("Something is Wrong at DateController in UIManager");
				break;				
		}
	}
}
