using Game.Actors.Functions;
using Game.Actors.Hands.Skeleton;
using Game.Actors.Wizzard;
using Merlin2d.Game;

namespace Game.Actors.EnemyWeapon.Skeleton
{
    public class AxeSkeleton : AbstractCharacter
    {
        private Player player;
        private HandsRogueSkeleton hands;
        private Animation animation;

        private int iteration = 0;

        private bool lastDirection;
        private bool pause = false;
        private bool attack = false;

        public AxeSkeleton(HandsRogueSkeleton hands)
        {
            this.hands = hands;
            animation = new Animation("resources/sprites/Weapon/Skeleton/Axe.png", 26, 26);

            lastDirection = hands.IsLeft();

            SetAnimation(animation);
            animation.SetDuration(2);
        }

        public override void Update()
        {
            if (player == null)
            {
                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Player");
            }
            if (hands.RemovedFromWorld())
            {
                GetWorld().RemoveActor(this);
            }
            if (hands.IsLeft())
            {
                if (lastDirection != hands.IsLeft())
                {
                    lastDirection = hands.IsLeft();
                    GetAnimation().FlipAnimation();
                }
                SetPosition(hands.GetX() - 10, hands.GetY() - 12);
            }
            else
            {
                if (lastDirection != hands.IsLeft())
                {
                    lastDirection = hands.IsLeft();
                    GetAnimation().FlipAnimation();
                }
                SetPosition(hands.GetX() + 18, hands.GetY() - 12);
            }
            attack = hands.GetAttack();

            if (attack & iteration == 0)
            {
                GetAnimation().Start();
            }

            if (GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() / 2 & !pause)
            {
                player.SetHP(-2);
                pause = true;
            }


            GetAnimation().StopAt(GetAnimation().GetFrameCount() - 1);
            if (iteration == 0 & GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() - 1)
            {
                iteration = 80;
            }

            if (iteration != 0 & GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() - 1)
            {
                iteration--;
                pause = false;
            }
        }
    }
}
