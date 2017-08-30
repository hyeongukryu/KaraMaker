using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public class MoveToShop : MonoBehaviour
    {
        public void MoveToShopScene()
        {
            SceneManager.LoadScene("Shop");
        }
    }
}