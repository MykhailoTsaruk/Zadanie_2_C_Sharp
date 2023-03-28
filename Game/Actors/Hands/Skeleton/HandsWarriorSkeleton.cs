using Game.Actors.Enemy;
using Game.Actors.EnemyWeapon.Skeleton;
using Game.Actors.Functions;
using Merlin2d.Game;
using System.Security.Cryptography;

namespace Game.Actors.Hands.Skeleton
{
    public class HandsWarriorSkeleton : AbstractCharacter
    {
        private EnemyWarrior warrior;
        private Animation animation;

        private int frame;
        private int anim;
        private int randomWeapon;


        private bool attack = false;
        private bool create = false;

        public HandsWarriorSkeleton(EnemyWarrior warrior)
        {
            this.warrior = warrior;
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
            return warrior.IsLeft();
        }

        public override void Update()
        {
            if (!create)
            {
                if (randomWeapon < 50)
                {
                    GetWorld().AddActor(new BigSwordSkeleton(this, 0, 0));
                    GetWorld().AddActor(new BigSwordSkeleton(this, 18, 40));
                    warrior.SetHP(4);
                }
                else
                {
                    GetWorld().AddActor(new BigHammerSkeleton(this));
                }
                create = true;
            }
            if (warrior.IsDie())
            {
                GetWorld().RemoveActor(this);
            }
            attack = warrior.GetAttack();
            frame = warrior.GetAnimation().GetCurrentFrame();

            _ = warrior.GetAnimation().GetFrameCount() == 4 ? (_ = frame == 0 | frame == 3 ? anim = 1 : anim = 0) :
            (_ = frame == 1 | frame == 2 | frame == 4 ? anim = 1 : anim = 0);

            if (warrior.IsLeft())
            {
                SetPosition(warrior.GetX(), warrior.GetY() + 14 - anim);
            }
            else
            {
                SetPosition(warrior.GetX(), warrior.GetY() + 14 - anim);
            }
        }
    }
}
