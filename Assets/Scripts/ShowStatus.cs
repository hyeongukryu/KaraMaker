using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStatus : MonoBehaviour
{
    public Text[] StateText;

    private KaramatsuManager KaraManager;

    private void Start()
    {
        KaraManager = GetComponent<KaramatsuManager>();
    }

    public void UpdateStatus()
    {
        for (int i = 0; i < 21; i++)
        {
            StateText[i].text = KaraManager.Status[i].ToString();
        }
    }
}
