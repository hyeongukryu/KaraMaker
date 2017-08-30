using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Opening
{
    public class BadOpeningManager : MonoBehaviour
    {
        public Text text;
        public GameObject Speaker;
        public Sprite[] ChoroFace;
        public Sprite[] ChoroDress;

        private int illustNumber = 0;
        private int textNumber = 0;
        private Image ChoroFaceImage;
        private Image ChoroDressImage;
        private string[] tutoText = new string[] {
            "...으, 으음 그렇군요... 알겠습니다.",
            "어쩔 수 없군요. 제가 사람을 잘못 봤나 보군요....",
            "그렇게 여신(?)은 사라졌다.",
            "그리고 난 산을 내려오는 길에 갑자기 발생한 산사태에 발을 헛디뎌 굴러떨어져 죽고 말았다.",
            "그러니까 누가 거절하래?",
            "Game Over......"
        };

        private int?[] faceNumber = new int?[] { 0, 0, null, null, 1, null };
        private int[] dressNumber = new int[] { 0, 0, 0, 0, 0 };

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
        }

        public void MoveNextText()
        {
            if (textNumber + 1 >= tutoText.Length)
            {
                SceneManager.LoadScene("Start");
                return;
            }

            textNumber = textNumber + 1;
        }

        public void MoveToStartScene()
        {
            SceneManager.LoadScene("Start");
        }

        private void UpdatePrologueIllust()
        {
            if (textNumber >= 2)
            {
                GetComponent<Image>().enabled = false;
            }
        }

        private void UpdateProfileFace(int? faceNumber)
        {
            if (faceNumber == null)
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
    }
}