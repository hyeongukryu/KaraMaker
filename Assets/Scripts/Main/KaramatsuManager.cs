using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaramatsuManager : MonoBehaviour
{
    public Sprite[] KaraFaceImages;
    public Sprite[] KaraDressImages;
    static public float[] Status;
    static public int KaraAge;
    static public string[] StatusName_Kr = new string[26] {"스트레스",
                                        "체력", "근력", "지능", "기품", "매력",
                                        "도덕성", "신앙", "인과", "감수성", "전투기술",
                                        "공격력", "방어력", "마법기술", "마력", "항마력",
                                        "예의범절", "예술", "화술", "요리", "청소세탁",
                                        "성품", "전사평가", "마법평가", "사교평가", "가사평가"};
    static public int Gold;
    static public string Face = "Idle";
    static public string Dress = "Paka 1";

    private Image FaceImage;
    private Image DressImage; 

    private void Start()
    {
        FaceImage = GameObject.Find("Karamatsu Standing").transform.Find("Face").gameObject.GetComponent<Image>();
        DressImage = GameObject.Find("Karamatsu Standing").transform.Find("Dress").gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        AgeControl();
        FaceController();
        DressController();
    }

    private void AgeControl() // 1년이 지나면 나이를 하나 먹습니다.
    {
        KaraAge = DayManager.Year - 625 + 12;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Year", DayManager.Year);
		PlayerPrefs.SetInt("Month", DayManager.Month);
		PlayerPrefs.SetInt("Date", DayManager.Date);
        PlayerPrefs.SetInt("스트레스", Mathf.RoundToInt(KaramatsuManager.Status[0]));
        PlayerPrefs.SetInt("체력", Mathf.RoundToInt(KaramatsuManager.Status[1]));
        PlayerPrefs.SetInt("근력", Mathf.RoundToInt(KaramatsuManager.Status[2]));
        PlayerPrefs.SetInt("지능", Mathf.RoundToInt(KaramatsuManager.Status[3]));
        PlayerPrefs.SetInt("기품", Mathf.RoundToInt(KaramatsuManager.Status[4]));
        PlayerPrefs.SetInt("매력", Mathf.RoundToInt(KaramatsuManager.Status[5]));
        PlayerPrefs.SetInt("도덕성", Mathf.RoundToInt(KaramatsuManager.Status[6]));
        PlayerPrefs.SetInt("신앙", Mathf.RoundToInt(KaramatsuManager.Status[7]));
        PlayerPrefs.SetInt("인과", Mathf.RoundToInt(KaramatsuManager.Status[8]));
        PlayerPrefs.SetInt("감수성", Mathf.RoundToInt(KaramatsuManager.Status[9]));
        PlayerPrefs.SetInt("전투기술", Mathf.RoundToInt(KaramatsuManager.Status[10]));
        PlayerPrefs.SetInt("공격력", Mathf.RoundToInt(KaramatsuManager.Status[11]));
        PlayerPrefs.SetInt("방어력", Mathf.RoundToInt(KaramatsuManager.Status[12]));
        PlayerPrefs.SetInt("마법기술", Mathf.RoundToInt(KaramatsuManager.Status[13]));
        PlayerPrefs.SetInt("마력", Mathf.RoundToInt(KaramatsuManager.Status[14]));
        PlayerPrefs.SetInt("항마력", Mathf.RoundToInt(KaramatsuManager.Status[15]));
        PlayerPrefs.SetInt("예의범절", Mathf.RoundToInt(KaramatsuManager.Status[16]));
        PlayerPrefs.SetInt("예술", Mathf.RoundToInt(KaramatsuManager.Status[17]));
        PlayerPrefs.SetInt("화술", Mathf.RoundToInt(KaramatsuManager.Status[18]));
        PlayerPrefs.SetInt("요리", Mathf.RoundToInt(KaramatsuManager.Status[19]));
        PlayerPrefs.SetInt("청소세탁", Mathf.RoundToInt(KaramatsuManager.Status[20]));
        PlayerPrefs.SetInt("성품", Mathf.RoundToInt(KaramatsuManager.Status[21]));
        PlayerPrefs.SetInt("Age", KaramatsuManager.KaraAge);
        PlayerPrefs.SetInt("Gold", KaramatsuManager.Gold);
    }

    public void MoveToEndingCheat()
    {
        DayManager.Year = 633;
        DayManager.Month = 5;
        DayManager.Date = 1;
    }

    private void FaceController()
    {
        switch(Face)
        {
            case "Idle":
                FaceImage.sprite = KaraFaceImages[0];
                break;
            case "Expressionless":
                FaceImage.sprite = KaraFaceImages[1];
                break;
            case "Smile":
                FaceImage.sprite = KaraFaceImages[2];
                break;
            case "Fun":
                FaceImage.sprite = KaraFaceImages[3];
                break;
            case "No Words":
                FaceImage.sprite = KaraFaceImages[4];
                break;
            case "Surprise":
                FaceImage.sprite = KaraFaceImages[5];
                break;
            case "Sad":
                FaceImage.sprite = KaraFaceImages[6];
                break;
            case "Serious":
                FaceImage.sprite = KaraFaceImages[7];
                break;
            case "Painful":
                FaceImage.sprite = KaraFaceImages[8];
                break;
            case "Angry":
                FaceImage.sprite = KaraFaceImages[9];
                break;
        }
    }

    private void DressController()
    {
        switch(Dress)
        {
            case "Paka 1":
                DressImage.sprite = KaraDressImages[0];
                break;
            case "Paka 2":
                DressImage.sprite = KaraDressImages[1];
                break;
        }
    }
}
