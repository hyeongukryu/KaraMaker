using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStatus : MonoBehaviour
{
    public Text[] StatusText;

    public void UpdateStatus()
    {
        for (int i = 0; i < StatusText.Length; i++)
        {
            StatusText[i].text = KaramatsuManager.Status[i].ToString();
        }
    }
}
