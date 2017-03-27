using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
	public int Year;
	public int Month;
	public int Date;
	public int Day;

	private void Start()
	{
		if(!(PlayerPrefs.HasKey("Year")))
		{
			PlayerPrefs.SetInt("Year", 625);
			Debug.Log("No PlayerPrefs at Year! So assign 625");
		}
		if(!(PlayerPrefs.HasKey("Month")))
		{
			PlayerPrefs.SetInt("Month", 5);
			Debug.Log("No PlayerPrefs at Month! So assign 5");
		}
		if(!(PlayerPrefs.HasKey("Date")))
		{
			PlayerPrefs.SetInt("Date", 1);
			Debug.Log("No PlayerPrefs at Date! So assign 1");
		}
	}

	private void Update()
	{
		GetDateInfoFromPlayerPrefs();
		ErrorChecking();

		CalculateDay();
	}

	private void GetDateInfoFromPlayerPrefs()
	{
		Year = PlayerPrefs.GetInt("Year");
		Month = PlayerPrefs.GetInt("Month");
		Date = PlayerPrefs.GetInt("Date");
	}

	private void ErrorChecking()
	{
		if(Year < 625)
		{
			Debug.Log("Something is Wrong at DayManager, Year is under 625!");
		}
		if(Month > 12)
		{
			Debug.Log("Something is Wrong at DayManager, Month is over 12!");
		}
		if(Date > 30)
		{
			Debug.Log("Something is Wrong at DayManager, Date is over 30!");
		}
	}

	private void CalculateDay()
	{
		int DateGap;

		DateGap = 3 * Year + 2 * Month + Date - 3;

		Day = DateGap % 7;
	}
}
