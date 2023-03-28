using Game.Actors.Functions;
using Game.Actors.Wizzard;
using Merlin2d.Game;

namespace Game.Actors.Hands.Wizzard
{
    public class HandsPlayer : AbstractCharacter
    {
        private Player player;
        private Animation animation;

        private int frame;
        private int anim;

        private bool create = false;

        public HandsPlayer()
        {
            animation = new Animation("resources/sprites/Hands/HandsAlive.png", 32, 16);

            SetAnimation(animation);
        }

        public override void Update()
        {
            if (!create)
            {
                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Player");
                create = true;
            }

            frame = player.GetAnimation().GetCurrentFrame();

            _ = player.GetAnimation().GetFrameCount() == 4 ? (_ = frame == 0 | frame == 3 ? anim = 1 : anim = 0) :
                (_ = frame == 1 | frame == 2 | frame == 4 ? anim = 1 : anim = 0);

            if (player.IsDie())
            {
                GetWorld().RemoveActor(this);
            }

            if (player.IsLeft())
            {
                SetPosition(player.GetX() - 2, player.GetY() + 14 - anim);
            }
            else
            {
                SetPosition(player.GetX() + 2, player.GetY() + 14 - anim);
            }
        }
    }
}
