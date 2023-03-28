using Game.Actors.Functions;
using Game.Actors.Hands.Wizzard;
using Game.Actors.WorldObjects;
using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;

namespace Game.Actors.Wizzard
{
    public class Player : AbstractCharacter
    {
        private static Player instance = null;
        public static Player Instance(int x, int y, int speed)
        {
            if (instance == null)
            {
                instance = new Player(x, y, speed);
            }
            return instance;
        }
        
        private Animation animation_hold;
        private Animation animation_run;
        private Animation animation_die;

        private int speed;
        private ICommand lastMove;
        private ICommand moveUp;
        private ICommand moveRight;
        private ICommand moveLeft;
        private ICommand moveRightRush;
        private ICommand moveLeftRush;

        private Lever lever;
        private Door door;

        private int iteration_shot = 0;
        private int iteration_jump = 0;
        private int healthPoint = 6;
        private int stamina;

        private bool jump = true;
        private bool stop = false;
        private bool die = false;
        private bool move = false;
        private bool create = false;


        public Player(int x, int y, int speed)
        {
            SetPosition(x, y);

            animation_hold = new Animation("resources/sprites/Player/Hold.png",  32, 32);
            animation_run  = new Animation("resources/sprites/Player/Run.png",   32, 32);
            animation_die  = new Animation("resources/sprites/Player/Death.png", 42, 32);

            animation_run.SetDuration(5);

            SetAnimation(animation_hold);
            GetAnimation().Start();

            this.speed = speed;

            SetSpeedStrategy(new ModifiedSpeedStrategy());

            moveUp     = new Jump(this, -4);
            moveRight  = new Move(this, speed, 1, 0);
            moveLeft   = new Move(this, speed, -1, 0);

            moveRightRush = new Move(this, GetSpeed(speed),  1, 0);
            moveLeftRush  = new Move(this, GetSpeed(speed), -1, 0);

            lastMove = moveRight;
        }

        public bool IsDie()
        {
            return GetAnimation() == animation_die ? true : false;
        }

        public bool IsLeft()
        {
            return lastMove == moveLeft ? true : false;
        }

        public int GetHP()
        {
            if (healthPoint < 0)
            {
                die = true;
                return 0;
            }
            return healthPoint;
        }

        public void SetHP(int healthPoint)
        {
            if (this.healthPoint > 0 & this.healthPoint <= 6)
            {
                //_ = this.healthPoint < healthPoint ? this.healthPoint = 0 : this.healthPoint += healthPoint;
                if (this.healthPoint + healthPoint > 6)
                {
                    this.healthPoint = 6;
                }
                else if (this.healthPoint + healthPoint < 0) 
                {
                    this.healthPoint = 0;
                }
                else
                {
                    this.healthPoint += healthPoint;
                }
            }
        }

        public void SetLever(Lever lever)
        {
            this.lever = lever;
        }

        public void SetDoor(Door door)
        {
            this.door = door;
        }

        private bool CheckCloseDoor()
        {
            if (lever == null)
            {
                return false;
            }
            if (lever.GetStatus())
            {
                return false;
            }
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    if (GetX() + i + 1 == door.GetX() & GetY() == door.GetY() + j)
                    {
                        if (IsLeft()) SetPosition(GetX() + 1, GetY());
                        else SetPosition(GetX() - 1, GetY());
                        return true;
                    }
                }
            }
            return false;
        }

        public override void Update()
        {
            if (!create)
            {
                GetWorld().AddActor(new HandsPlayer());
                GetWorld().AddActor(new Hearts());
                create = true;
            }
            if (!stop)
            {
                if (!die)
                {
                    if (Input.GetInstance().IsKeyPressed(Input.Key.O))
                    {
                        SetHP(-1);
                    }
                    if (Input.GetInstance().IsKeyPressed(Input.Key.UP) | Input.GetInstance().IsKeyPressed(Input.Key.W))
                    {
                        if (jump & stamina == 0)
                        {
                            iteration_jump = 25;
                            stamina = iteration_jump * 3;
                            jump = !jump;
                            SetPhysics(false);
                        }
                    }
                    if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT) | Input.GetInstance().IsKeyDown(Input.Key.D))
                    {
                        if (!CheckCloseDoor())
                        {
                            if (lastMove == moveLeft)
                            {
                                animation_run.FlipAnimation();
                                animation_hold.FlipAnimation();
                                animation_die.FlipAnimation();
                            }
                            move = true;
                            //SetAnimation(animation_run);
                            //GetAnimation().Start();
                            if (Input.GetInstance().IsKeyDown(Input.Key.LEFT_SHIFT))
                            {
                                moveRightRush.Execute();
                            }
                            else
                            {
                                moveRight.Execute();
                            }
                            lastMove = moveRight;
                        }
                    }
                    if (Input.GetInstance().IsKeyDown(Input.Key.LEFT) | Input.GetInstance().IsKeyDown(Input.Key.A))
                    {
                        if (!CheckCloseDoor())
                        {
                            if (lastMove == moveRight)
                            {
                                animation_run.FlipAnimation();
                                animation_hold.FlipAnimation();
                                animation_die.FlipAnimation();
                            }
                            move = true;
                            //SetAnimation(animation_run);
                            //GetAnimation().Start();
                            if (Input.GetInstance().IsKeyDown(Input.Key.LEFT_SHIFT))
                            {
                                moveLeftRush.Execute();
                            }
                            else
                            {
                                moveLeft.Execute();
                            }
                            lastMove = moveLeft;
                        }
                    }
                    if (move)
                    {
                        SetAnimation(animation_run);
                    }
                    else
                    {
                        SetAnimation(animation_hold);
                    }
                    GetAnimation().Start();
                    move = false;

                    if (!jump)
                    {
                        animation_hold.Start();
                        moveUp.Execute();

                        iteration_jump--;

                        if (iteration_jump == 0)
                        {
                            jump = !jump;
                            SetPhysics(true);
                        }
                    }
                    if (stamina != 0)
                    {
                        stamina--;
                    }
                    if (iteration_shot != 0)
                    {
                        iteration_shot--;
                    }

                    if (healthPoint == 0)
                    {
                        die = true;
                    }
                }

                else if (die)
                {
                    SetAnimation(animation_die);
                    animation_die.Start();
                    animation_die.SetDuration(25);
                    if (animation_die.GetCurrentFrame() == animation_die.GetFrameCount() - 1)
                    {
                        stop = !stop;
                        animation_die.Stop();
                    }
                }
            }
        }
    }
}
