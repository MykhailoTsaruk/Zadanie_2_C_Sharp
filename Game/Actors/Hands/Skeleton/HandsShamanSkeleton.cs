using Game.Actors.Enemy;
using Game.Actors.EnemyWeapon;
using Game.Actors.EnemyWeapon.Skeleton;
using Game.Actors.Functions;
using Merlin2d.Game;

namespace Game.Actors.Hands.Skeleton
{
    public class HandsShamanSkeleton : AbstractCharacter
    {
        private EnemyShaman shaman;
        private Animation animation;

        private int frame;
        private int anim;

        private bool create = false;

        public HandsShamanSkeleton(EnemyShaman shaman)
        {
            this.shaman = shaman;
            animation = new Animation("resources/sprites/Hands/HandsDead.png", 32, 16);

            SetAnimation(animation);
        }

        public bool GetShot()
        {
            return shaman.GetShot();
        }

        public bool IsLeft()
        {
            return shaman.IsLeft();
        }

        public override void Update()
        {
            if (shaman.IsDie())
            {
                GetWorld().RemoveActor(this);
            }
            if (!create)
            {
                GetWorld().AddActor(new ShamanSkeletonMagicStick(this));
                create = true;
            }
            frame = shaman.GetAnimation().GetCurrentFrame();

            _ = shaman.GetAnimation().GetFrameCount() == 4 ? (_ = frame == 0 | frame == 3 ? anim = 1 : anim = 0) :
            (_ = frame == 1 | frame == 2 | frame == 4 ? anim = 1 : anim = 0);

            if (shaman.IsLeft())
            {
                SetPosition(shaman.GetX() - 4, shaman.GetY() + 17 - anim);
            }
            else
            {
                SetPosition(shaman.GetX() + 4, shaman.GetY() + 17 - anim);
            }
        }
    }
}
