using Game.Actors.Functions;
using Merlin2d.Game;

namespace Game.Actors.WorldObjects
{
    public class TorchLight : AbstractCharacter
    {
        private Animation animation;

        public TorchLight()
        {
            animation = new Animation("resources/sprites/TorchLight/Torch.png", 32, 32);

            SetAnimation(animation);
            GetAnimation().Start();
        }

        public override void Update()
        {

        }
    }
}
