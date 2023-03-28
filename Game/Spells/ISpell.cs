using Game.Actors.Functions;
using Merlin2d.Game.Actions;

namespace Game.Spells
{
    public interface ISpell
    {
        ISpell AddEffect(ICommand effect);
        void AddEffects(IEnumerable<ICommand> effects);
        int GetCost();
        void ApplyEffects(ICharacter target);
    }
}
