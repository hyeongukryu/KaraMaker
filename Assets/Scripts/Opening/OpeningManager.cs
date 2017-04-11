using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningManager : MonoBehaviour
{
	public Sprite[] Illust;
	public Image illustImage;

	private float gameTime;
	private int illustNumber = 0;

	private void Start()
	{
		gameTime = 0;

		illustImage.sprite = Illust[0];
		illustNumber = illustNumber + 1;
	}

	private void Update()
	{
		gameTime = gameTime + Time.deltaTime;

		if(gameTime >= 5f)
		{
			if(illustNumber == 7)
			{
				SceneManager.LoadScene("Main");
			}
			
			illustImage.sprite = Illust[illustNumber];
			illustNumber = illustNumber + 1;

			gameTime = 0;
		}
	}

	public void MoveToMainScene()
	{
		SceneManager.LoadScene("Main");
	}
}