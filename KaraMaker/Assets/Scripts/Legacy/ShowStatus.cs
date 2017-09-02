using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class ShowStatus : MonoBehaviour
    {
        public Text[] StatusText;

        public void UpdateStatus()
        {
            for (int i = 0; i < StatusText.Length; i++)
            {
                StatusText[i].text = Mathf.CeilToInt(KaramatsuManager.Status[i]).ToString();
            }
        }
    }
}
