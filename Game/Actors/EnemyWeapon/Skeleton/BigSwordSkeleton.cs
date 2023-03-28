using Game.Actors.Functions;
using Game.Actors.Hands.Orcs;
using Game.Actors.Hands.Skeleton;
using Game.Actors.Wizzard;
using Merlin2d.Game;
using System.Runtime.CompilerServices;

namespace Game.Actors.EnemyWeapon.Skeleton
{
    public class BigSwordSkeleton : AbstractCharacter
    {
        private Player player;
        private HandsWarriorSkeleton hands;
        private Animation animation;

        private int iteration = 0;
        private int wait;
        private int posX;

        private bool lastDirection;
        private bool pause = false;
        private bool attack = false;

        public BigSwordSkeleton(HandsWarriorSkeleton hands, int posX, int wait)
        {
            this.hands = hands;
            animation = new Animation("resources/sprites/Weapon/Skeleton/BigSword.png", 41, 41);

            lastDirection = hands.IsLeft();
            this.posX = posX;
            this.wait = wait;

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
                SetPosition(hands.GetX() - 30 + posX, hands.GetY() - 26);
            }
            else
            {
                if (lastDirection != hands.IsLeft())
                {
                    lastDirection = hands.IsLeft();
                    GetAnimation().FlipAnimation();
                }
                SetPosition(hands.GetX() + 20 - posX, hands.GetY() - 26);
            }
            attack = hands.GetAttack();

            if (attack & iteration == 0)
            {
                if (wait == 0)
                {
                    GetAnimation().Start();
                }
                else
                {
                    wait--;
                }
            }

            if (GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() / 2 & !pause)
            {
                player.SetHP(-1);
                pause = true;
            }


            GetAnimation().StopAt(GetAnimation().GetFrameCount() - 1);
            if (iteration == 0 & GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() - 1)
            {
                iteration = 20;
            }

            if (iteration != 0 & GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() - 1)
            {
                iteration--;
                pause = false;
            }
        }
    }
}
