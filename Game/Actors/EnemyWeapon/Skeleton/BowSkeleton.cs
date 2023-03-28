using Game.Actors.Functions;
using Game.Actors.Hands.Skeleton;
using Merlin2d.Game;

namespace Game.Actors.EnemyWeapon.Skeleton
{
    public class BowSkeleton : AbstractCharacter
    {
        private HandsArcherSkeleton hands;
        private Animation animationBow;

        private bool lastDirection;

        private int wait = 0;

        private bool shot = false;

        public BowSkeleton(HandsArcherSkeleton hands)
        {
            this.hands = hands;
            animationBow = new Animation("resources/sprites/Weapon/Skeleton/Bow.png", 16, 28);

            lastDirection = hands.IsLeft();

            animationBow.SetDuration(30);
            SetAnimation(animationBow);
        }

        public bool GetShot()
        {
            return hands.GetShot();
        }

        public bool IsLeft()
        {
            return hands.IsLeft();
        }

        public override void Update()
        {
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
                SetPosition(hands.GetX() + 3, hands.GetY() - 7);
            }
            else
            {
                if (lastDirection != hands.IsLeft())
                {
                    lastDirection = hands.IsLeft();
                    GetAnimation().FlipAnimation();
                }
                SetPosition(hands.GetX() + 13, hands.GetY() - 7);
            }
            if (GetShot())
            {
                if (wait == 0 & !shot)
                {
                    GetAnimation().Start();
                    if (GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() - 1)
                    {
                        shot = true;
                        wait = 30;
                    }
                }
                else if (wait == 0 & shot)
                {
                    GetWorld().AddActor(new ArrowSkeleton(this));
                    GetAnimation().Stop();
                    GetAnimation().SetCurrentFrame(0);
                    wait = 90;
                    shot = false;
                }
                else
                {
                    wait--;
                }

            }
            else
            {
                GetAnimation().Stop();
                wait = 90;
            }
        }
    }
}
