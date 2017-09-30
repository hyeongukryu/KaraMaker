using Main;
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
        FameCalculator();
    }

    private void FameCalculator() //4가지 평가를 계산합니다.
    {
        Status[22] = Status[10] + Status[11] + Status[12];
        Status[23] = Status[13] + Status[14] + Status[15];
        Status[24] = Status[16] + Status[17] + Status[18];
        Status[25] = Status[19] + Status[20] + Status[21];
    }

    private void AgeControl() // 1년이 지나면 나이를 하나 먹습니다.
    {
        KaraAge = DayManager.Year - 625 + 12;
    }

    public void Save() //저장 기능을 구현해야 하는데 뭘 저장해야 할지 아직 몰라서 비워둠.
    {
    }

    public void MoveToEndingCheat() //날짜만 엔딩 날짜로 옮겨줌
    {
        DayManager.Year = 633;
        DayManager.Month = 5;
        DayManager.Date = 1;
    }

    private void FaceController() //표정을 조절하는 함수
    {
        switch (Face)
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

    private void DressController() //옷을 바꾸는 함수
    {
        switch (Dress)
        {
            case "Paka 1":
                DressImage.sprite = KaraDressImages[0];
                break;
            case "Paka 2":
                DressImage.sprite = KaraDressImages[1];
                break;
        }
    }

    static public void StatusChange(string statusName, int amount)
    {
        Status[GetStatusNum(statusName)] += amount;

        if (GetStatusNum(statusName) >= 0 && GetStatusNum(statusName) <= 9)
        {
            if (Status[GetStatusNum(statusName)] >= 999)
                Status[GetStatusNum(statusName)] = 999;
            else if (Status[GetStatusNum(statusName)] <= 0)
                Status[GetStatusNum(statusName)] = 0;

            return;
        }
        else if (GetStatusNum(statusName) >= 10 && GetStatusNum(statusName) <= 21)
        {
            if (Status[GetStatusNum(statusName)] >= 100)
                Status[GetStatusNum(statusName)] = 100;
            else if (Status[GetStatusNum(statusName)] <= 0)
                Status[GetStatusNum(statusName)] = 0;

            return;
        }
    }

    static private int GetStatusNum(string StatusName)
    {
        for (int i = 0; i < KaramatsuManager.StatusName_Kr.Length; i++)
        {
            if (KaramatsuManager.StatusName_Kr[i] == StatusName)
                return i;
        }

        return 0;
    }
}
