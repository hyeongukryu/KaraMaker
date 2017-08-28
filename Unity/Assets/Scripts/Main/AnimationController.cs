using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
	public AnimationInfo[] ani;
	[HideInInspector]
	public int scheduleNum;
	[HideInInspector]
	public bool isSuccess;

	private Image aniImage;
	private float gameTime;

	private void Start()
	{
		aniImage = gameObject.transform.Find("AnimationImage").gameObject.GetComponent<Image>();
		gameTime = 0f;
	}

	private void Update()
	{
		gameTime += Time.deltaTime;
		
		if(gameTime >= 0f && gameTime < ani[scheduleNum].IntervalTime)
		{
			SpriteChange(0);
		}
		else if(gameTime >= ani[scheduleNum].IntervalTime && gameTime < 2 * ani[scheduleNum].IntervalTime)
		{
			SpriteChange(1);
		}
		else if(gameTime >= 2 * ani[scheduleNum].IntervalTime)
		{
			gameTime = 0;
		}
	}

	private void SpriteChange(int n)
	{
		if(isSuccess == true)
		{
			aniImage.sprite = ani[scheduleNum].SuccessAni[n];
		}
		else
		{
			aniImage.sprite = ani[scheduleNum].FailAni[n];
		}
	}
}