using Game.Actors.Functions;
using Game.Actors.Wizzard;
using Merlin2d.Game;

namespace Game.Actors.EnemyWeapon.Skeleton
{
    public class ArrowSkeleton : AbstractCharacter
    {
        private Player player;
        private BowSkeleton bow;
        private Animation animation;

        private int timeFlight = 30;
        private int timer = 2;
        private int damage;

        private bool create = false;
        private bool isLeft = false;

        public ArrowSkeleton(BowSkeleton bow)
        {
            this.bow = bow;
            animation = new Animation("resources/sprites/Weapon/Skeleton/Arrow.png", 15, 6);

            SetAnimation(animation);
            if (bow.IsLeft())
            {
                GetAnimation().FlipAnimation();
                isLeft = true;
            }
            SetPosition(this.bow.GetX(), this.bow.GetY() + 5);

            damage = -1;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }

        private void SetPlayer()
        {
            player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Player");
        }

        private void CheckClosePlayer()
        {
            for (int i = 0; i < player.GetAnimation().GetWidth(); i++)
            {
                for (int j = 0; j < player.GetAnimation().GetHeight(); j++)
                {
                    if (player.GetX() + i == GetX() & player.GetY() + j == GetY())
                    {
                        player.SetHP(damage);
                        GetWorld().RemoveActor(this);
                        return;
                    }
                }
            }
        }

        public override void Update()
        {
            if (!create)
            {
                SetPlayer();
                create = true;
            }
            CheckClosePlayer();
            if (timeFlight != 0)
            {
                if (timer == 0)
                {
                    if (isLeft)
                    {
                        SetPosition(GetX() - timeFlight, GetY());
                    }
                    else
                    {
                        SetPosition(GetX() + timeFlight, GetY());
                    }
                    timeFlight--;
                    timer = 2;
                }
                else
                {
                    timer--;
                }
            }
            else
            {
                damage = 0;
                GetWorld().RemoveActor(this);
            }
        }
    }
}
