namespace Main
{
    partial class MainSceneManager
    {
        private void UpdateControlSubsystem()
        {
            if (!ActivateIfAndOnlyIfRouteMatches(ControlSubsystem, null))
            {
                return;
            }
        }
    }
}