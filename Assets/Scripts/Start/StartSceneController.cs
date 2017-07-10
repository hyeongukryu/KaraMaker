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

		KaramatsuManager.Status = new int[21]{0,
											  100, 100, 100, 100, 100,
											  100, 100, 100, 100, 100,
											  100, 100, 100, 100, 100,
											  100, 100, 100, 100, 100};
		KaramatsuManager.KaraAge = 12;
		KaramatsuManager.Gold = 500;
	}

	public void LoadGame()
	{
		if(PlayerPrefs.HasKey("Stress") == false)
		{
			Debug.Log("No Save");
			return;
		}
		KaramatsuManager.KaraAge = PlayerPrefs.GetInt("Age");
		KaramatsuManager.Gold = PlayerPrefs.GetInt("Gold");
		KaramatsuManager.Status = new int[21]{PlayerPrefs.GetInt("Stress"),
											  PlayerPrefs.GetInt("Cleaning"),
											  PlayerPrefs.GetInt("Cook"),
											  PlayerPrefs.GetInt("Talk"),
											  PlayerPrefs.GetInt("Art"),
											  PlayerPrefs.GetInt("Elegance"),
											  PlayerPrefs.GetInt("Courtesy"),
											  PlayerPrefs.GetInt("Causation"),
											  PlayerPrefs.GetInt("Sensibility"),
											  PlayerPrefs.GetInt("Character"),
											  PlayerPrefs.GetInt("Music"),
											  PlayerPrefs.GetInt("Health"),
											  PlayerPrefs.GetInt("Strength"),
											  PlayerPrefs.GetInt("Intelligence"),
											  PlayerPrefs.GetInt("Charisma"),
											  PlayerPrefs.GetInt("Charm"),
											  PlayerPrefs.GetInt("Attack Power"),
											  PlayerPrefs.GetInt("Spell"),
											  PlayerPrefs.GetInt("Morality"),
											  PlayerPrefs.GetInt("Anti Spell"),
											  PlayerPrefs.GetInt("Religiosity")};

		SceneManager.LoadScene("Main");
	}
}
