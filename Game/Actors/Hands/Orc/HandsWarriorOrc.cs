using Game.Actors.Enemy;
using Game.Actors.EnemyWeapon.Orc;
using Game.Actors.EnemyWeapon.Orcs;
using Game.Actors.Functions;
using Merlin2d.Game;
using System.Security.Cryptography;

namespace Game.Actors.Hands.Orcs
{
    public class HandsWarriorOrc : AbstractCharacter
    {
        private EnemyWarrior warrior;
        private Animation animation;

        private int frame;
        private int anim;
        private int randomWeapon;


        private bool attack = false;
        private bool create = false;

        public HandsWarriorOrc(EnemyWarrior warrior)
        {
            this.warrior = warrior;
            animation = new Animation("resources/sprites/Hands/HandsAlive.png", 32, 16);

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
                    GetWorld().AddActor(new ShieldWarriorOrc(this));
                    GetWorld().AddActor(new BigSwordOrc(this));
                }
                else
                {
                    GetWorld().AddActor(new BigHammerOrc(this));
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
