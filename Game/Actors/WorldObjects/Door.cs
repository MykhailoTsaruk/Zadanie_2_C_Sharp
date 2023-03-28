using Game.Actors.Functions;
using Game.Actors.Wizzard;
using Merlin2d.Game;

namespace Game.Actors.WorldObjects
{
    public class Door : AbstractActor
    {

        private Player player;

        private Animation animationHold;
        //private Animation animationLeft;
        private Animation animationRight;

        private Lever lever;


        private bool create = false;

        public Door()
        {
            animationHold = new Animation("resources/sprites/Door/Door.png", 24, 64);
            //animationLeft  = new Animation("resources/sprites/Door/DoorLeft.png",  40, 64);
            animationRight = new Animation("resources/sprites/Door/DoorRight.png", 40, 64);

            SetAnimation(animationHold);
        }

        private bool CheckClosePlayer()
        {
            for (int i = -20; i < 60; i++)
            {
                for (int j = 0; j < 96; j++)
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
            if (!create)
            {
                lever = (Lever)GetWorld().GetActors().Find(actor => actor.GetName() == "LeverDoor1");
                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Player");
                player.SetDoor(this);
                create = true;
            }

            if (lever.GetStatus())
            {
                if (CheckClosePlayer())
                {
                    SetAnimation(animationRight);
                }
                else
                {
                    SetAnimation(animationHold);
                }
            }
        }
    }
}
