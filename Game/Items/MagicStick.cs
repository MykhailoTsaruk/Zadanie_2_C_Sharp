using Game.Actors.Functions;
using Game.Actors.Wizzard;
using Merlin2d.Game;

namespace Game.Items
{
    public class MagicStick : AbstractCharacter
    {
        private Player player;
        private Animation animation;

        private int anim;
        private int frame;
        private int drop = 0;
        private int iterationShot = 0;

        private bool take = false;
        private bool shot = false;
        private bool isLeft = false;

        public MagicStick()
        {
            animation = new Animation("resources/sprites/Weapon/Wizzard/MagicStick.png", 28, 28);

            SetAnimation(animation);
            GetAnimation().SetDuration(3);
        }

        public bool GetTake()
        {
            return take;
        }

        public override void Update()
        {
            if (player == null)
            {
                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Player");
            }
            if (Input.GetInstance().IsKeyDown(Input.Key.E) & !take & !player.IsDie())
            {
                for (int i = 0; i < player.GetWidth(); i++)
                {
                    for (int j = 0; j < player.GetWidth(); j++)
                    {
                        if (GetX() == player.GetX() + i & GetY() == player.GetY() + j)
                        {
                            take = !take;
                        }
                    }
                }
            }

            if (player.IsDie())
            {
                take = false;
                SetPhysics(true);
            }

            if (Input.GetInstance().IsKeyPressed(Input.Key.TWO) & take)
            {
                drop = 60;
            }

            if (Input.GetInstance().IsKeyPressed(Input.Key.T) & drop > 0)
            {
                take = !take;
                SetPosition(player.GetX(), player.GetY());
                SetPhysics(true);
            }
            if (drop != 0)
            {
                drop--;
            }

            if (take)
            {
                if (isLeft != player.IsLeft())
                {
                    GetAnimation().FlipAnimation();
                    isLeft = player.IsLeft();
                }
                SetPhysics(false);
                frame = player.GetAnimation().GetCurrentFrame();

                _ = player.GetAnimation().GetFrameCount() == 4 ? (_ = frame == 0 | frame == 3 ? anim = 1 : anim = 0) :
                    (_ = frame == 1 | frame == 2 | frame == 4 ? anim = 1 : anim = 0);

                if (player.IsLeft())
                {
                    SetPosition(player.GetX() - 18, player.GetY() - 2 - anim);
                }
                else
                {
                    SetPosition(player.GetX() + 22, player.GetY() - 2 - anim);
                }

                if (Input.GetInstance().IsKeyPressed(Input.Key.SPACE) & iterationShot == 0)
                {
                    shot = true;
                }

                if (shot)
                {
                    GetAnimation().Start();
                    GetAnimation().StopAt(GetAnimation().GetFrameCount() - 1);
                    if (GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() / 2)
                    {
                        GetWorld().AddActor(new IceBall());
                        iterationShot = 60;
                        shot = false;
                    }
                }
                if (iterationShot != 0 & !shot & GetAnimation().GetCurrentFrame() != GetAnimation().GetFrameCount() / 2)
                {
                    iterationShot--;
                }

            }
        }
    }
}
