using Game;
using UnityEngine.UI;

namespace Main
{
    partial class MainSceneManager
    {
        private void StartCommonSubsystem()
        {
            CalendarService.NewDay += (sender, e) => RootState.PlayState.BackgroundImage = "Backgrounds/Main";            
        }

        private void UpdateCommonSubsystem()
        {
            UpdateBackground();
            UpdateDateIndicator();
            UpdateProfileIndicator();
        }

        private void UpdateBackground()
        {
            KaraResources.LoadSprite(GetComponent<Image>("Background"), RootState.PlayState, p => p.BackgroundImage);
        }

        private void UpdateDateIndicator()
        {
            var p = RootState.PlayState;
            GetComponent<Text>("Year").text = p.Year.ToString();
            GetComponent<Text>("Month").text = p.Month.ToString();
            GetComponent<Text>("Date").text = p.Date.ToString();
            GetComponent<Text>("Day").text = CalendarService.GetDayText();
        }

        private void UpdateProfileIndicator()
        {
            GetComponent<Text>("Age").text = StatusService.GetFixedValue("Age").ToString();
            GetComponent<Text>("Gold").text = StatusService.GetRealValue("Gold").ToString("F0");
        }
    }
}