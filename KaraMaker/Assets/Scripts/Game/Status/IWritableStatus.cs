namespace Game
{
    interface IWritableStatus : IStatus
    {
        new int Value { get; set; }
    }
}
