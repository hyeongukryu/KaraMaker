using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningManager : MonoBehaviour
{
	public Text text;
	public GameObject Speaker;
	public Button TextBoxButton;
	public GameObject[] YesNoButton;
	public Sprite[] PrologueIllust;
	public Sprite[] ChoroFace;
	public Sprite[] ChoroDress;

	private int illustNumber = 0;
	private int textNumber = 0;
	private Image ChoroFaceImage;
	private Image ChoroDressImage;
	private string[] tutoText = new string [] {
		"예전에는 잘 나가는 용사였지만 마지막으로 싸운 전투에서 다리에 큰 부상을 입어",
		"더 이상 용사로서는 활약하지 못하게 되었다.",
		"그리하여 나는 지금까지 이루었던 업적을 인정받아 괜찮은 집을 받고, 1년에 한 번씩 나오는 연금으로 편하게 놀고먹으면서 살고 있었다.",
		"매일 놀고 먹는 건 물론 즐거웠지만 그... 약간의 스파이스가 부족하다고 할까",
		"뭔가 일상의 변화가 일어났으면 좋겠다는 생각을 하게 되었다.",
		"그러던 어느 날 밤, 마을에 있는 뒷산에 등산을 갔다.",
		"날씨가 너무나도 좋았고 평소에는 가지 않은 곳까지 산을 타고 말았다.",
		"이런 곳이 있었나? 라고 생각이 들은 것과 동시에 샘에서 갑자기 빛이 났다.",
		"......",
		"...뭐 뭐야?!",
		"음... 나쁘지 않네",
		"거기 당신 , 아이를 키워보실 생각 없으신가요?",
		"예?",
		"갑자기 저희가 곤란한 일이 생겨서 말입니다.",
		"원래는 죽어서는 안 되는 영혼을 사신이 실수로 죽이는 바람에 하늘로 올라오고 말았어요.",
		"이대로 내려보내자니 이미 장례도 다 치뤄버린 상태고, 그렇다고 다음 생으로 넘어가기까지엔 수명이 너무 많이 남았고......",
		"귀찮게 됐어요. 정말... 그러니까 누가 이따이하다고 죽이래?",
		"... 본론은, 이 아이를 키워주셨으면 합니다.",
		"성인이 되어서 스스로 살 수 있을 때까지면 됩니다.",
		"당신, 어차피 할 일 없다고 생각하고 계셨죠?",
		"뭔진 모르지만 정곡을 찔렸다.",
		"아이는 이렇게 생겼습니다.",
		"이미 전적이 있으니 조금만 잘못 키워도 이따이해질 것 같긴 하지만...",
		"당신이라면 잘 할 수 있을 거라고 생각합니다.",
		"이름은 카라마츠. 나이는 12살",
		"중요한 건 사신이 다시 죽이질 못하도록 이따이하지 않게 키우는 것입니다.",
		"어떤가요? 할 수 있으시겠나요?",
		"이따이한 게 뭔지는 잘 모르겠지만, 나는 대답했다. \n\n >네.\t\t\t\t\t\t\t\t >아니요.",
		"휴우 다행이에요. 한숨 놨네요.",
		"그래도 아이를 한 번도 키워본 적 없는 당신이 갑자기 양육을 한다는 게 좀 걱정이기도 하고,",
		"아이가 이따이하지 않으려면 지도도 좀 필요할 것 같으니...",
		"그래. 제 분신을 내려보내 집사로 쓸 수 있게 해 드리겠습니다.",
		"아, 그리고 오늘 가벼운 산사태가 일어날 예정이라서 집으로 바로 내려보내도록 하지요. 카라마츠와 함께.",
		"자, 그럼 당신의 앞날에 축복이 있기를....",
		"안녕 아빠! 오늘은 뭘 할까?",
		"안녕하세요. 앞으로 당신을 모시게 된 쵸로마츠입니다. 잘 부탁드립니다, 주인님."
	};

	private int?[] faceNumber = new int?[] {null, null, null, null, null, null, null, null, 6, null,
											1, 1, null, 5, 5, 5, 5, 0, 0, 0,
											null, 0, 0, 0, 0, 0, 0, null, 1, 0,
											0, 0, 0, 0, null, 2};
	private int[] dressNumber = new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1};

	private void Start()
	{
		textNumber = 0;
		ChoroFaceImage = Speaker.transform.Find("Face").gameObject.GetComponent<Image>();
		ChoroDressImage = Speaker.transform.Find("Dress").gameObject.GetComponent<Image>();
	}

	private void Update()
	{
		text.text = tutoText[textNumber];
		UpdateProfileFace(faceNumber[textNumber]);
		UpdateProfileDress(dressNumber[textNumber]);
		UpdatePrologueIllust();
		ButtonControllerForChoose();
	}

	public void MoveNextText()
	{
		if(textNumber + 1 >= tutoText.Length)
		{
			SceneManager.LoadScene("Main");
			return;
		}			

		textNumber = textNumber + 1;
	}

	public void MoveToMainScene()
	{
		SceneManager.LoadScene("Main");
	}

	private void UpdatePrologueIllust()
	{
		if(textNumber >= 7 && textNumber < 34)
		{
			GetComponent<Image>().sprite = PrologueIllust[1];
		}
		else if(textNumber >= 34)
		{
			GetComponent<Image>().sprite = PrologueIllust[2];
		}
	}

	private void UpdateProfileFace(int? faceNumber)
	{
		if(faceNumber == null)
		{
			Speaker.SetActive(false);
			return;
		}

		Speaker.SetActive(true);
		ChoroFaceImage.sprite = ChoroFace[faceNumber.Value];
	}

	private void UpdateProfileDress(int dressNumber)
	{
		ChoroDressImage.sprite = ChoroDress[dressNumber];
	}

	private void ButtonControllerForChoose()
	{
		if(textNumber == 27)
		{
			TextBoxButton.enabled = false;

			foreach(GameObject button in YesNoButton)
			{
				button.SetActive(true);
			}
		}
	}

	public void ChooseYes()
	{
		textNumber += 1;

		TextBoxButton.enabled = true;

		foreach(GameObject button in YesNoButton)
		{
			button.SetActive(false);
		}
	}

	public void ChooseNo()
	{
		SceneManager.LoadScene("Opening_Bad");
	}
}