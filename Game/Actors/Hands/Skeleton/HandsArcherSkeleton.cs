using Game.Actors.Enemy;
using Game.Actors.EnemyWeapon;
using Game.Actors.EnemyWeapon.Skeleton;
using Game.Actors.Functions;
using Merlin2d.Game;

namespace Game.Actors.Hands.Skeleton
{
    public class HandsArcherSkeleton : AbstractCharacter
    {
        private EnemyArcher archer;
        private Animation animation;

        private int frame;
        private int anim;

        private bool create = false;

        public HandsArcherSkeleton(EnemyArcher archer)
        {
            this.archer = archer;
            animation = new Animation("resources/sprites/Hands/HandsDead.png", 32, 16);

            SetAnimation(animation);
        }

        public bool GetShot()
        {
            return archer.GetShot();
        }

        public bool IsLeft()
        {
            return archer.IsLeft();
        }

        public override void Update()
        {
            if (archer.IsDie())
            {
                GetWorld().RemoveActor(this);
            }
            if (!create)
            {
                GetWorld().AddActor(new BowSkeleton(this));
                create = true;
            }
            frame = archer.GetAnimation().GetCurrentFrame();

            _ = archer.GetAnimation().GetFrameCount() == 4 ? (_ = frame == 0 | frame == 3 ? anim = 1 : anim = 0) :
            (_ = frame == 1 | frame == 2 | frame == 4 ? anim = 1 : anim = 0);

            if (archer.IsLeft())
            {
                SetPosition(archer.GetX() - 2, archer.GetY() + 14 - anim);
            }
            else
            {
                SetPosition(archer.GetX() + 2, archer.GetY() + 14 - anim);
            }
        }
    }
}
