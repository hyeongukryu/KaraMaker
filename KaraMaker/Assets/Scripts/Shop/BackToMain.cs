using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shop
{
    public class BackToMain : MonoBehaviour
    {
        public void MoveToMainScene()
        {
            SceneManager.LoadScene("Main");
        }
    }
}