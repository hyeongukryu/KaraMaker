using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class ScheduleManager : MonoBehaviour
    {
        public Image[] CalendarIcon;
        public Sprite[] ToDoIcon;
        public int[] ScheduleList;

        private int[] ToDoList;

        private void Start()
        {
            ToDoList = new int[3] { 99, 99, 99 };
        }

        private void Update()
        {
            for (int i = 0; i <= 2; i++)
            {
                if (ToDoList[i] == 99)
                    return;

                for (int j = 0; j <= 9; j++)
                {
                    CalendarIcon[10 * i + j].sprite = ToDoIcon[ToDoList[i]];
                    CalendarIcon[10 * i + j].color = new Vector4(1, 1, 1, 1);
                }
            }

            if (ToDoList[2] != 99)
            {
                GetComponent<UIManager>().RunOrCancelMode();
            }
        }

        private int AssignNumber()
        {
            for (int i = 0; i <= 2; i++)
            {
                if (ToDoList[i] == 99)
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

        public void RunSchedule()
        {
            GetComponent<RunningSchedule>().ScheduleList = ToDoList;
            ToDoList = new int[3] { 99, 99, 99 };
            foreach (Image icon in CalendarIcon)
            {
                icon.color = new Vector4(1, 1, 1, 0);
            }
            GetComponent<UIManager>().RunSchedule();
            GetComponent<RunningSchedule>().enabled = true;
        }

        public void CancelSchedule()
        {
            for (int i = 0; i < CalendarIcon.Length; i++)
            {
                CalendarIcon[i].sprite = null;
                CalendarIcon[i].color = new Vector4(1, 1, 1, 0);
            }

            ToDoList = new int[3] { 99, 99, 99 };
            GetComponent<UIManager>().SchedulingMode();
        }
    }
}