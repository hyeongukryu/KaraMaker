namespace Game
{
    interface IStatusService
    {
        IStatus Get(string key);
        int GetFixedValue(string key);
        double GetRealValue(string key);
    }
}
