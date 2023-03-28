using Merlin2d.Game.Actions;

namespace Game.Actors.Functions
{
    public abstract class AbstractCharacter : AbstractActor, ICharacter
    {
        private List<ICommand> activeEffects;
        private int health;
        private float speed;
        private ISpeedStrategy speedStrategy;

        // TODO: you can solve considering effects here in the Update method
        // you will further specify the Update method in subclasses

        public void AddEffect(ICommand effect)
        {
            // TODO: add effect to list of active effects
            throw new NotImplementedException();
        }

        public void ChangeHealth(int delta)
        {
            // TODO: update health based on delta change - keep in mind limits
            throw new NotImplementedException();
        }

        public void Die()
        {
            // TODO: what happens when the character dies?
            throw new NotImplementedException();
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetSpeed(int speed)
        {
            // TODO: get current speed based on the character's initial speed and current strategy
            return speedStrategy.GetSpeed(speed);
        }

        public void RemoveEffect(ICommand effect)
        {
            // TODO: remove effect from active effects
            // consider what happens if it is not among them
            throw new NotImplementedException();
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            speedStrategy = strategy;
        }
    }
}
