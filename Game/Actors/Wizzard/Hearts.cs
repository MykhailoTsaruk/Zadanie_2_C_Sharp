using Game.Actors.Functions;
using Merlin2d.Game;

namespace Game.Actors.Wizzard
{
    public class Hearts : AbstractCharacter
    {
        private Player player;
        //private Animation animation;
        private List<Animation> animation = new List<Animation>();

        private int healthPoint;

        public Hearts()
        {
            for (int i = 0; i <= 6; i++)
            {
                animation.Add(new Animation($"resources/sprites/Heart/HP/{i}.png", 48, 16));
            }
        }

        public override void Update()
        {
            if (player == null)
            {
                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Player");
                healthPoint = player.GetHP();
                SetAnimation(animation[healthPoint]);
            }
            if (player.GetHP() != healthPoint)
            {
                healthPoint = player.GetHP();
                SetAnimation(animation[healthPoint]);
            }
            SetPosition(player.GetX() - 8, player.GetY() - 17);
        }
    }
}
