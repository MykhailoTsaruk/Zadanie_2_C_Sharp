using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Game.Commands
{
    public class Jump : ICommand
    {
        private IActor actor;
        private int dy;
        public Jump(IActor movable, int dy)
        {
            if (!(movable is IActor))
            {
                throw new ArgumentException("Can only move actors");
            }
            actor = movable;
            this.dy = dy;
        }

        public void Execute()
        {
            int newY = this.actor.GetY() + dy;
            this.actor.SetPosition(this.actor.GetX(), newY);
        }
    }
}