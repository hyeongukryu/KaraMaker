using UnityEngine;

namespace Start
{
    public class StartUIController : MonoBehaviour
    {
        public GameObject[] StartUI;
        public GameObject UIOnButton;

        private void Start()
        {
            foreach (GameObject UI in StartUI)
            {
                UI.SetActive(true);
            }

            UIOnButton.SetActive(false);
        }

        public void UIOff()
        {
            foreach (GameObject UI in StartUI)
            {
                UI.SetActive(false);
            }

            UIOnButton.SetActive(true);
        }

        public void UIOn()
        {
            foreach (GameObject UI in StartUI)
            {
                UI.SetActive(true);
            }

            UIOnButton.SetActive(false);
        }
    }
}