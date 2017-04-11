using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
	public void NewGame()
	{
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene("Opening");

		KaramatsuManager.Status = new int[21] {0,
												100, 100, 100, 100, 100,
												100, 100, 100, 100, 100,
												100, 100, 100, 100, 100,
												100, 100, 100, 100, 100};
	}
}
