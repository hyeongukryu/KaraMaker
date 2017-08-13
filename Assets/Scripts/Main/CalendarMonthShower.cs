using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarMonthShower : MonoBehaviour
{
	private int month;

	private void Update()
	{
		month = DayManager.Month;

		GetComponent<Text>().text = month.ToString();
	}
}