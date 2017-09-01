namespace Game
{
    interface IStatusService
    {
        IStatus Get(string key);
        int GetValue(string key);
    }
}
