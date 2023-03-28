using Game.Actors.Functions;
using Game.Actors.Wizzard;
using Merlin2d.Game;

namespace Game.Actors.WorldObjects
{
    public class Lever : AbstractCharacter
    {
        private Player player;
        private Animation animation_off;
        private Animation animation_on;

        private bool on = false;
        private bool create = false;

        public Lever()
        {
            //animation = new Animation("resources/sprites/Lever/Lever.png", 32, 15);
            animation_on = new Animation("resources/sprites/Lever/LeverPos2.png", 19, 13);
            animation_off = new Animation("resources/sprites/Lever/LeverPos1.png", 18, 13);

            SetAnimation(animation_off);
            //this.GetAnimation().SetCurrentFrame(1);
        }

        public bool GetStatus()
        {
            return on;
        }

        public override void Update()
        {
            if (!create)
            {
                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Player");
                player.SetLever(this);
                create = true;
            }
            if (!on)
            {
                if (Input.GetInstance().IsKeyPressed(Input.Key.F))
                {
                    for (int i = 0; i < player.GetAnimation().GetWidth() / 2; i++)
                    {
                        for (int j = 0; j < player.GetAnimation().GetHeight(); j++)
                        {
                            if (player.GetX() + i == GetX() & player.GetY() == GetY() - j)
                            {
                                SetAnimation(animation_on);
                                on = !on;
                                //this.GetAnimation().SetCurrentFrame(2);
                            }
                        }
                    }
                }
            }
        }
    }
}
