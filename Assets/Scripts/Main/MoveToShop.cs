using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToShop : MonoBehaviour
{
	public void MoveToShopScene()
	{
		SceneManager.LoadScene("Shop");
	}
}