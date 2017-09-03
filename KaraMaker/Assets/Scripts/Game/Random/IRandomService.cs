namespace Game.Random
{
    interface IRandomService
    {
        int Next(int beginClosed, int endOpen, int salt);
        int Next(int salt);
        double NextDouble(int salt);
    }
}
