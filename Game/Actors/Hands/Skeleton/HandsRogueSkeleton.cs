using Game.Actors.Enemy;
using Game.Actors.EnemyWeapon;
using Game.Actors.EnemyWeapon.Skeleton;
using Game.Actors.Functions;
using Merlin2d.Game;
using System.Security.Cryptography;

namespace Game.Actors.Hands.Skeleton
{
    public class HandsRogueSkeleton : AbstractCharacter
    {
        private EnemyRogue rogue;
        private Animation animation;

        private int frame;
        private int anim;
        private int randomWeapon;

        private bool attack = false;
        private bool create = false;

        public HandsRogueSkeleton(EnemyRogue rogue)
        {
            this.rogue = rogue;
            animation = new Animation("resources/sprites/Hands/HandsDead.png", 32, 16);

            randomWeapon = RandomNumberGenerator.GetInt32(100);

            SetAnimation(animation);
        }

        public bool GetAttack()
        {
            return attack;
        }

        public bool IsLeft()
        {
            return rogue.IsLeft();
        }

        public override void Update()
        {
            if (rogue.IsDie())
            {
                GetWorld().RemoveActor(this);
            }
            if (!create)
            {
                if (randomWeapon < 50)
                {
                    GetWorld().AddActor(new SwordSkeleton(this));
                }
                else
                {
                    GetWorld().AddActor(new AxeSkeleton(this));
                }
                create = true;
            }
            attack = rogue.GetAttack();
            frame = rogue.GetAnimation().GetCurrentFrame();

            _ = rogue.GetAnimation().GetFrameCount() == 4 ? (_ = frame == 0 | frame == 3 ? anim = 1 : anim = 0) :
            (_ = frame == 1 | frame == 2 | frame == 4 ? anim = 1 : anim = 0);

            if (rogue.IsLeft())
            {
                SetPosition(rogue.GetX(), rogue.GetY() + 14 - anim);
            }
            else
            {
                SetPosition(rogue.GetX(), rogue.GetY() + 14 - anim);
            }
        }
    }
}
