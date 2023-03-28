using Game.Actors.Functions;
using Game.Actors.Wizzard;
using Merlin2d.Game;

namespace Game.Items
{
    public class HealPotion : AbstractCharacter
    {
        private Player player;
        private Animation animationFull;
        private Animation animationEmpty;

        private int heal;

        public HealPotion(Animation animationFull, Animation animationEmpty, int heal)
        {
            this.animationFull = animationFull;
            this.animationEmpty = animationEmpty;
            this.heal = heal;

            SetAnimation(animationFull);
            GetAnimation().Start();
        }

        private bool CheckClosePlayer()
        {
            for (int i = -24; i < 24; i++)
            {
                for (int j = -24; j < 24; j++)
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
            }

            if (Input.GetInstance().IsKeyPressed(Input.Key.E) & CheckClosePlayer() 
                & GetAnimation() == animationFull)
            {
                player.SetHP(heal);
                heal = 0;
                SetAnimation(animationEmpty); 
                GetAnimation().Start();
            }
        }
    }
}
