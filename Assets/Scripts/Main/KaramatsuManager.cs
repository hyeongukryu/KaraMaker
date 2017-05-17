using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaramatsuManager : MonoBehaviour
{
    static public int[] Status;
    static public int KaraAge;
    static public string[] StatusName_Kr;
    static public int Money;

    private void Start()
    {
        StatusName_Kr = new string[21] {"스트레스",
                                        "청소", "요리", "화술", "예술", "기품",
                                        "예의범절", "인과", "감수성", "성품", "음악",
                                        "체력", "근력", "지능", "카리스마", "매력",
                                        "전투력", "마력", "도덕심", "항마력", "신앙심"};
    }

    private void Update()
    {
        
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Year", DayManager.Year);
		PlayerPrefs.SetInt("Month", DayManager.Month);
		PlayerPrefs.SetInt("Date", DayManager.Date);
        PlayerPrefs.SetInt("Stress", KaramatsuManager.Status[0]);
        PlayerPrefs.SetInt("Cleaning", KaramatsuManager.Status[1]);
        PlayerPrefs.SetInt("Cook", KaramatsuManager.Status[2]);
        PlayerPrefs.SetInt("Talk", KaramatsuManager.Status[3]);
        PlayerPrefs.SetInt("Art", KaramatsuManager.Status[4]);
        PlayerPrefs.SetInt("Elegance", KaramatsuManager.Status[5]);
        PlayerPrefs.SetInt("Courtesy", KaramatsuManager.Status[6]);
        PlayerPrefs.SetInt("Causation", KaramatsuManager.Status[7]);
        PlayerPrefs.SetInt("Sensibility", KaramatsuManager.Status[8]);
        PlayerPrefs.SetInt("Character", KaramatsuManager.Status[9]);
        PlayerPrefs.SetInt("Music", KaramatsuManager.Status[10]);
        PlayerPrefs.SetInt("Health", KaramatsuManager.Status[11]);
        PlayerPrefs.SetInt("Strength", KaramatsuManager.Status[12]);
        PlayerPrefs.SetInt("Intelligence", KaramatsuManager.Status[13]);
        PlayerPrefs.SetInt("Charisma", KaramatsuManager.Status[14]);
        PlayerPrefs.SetInt("Charm", KaramatsuManager.Status[15]);
        PlayerPrefs.SetInt("Attack Power", KaramatsuManager.Status[16]);
        PlayerPrefs.SetInt("Spell", KaramatsuManager.Status[17]);
        PlayerPrefs.SetInt("Morality", KaramatsuManager.Status[18]);
        PlayerPrefs.SetInt("Anti Spell", KaramatsuManager.Status[19]);
        PlayerPrefs.SetInt("Religiosity", KaramatsuManager.Status[20]);
        PlayerPrefs.SetInt("Age", KaramatsuManager.KaraAge);
        PlayerPrefs.SetInt("Money", KaramatsuManager.Money);
    }
}
