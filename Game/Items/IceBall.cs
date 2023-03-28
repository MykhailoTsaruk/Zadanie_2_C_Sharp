using Game.Actors.Functions;
using Game.Actors.Wizzard;
using Merlin2d.Game;

namespace Game.Items
{
    public class IceBall : AbstractCharacter
    {
        private Player player;
        private Animation animation_start;
        private Animation animation_end;
        private int iteration = 1;
        private int damage = 2;

        private bool start = true;
        private bool status = false;
        private bool direction_left;

        public IceBall()
        {
            animation_start = new Animation("resources/sprites/Spell/Ice/Start/IceBallStart.png", 16, 11);
            animation_end = new Animation("resources/sprites/Spell/Ice/End/IceBallEnd.png", 16, 16);

            SetName("IceBall");
        }

        public bool GetStatus()
        {
            return status;
        }

        public void SetStatus()
        {
            status = true;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void RemoveActor()
        {
            GetWorld().RemoveActor(this);
        }

        public override void Update()
        {
            if (player == null)
            {
                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Player");
                _ = player.IsLeft() ? direction_left = true : direction_left = false;
                if (direction_left)
                {
                    SetAnimation(animation_start);
                    GetAnimation().FlipAnimation();
                    SetPosition(player.GetX() - 15, player.GetY() + 10);
                }
                else
                {
                    SetAnimation(animation_start);
                    SetPosition(player.GetX() + 35, player.GetY() + 10);
                }
            }
            if (GetWorld().IntersectWithWall(this))
            {
                GetWorld().RemoveActor(this);
            }
            if (status)
            {
                GetWorld().RemoveActor(this);
            }
            if (iteration % 2 == 0)
            {
                if (start)
                {
                    damage = 2;
                    if (GetAnimation().GetCurrentFrame() != GetAnimation().GetFrameCount() - 1)
                    {
                        if (direction_left)
                        {
                            SetPosition(GetX() - GetAnimation().GetCurrentFrame() * 2, GetY());
                        }
                        else
                        {
                            SetPosition(GetX() + GetAnimation().GetCurrentFrame() * 2, GetY());
                        }
                    }
                    else
                    {
                        if (direction_left)
                        {
                            SetPosition(GetX() - GetAnimation().GetCurrentFrame() * 2, GetY());
                            SetAnimation(animation_end);
                            GetAnimation().FlipAnimation();
                        }
                        else
                        {
                            SetPosition(GetX() + GetAnimation().GetCurrentFrame() * 2, GetY());
                            SetAnimation(animation_end);
                        }
                        start = !start;
                    }
                }
                else
                {
                    damage = 1;
                    if (GetAnimation().GetCurrentFrame() != GetAnimation().GetFrameCount() - 1)
                    {
                        if (direction_left)
                        {
                            SetPosition(GetX() - GetAnimation().GetCurrentFrame(), GetY());
                        }
                        else
                        {
                            SetPosition(GetX() + GetAnimation().GetCurrentFrame(), GetY());
                        }
                    }
                    else
                    {
                        if (direction_left)
                        {
                            SetPosition(GetX() - GetAnimation().GetCurrentFrame(), GetY());
                        }
                        else
                        {
                            SetPosition(GetX() + GetAnimation().GetCurrentFrame(), GetY());
                        }
                        damage = 0;
                        GetWorld().RemoveActor(this);
                        status = true;
                    }
                }
                iteration--;
            }
            else
            {
                iteration++;
            }
            GetAnimation().Start();
            GetAnimation().SetDuration(2);
            //_ = direction_left ? SetPosition(GetX() - iteration, GetY()) : SetPosition(GetX() + iteration, GetY());
        }
    }
}
