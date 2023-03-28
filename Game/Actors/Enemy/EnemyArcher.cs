using Game.Actors.Functions;
using Game.Actors.Hands.Orcs;
using Game.Actors.Hands.Skeleton;
using Game.Actors.Wizzard;
using Game.Commands;
using Game.Items;
using Merlin2d.Game;
using Merlin2d.Game.Actions;

namespace Game.Actors.Enemy
{
    public class EnemyArcher : AbstractCharacter
    {
        private Player player;
        private int ClosePlayerGetX;

        private Animation animationHold;
        private Animation animationRun;
        private Animation animationDeath;

        private ICommand moveLeft;
        private ICommand moveRight;
        private ICommand lastMove;
        private ICommand thisMove;

        private int healthPoint;

        private int move;
        private int wait = 40;

        private bool stalking = false;
        private bool die = false;
        private bool shot = false;

        public EnemyArcher(Animation animationHold, Animation animationRun,
            Animation animationDeath, int healthPoint, int speed)
        {
            this.animationHold = animationHold;
            this.animationRun = animationRun;
            this.animationDeath = animationDeath;

            this.healthPoint = healthPoint;

            moveLeft = new Move(this, speed, -1, 0);
            moveRight = new Move(this, speed, 1, 0);
            lastMove = moveRight;

            SetAnimation(animationHold);
            this.animationRun.SetDuration(5);
        }

        private void SetHP(int damage)
        {
            healthPoint -= damage;
            return;
        }

        private void FlipAllAnimation()
        {
            animationHold.FlipAnimation();
            animationRun.FlipAnimation();
            animationDeath.FlipAnimation();
        }

        private bool CheckClosePlayer()
        {
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if ((player.GetX() == GetX() + i | player.GetX() == GetX() - i) &
                        (player.GetY() == GetY() + j | player.GetY() == GetY() - j))
                    {
                        ClosePlayerGetX = player.GetX();
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckIsLeftPlayer()
        {
            return GetX() > ClosePlayerGetX ? true : false;
        }

        private void CheckCloseIceBall(IceBall iceBall)
        {
            if (iceBall != null)
            {
                for (int i = 0; i < GetAnimation().GetWidth(); i++)
                {
                    for (int j = 0; j < GetAnimation().GetHeight(); j++)
                    {
                        if (GetX() + i == iceBall.GetX() & GetY() + j == iceBall.GetY())
                        {
                            SetHP(iceBall.GetDamage());
                            iceBall.SetStatus();
                            return;
                        }
                    }
                }
            }
        }

        public bool IsDie()
        {
            return die;
        }

        public bool IsLeft()
        {
            return lastMove == moveLeft ? true : false;
        }

        public bool GetShot()
        {
            return shot;
        }

        public override void Update()
        {
            if (player == null)
            {
                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Player");
                if (GetName() == "OrcArcher")
                {
                    GetWorld().AddActor(new HandsArcherOrc(this));
                }
                else if (GetName() == "SkeletonArcher")
                {
                    GetWorld().AddActor(new HandsArcherSkeleton(this));
                }
            }
            if (!die)
            {
                CheckCloseIceBall((IceBall)GetWorld().GetActors().Find(actor => actor.GetName() == "IceBall"));
                _ = CheckClosePlayer() ? stalking = true : stalking = false;
                if (!stalking)
                {
                    if (wait == 0)
                    {
                        if (move != 0)
                        {
                            SetAnimation(animationRun);
                            if (thisMove != lastMove)
                            {
                                FlipAllAnimation();
                                lastMove = thisMove;
                            }
                            thisMove.Execute();
                            move--;
                        }
                        else
                        {
                            SetAnimation(animationHold);
                            wait = 90;
                            move = 210;
                            if (lastMove == moveLeft)
                            {
                                thisMove = moveRight;
                            }
                            else
                            {
                                thisMove = moveLeft;
                            }
                        }
                    }
                    else
                    {
                        wait--;
                    }
                    shot = false;
                }
                else
                {
                    shot = true;
                    SetAnimation(animationHold);
                    if (CheckIsLeftPlayer())
                    {
                        if (lastMove == moveRight)
                        {
                            FlipAllAnimation();
                        }
                        lastMove = moveLeft;
                    }
                    else
                    {
                        if (lastMove == moveLeft)
                        {
                            FlipAllAnimation();
                        }
                        lastMove = moveRight;
                    }
                }
                if (healthPoint <= 0)
                {
                    SetAnimation(animationDeath);
                    if (GetName() == "SkeletonArcher")
                    {
                        SetPosition(GetX(), GetY() - 16);
                        GetAnimation().SetDuration(8);
                    }
                    else
                    {
                        GetAnimation().SetDuration(15);
                    }
                    GetAnimation().Start();
                    die = true;
                }
                GetAnimation().Start();
            }
            else
            {
                if (GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() - 1)
                {
                    GetAnimation().Stop();
                }
            }
            //Console.WriteLine(healthPoint);
        }
    }
}
