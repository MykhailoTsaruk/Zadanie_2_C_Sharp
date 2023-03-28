﻿using Game.Actors.Functions;
using Game.Actors.Hands.Orcs;
using Game.Actors.Wizzard;
using Merlin2d.Game;

namespace Game.Actors.EnemyWeapon.Orc
{
    public class BigHammerOrc : AbstractCharacter
    {
        private Player player;
        private HandsWarriorOrc hands;
        private Animation animation;

        private int iteration = 0;

        private bool lastDirection;
        private bool pause = false;
        private bool attack = false;

        public BigHammerOrc(HandsWarriorOrc hands)
        {
            this.hands = hands;
            animation = new Animation("resources/sprites/Weapon/Orc/BigHammer.png", 38, 38);

            lastDirection = hands.IsLeft();

            SetAnimation(animation);
            animation.SetDuration(2);
        }

        public override void Update()
        {
            if (player == null)
            {
                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Player");
            }
            if (hands.RemovedFromWorld())
            {
                GetWorld().RemoveActor(this);
            }
            if (hands.IsLeft())
            {
                if (lastDirection != hands.IsLeft())
                {
                    lastDirection = hands.IsLeft();
                    GetAnimation().FlipAnimation();
                }
                SetPosition(hands.GetX() - 21, hands.GetY() - 26);
            }
            else
            {
                if (lastDirection != hands.IsLeft())
                {
                    lastDirection = hands.IsLeft();
                    GetAnimation().FlipAnimation();
                }
                SetPosition(hands.GetX() + 16, hands.GetY() - 26);
            }
            attack = hands.GetAttack();

            if (attack & iteration == 0)
            {
                GetAnimation().Start();
            }

            if (GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() / 2 & !pause)
            {
                player.SetHP(-2);
                pause = true;
            }


            GetAnimation().StopAt(GetAnimation().GetFrameCount() - 1);
            if (iteration == 0 & GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() - 1)
            {
                iteration = 80;
            }

            if (iteration != 0 & GetAnimation().GetCurrentFrame() == GetAnimation().GetFrameCount() - 1)
            {
                iteration--;
                pause = false;
            }
        }
    }
}
