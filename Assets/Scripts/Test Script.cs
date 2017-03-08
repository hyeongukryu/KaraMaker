using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public void PartTime(string PartTimeName)
    {
        switch (PartTimeName)
        {
            case "Farm":
                break;
            case "Church":
                break;
            case "Black Factroy":
                break;
            case "Shrine":
                break;
            case "Bar":
                break;
            case "Delivery":
                break;
            case "Hotel":
                break;
            case "Housework":
                break;
            case "Parenting":
                break;
            case "Mine":
                break;
            case "Salon":
                break;
            case "Hunter":
                break;
            case "Graveyard":
                break;
            case "Tutor":
                break;
            default:
                Debug.Log("Something is Wrong at PartTime Fuction");
                break;
        }
    }
}
