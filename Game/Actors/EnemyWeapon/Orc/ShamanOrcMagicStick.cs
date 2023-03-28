using Game.Actors.Functions;
using Game.Actors.Hands.Orcs;
using Merlin2d.Game;

namespace Game.Actors.EnemyWeapon.Orcs
{
    public class ShamanOrcMagicStick : AbstractCharacter
    {
        private HandsShamanOrc hands;
        private Animation animation;

        private int wait = 0;

        private bool isLeft = false;
        private bool shot = false;

        public ShamanOrcMagicStick(HandsShamanOrc hands)
        {
            this.hands = hands;
            animation = new Animation("resources/sprites/Weapon/Orc/ShamanOrcMagicStick.png", 28, 28);

            isLeft = hands.IsLeft();

            SetAnimation(animation);
            GetAnimation().SetDuration(3);
        }

        public override void Update()
        {
            if (hands.RemovedFromWorld())
            {
                GetWorld().RemoveActor(this);
            }
            if (hands.IsLeft())
            {
                if (isLeft != hands.IsLeft())
                {
                    isLeft = hands.IsLeft();
                    GetAnimation().FlipAnimation();
                }
                SetPosition(hands.GetX() - 16, hands.GetY() - 16);
            }
            else
            {
                if (isLeft != hands.IsLeft())
                {
                    isLeft = hands.IsLeft();
                    GetAnimation().FlipAnimation();
                }
                SetPosition(hands.GetX() + 20, hands.GetY() - 16);
            }
            if (hands.GetShot())
            {
                if (wait == 0 & !shot)
                {
                    GetAnimation().Start();
                    if (GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() / 2)
                    {
                        GetWorld().AddActor(new FireBall(isLeft, GetX(), GetY()));
                        GetAnimation().StopAt(GetAnimation().GetFrameCount() - 1);
                        shot = true;
                        wait = 90;
                    }
                }
                else if (wait != 0)
                {
                    wait--;
                }
                if (wait == 0 & shot)
                {
                    shot = false;
                }
            }
            else
            {
                wait = 90;
            }
        }
    }
}
