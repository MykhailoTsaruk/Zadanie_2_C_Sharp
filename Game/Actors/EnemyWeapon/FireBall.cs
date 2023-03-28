using Game.Actors.Functions;
using Game.Actors.Wizzard;
using Merlin2d.Game;

namespace Game.Actors.EnemyWeapon
{
    public class FireBall : AbstractCharacter
    {
        private Player player;
        private Animation animationStart;
        private Animation animationEnd;

        private int iteration = 1;
        private int damage = -2;
        private int posX;
        private int posY;

        private bool start = true;
        private bool status = false;
        private bool directionLeft;

        public FireBall(bool directionLeft, int posX, int posY)
        {
            animationStart = new Animation("resources/sprites/Spell/Fire/Start/FireBallStart.png", 16, 11);
            animationEnd = new Animation("resources/sprites/Spell/Fire/End/FireBallEnd.png", 16, 16);

            this.directionLeft = directionLeft;
            this.posX = posX;
            this.posY = posY;

            SetName("FireBall");
            SetPosition(posX, posY);
        }

        private bool CheckClosePlayer()
        {
            for (int i = -16; i < 16; i++)
            {
                for (int j = -16; j < 16; j++)
                {
                    if (GetX() + i == player.GetX() & GetY() + j == player.GetY())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override void Update()
        {

            if (player == null)
            {
                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Player");
                if (directionLeft)
                {
                    SetAnimation(animationStart);
                    GetAnimation().FlipAnimation();
                    SetPosition(posX - 15, posY + 10);
                }
                else
                {
                    SetAnimation(animationStart);
                    SetPosition(posX + 35, posY + 10);
                }
            }
            if (GetWorld().IntersectWithWall(this))
            {
                GetWorld().RemoveActor(this);
            }
            if (CheckClosePlayer())
            {
                player.SetHP(damage);
                damage = 0;
                GetWorld().RemoveActor(this);
                return;
            }
            if (iteration % 2 == 0)
            {
                if (start)
                {
                    damage = -2;
                    if (GetAnimation().GetCurrentFrame() != GetAnimation().GetFrameCount() - 1)
                    {
                        if (directionLeft)
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
                        if (directionLeft)
                        {
                            SetPosition(GetX() - GetAnimation().GetCurrentFrame() * 2, GetY());
                            SetAnimation(animationEnd);
                            GetAnimation().FlipAnimation();
                        }
                        else
                        {
                            SetPosition(GetX() + GetAnimation().GetCurrentFrame() * 2, GetY());
                            SetAnimation(animationEnd);
                        }
                        start = !start;
                    }
                }
                else
                {
                    damage = -1;
                    if (GetAnimation().GetCurrentFrame() != GetAnimation().GetFrameCount() - 1)
                    {
                        if (directionLeft)
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
                        if (directionLeft)
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
        }
    }
}
