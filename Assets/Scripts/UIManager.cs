using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public GameObject RunOrCancel;

	private void Start()
	{
		ScheduleIconPanel.SetActive(true);
		ScheduleMenu.SetActive(false);
		Profile.SetActive(true);
		DateDisplay.SetActive(true);
		Calendar.SetActive(false);
		StatusIndex.SetActive(false);
		PartTimeJobIndex.SetActive(false);
		EducationIndex.SetActive(false);
		RunOrCancel.SetActive(false);
	}
}
