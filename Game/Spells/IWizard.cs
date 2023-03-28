using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Spells
{
    public interface IWizard
    {
        void ChangeMana(int delta);
        int GetMana();
        void Cast(ISpell spell);
    }
}
