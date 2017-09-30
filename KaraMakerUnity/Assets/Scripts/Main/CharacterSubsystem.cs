using Game;
using UnityEngine.UI;

namespace Main
{
    partial class MainSceneManager
    {
        private void UpdateCharacterSubsystem()
        {
            AppearanceService.Update();

            KaraResources.LoadSprite(GetComponent<Image>("CharacterBody"),
                RootState.PlayState, p => p.CurrentBodyImage);
            KaraResources.LoadSprite(GetComponent<Image>("CharacterDress"),
                RootState.PlayState, p => p.CurrentDressImage);
            KaraResources.LoadSprite(GetComponent<Image>("CharacterFace"),
                RootState.PlayState, p => p.CurrentFaceImage);
        }
    }
}