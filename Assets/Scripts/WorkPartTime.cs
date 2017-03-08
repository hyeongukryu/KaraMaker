using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkPartTime : MonoBehaviour
{
    private KaramatsuManager KaraManager;

    private void Start()
    {
        KaraManager = GetComponent<KaramatsuManager>();
    }

    public void PartTime(string PartTimeName)
    {
        switch (PartTimeName)
        {
            case "Farm":
                KaraManager.Status[0] += 4;
                break;
            case "Church":
                KaraManager.Status[0] += 2;
                break;
            case "Black Factory":
                KaraManager.Status[0] += 20;
                break;
            case "Shrine":
                KaraManager.Status[0] += 2;
                break;
            case "Bar":
                KaraManager.Status[0] += 5;
                break;
            case "Delivery":
                KaraManager.Status[0] += 5;
                break;
            case "Hotel":
                KaraManager.Status[0] += 3;
                break;
            case "Housework":
                KaraManager.Status[0] += 1;
                break;
            case "Parenting":
                KaraManager.Status[0] += 3;
                break;
            case "Mine":
                KaraManager.Status[0] += 5;
                break;
            case "Salon":
                KaraManager.Status[0] += 4;
                break;
            case "Hunter":
                KaraManager.Status[0] += 3;
                break;
            case "Graveyard":
                KaraManager.Status[0] += 4;
                break;
            case "Tutor":
                KaraManager.Status[0] += 3;
                break;
            default:
                Debug.Log("Something is Wrong at PartTime Fuction");
                break;
        }
    }
}
