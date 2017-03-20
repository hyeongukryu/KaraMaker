using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleManager : MonoBehaviour
{
	public Image[] CalendarIcon;
	public Sprite[] ToDoIcon;

	private int[] ToDoList;

	private void Start()
	{
		ToDoList = new int[3] {99, 99, 99};
	}

	private void Update()
	{
		for(int i = 0; i <= 2; i++)
		{
			if(ToDoList[i] == 99)
				return;

			for(int j = 0; j <= 9; j++)
			{
				CalendarIcon[10 * i + j].sprite = ToDoIcon[ToDoList[i]];
			}
		}

		if(ToDoList[2] != 99)
		{
			GetComponent<UIManager>().RunOrCancelMode();
		}
	}

	private int AssignNumber()
	{
		for(int i = 0; i <= 2; i++)
		{
			if(ToDoList[i] == 99)
			{
				return i;
			}
		}

		Debug.Log("Something is Wrong at AssignNumber");
		return 3;
	}

	public void AssignToDo(int ToDo)
	{
		ToDoList[AssignNumber()] = ToDo;
	}

	public void CancelSchedule()
	{
		for(int i = 0; i < CalendarIcon.Length; i++)
		{
			CalendarIcon[i].sprite = null;
		}

		ToDoList = new int[3] {99, 99, 99};
		GetComponent<UIManager>().SchedulingMode();
	}
}

/*switch (ToDo)
        {
            case "Farm":
				
                //KaramatsuManager.Status[0] += 4;
                break;
            case "Church":
                break;
            case "Black Factory":
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
			case "Art":
				break;
			case "Athletic":
				break;
			case "Dance":
				break;
			case "Etiquette":
				break;
			case "Fence":
				break;
			case "Literature":
				break;
			case "Magic":
				break;
			case "Music":
				break;
			case "Science":
				break;
			case "Speech":
				break;
			case "Theology":
				break;
            default:
                Debug.Log("Something is Wrong at AssignToDo Fuction");
                break; */
