using Game.Actors.Functions;
using Game.Actors.Hands.Orcs;
using Merlin2d.Game;

namespace Game.Actors.EnemyWeapon.Orcs
{
    public class ShieldWarriorOrc : AbstractCharacter
    {
        private HandsWarriorOrc hands;
        private Animation animation;

        public ShieldWarriorOrc(HandsWarriorOrc hands)
        {
            this.hands = hands;
            animation = new Animation("resources/sprites/Weapon/Orc/Shield.png", 16, 16);

            SetAnimation(animation);
        }

        public override void Update()
        {
            if (hands.IsLeft()) SetPosition(hands.GetX() + 16, hands.GetY() - 2);
            else SetPosition(hands.GetX(), hands.GetY() - 2);
        }
    }
}
