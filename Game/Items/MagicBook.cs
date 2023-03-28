using Game.Actors.Functions;
using Game.Actors.Wizzard;
using Merlin2d.Game;

namespace Game.Items
{
    public class MagicBook : AbstractCharacter
    {
        private Player player;
        private Animation animation;


        private int anim;
        private int frame;
        private int drop = 0;
        private int iteration = 600;

        private bool direction;
        private bool IsLeft;
        private bool take = false;

        public MagicBook()
        {
            animation = new Animation("resources/sprites/Weapon/Wizzard/MagicBook.png", 13, 15);

            SetAnimation(animation);
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
                            take = true; ;
                            IsLeft = player.IsLeft();
                            direction = IsLeft;
                        }
                    }
                }
            }

            if (player.IsDie())
            {
                take = false;
                SetPhysics(true);
            }

            if (iteration != 0)
            {
                iteration--;
            }

            if (Input.GetInstance().IsKeyPressed(Input.Key.T) & drop > 0)
            {
                SetPhysics(true);
                take = !take;
                SetPosition(player.GetX(), player.GetY());
            }

            if (drop != 0)
            {
                drop--;
            }

            if (take)
            {
                IsLeft = player.IsLeft();
                if (direction != IsLeft) 
                {
                    GetAnimation().FlipAnimation();
                    direction = IsLeft;
                }
                SetPhysics(false);
                frame = player.GetAnimation().GetCurrentFrame();

                _ = player.GetAnimation().GetFrameCount() == 4 ? (_ = frame == 0 | frame == 3 ? anim = 1 : anim = 0) :
                    (_ = frame == 1 | frame == 2 | frame == 4 ? anim = 1 : anim = 0);

                if (player.IsLeft())
                {
                    SetPosition(player.GetX() + 13, player.GetY() + 14 - anim);
                }
                else
                {
                    SetPosition(player.GetX() + 6, player.GetY() + 14 - anim);
                }

                if (Input.GetInstance().IsKeyPressed(Input.Key.ONE))
                {
                    drop = 60;
                }

                if ((Input.GetInstance().IsKeyPressed(Input.Key.DOWN) | Input.GetInstance().IsKeyPressed(Input.Key.S)) & iteration == 0)
                {
                    player.SetHP(1);
                    iteration = 300;
                }
            }
        }
    }
}
