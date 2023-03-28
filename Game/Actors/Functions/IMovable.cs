namespace Game.Actors.Functions
{
    public interface IMovable
    {
        void SetSpeedStrategy(ISpeedStrategy strategy);
        int GetSpeed(int speed);
    }
}
