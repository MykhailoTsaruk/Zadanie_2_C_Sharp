using Game.Actors.Enemy;
using Game.Actors.EnemyWeapon;
using Game.Actors.EnemyWeapon.Orcs;
using Game.Actors.Functions;
using Merlin2d.Game;

namespace Game.Actors.Hands.Orcs
{
    public class HandsArcherOrc : AbstractCharacter
    {
        private EnemyArcher archer;
        private Animation animation;

        private int frame;
        private int anim;

        private bool create = false;

        public HandsArcherOrc(EnemyArcher archer)
        {
            this.archer = archer;
            animation = new Animation("resources/sprites/Hands/HandsAlive.png", 32, 16);

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
                GetWorld().AddActor(new BowOrc(this));
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
