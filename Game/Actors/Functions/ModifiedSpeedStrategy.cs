using Game.Actors.Functions;

namespace Game.Actors
{
    public class ModifiedSpeedStrategy : ISpeedStrategy
    {
        public int GetSpeed(int speed)
        {
            double var = speed * 1.5;
            return (int)var;
        }
    }
}
