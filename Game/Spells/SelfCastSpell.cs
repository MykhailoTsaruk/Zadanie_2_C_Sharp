using Game.Actors.Functions;
using Merlin2d.Game.Actions;

namespace Game.Spells
{
    public class SelfCastSpell : ISpell
    {
        // TODO: check functionality in lab 8
        public ISpell AddEffect(ICommand effect)
        {
            throw new NotImplementedException();
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            throw new NotImplementedException();
        }

        public void ApplyEffects(ICharacter target)
        {
            throw new NotImplementedException();
        }

        public int GetCost()
        {
            throw new NotImplementedException();
        }
    }
}
