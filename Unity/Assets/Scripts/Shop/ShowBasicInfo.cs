using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBasicInfo : MonoBehaviour
{
	public Text Year_Text;
	public Text Month_Text;
	public Text Date_Text;
	public Text Day_Text;
	public Text Age_Text;
	public Text Gold_Text;

	private void Update()
	{
		Year_Text.text = DayManager.Year.ToString();
		Month_Text.text = DayManager.Month.ToString();
		Date_Text.text = DayManager.Date.ToString();
		Day_Text.text = DayToString();
		Age_Text.text = KaramatsuManager.KaraAge.ToString();
		Gold_Text.text = KaramatsuManager.Gold.ToString();
	}

	private string DayToString()
	{
		switch(DayManager.Day)
		{
			case 0:
				return "월";
			case 1:
				return "화";
			case 2:
				return "수";
			case 3:
				return "목";
			case 4:
				return "금";
			case 5:
				return "토";
			case 6:
				return "일";				
		}

		return "??";
	}
}