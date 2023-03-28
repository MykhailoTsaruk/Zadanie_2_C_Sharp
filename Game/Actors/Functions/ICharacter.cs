using Merlin2d.Game.Actions;

namespace Game.Actors.Functions
{
    public interface ICharacter : IMovable
    {
        void ChangeHealth(int delta);
        int GetHealth();
        void Die();
        void AddEffect(ICommand effect);
        void RemoveEffect(ICommand effect);
    }
}
