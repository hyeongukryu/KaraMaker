using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
	private bool IsFinalDay()
	{
		if(DayManager.Year == 633 & DayManager.Month == 5 && DayManager.Date == 1)
		{
			return true;
		}

		return false;
	}

	public void MoveToEndingScene()
	{
		if(IsFinalDay())
		{
			SceneManager.LoadScene("Ending");
		}
	}
}