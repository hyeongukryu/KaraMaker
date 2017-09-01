using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class BlockEducationWhenYouDoNotHaveMoney : MonoBehaviour
    {
        private void Update()
        {
            if (KaramatsuManager.Gold <= 0)
            {
                gameObject.GetComponent<Button>().interactable = false;
            }
            else
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
    }
}