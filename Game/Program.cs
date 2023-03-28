using Game.Actors.Wizzard;
using Game.Commands;
using Game.Factories;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("Game window", 1600, 900);

            container.SetMap("resources/maps/Map.tmx");

            container.GetWorld().SetPhysics(new Gravity());
            container.GetWorld().SetFactory(new ActorFactory());

            container.GetWorld().AddInitAction((world) =>
            {
                IActor player = world.GetActors().ToList().Find(actor => actor is Player)!;
                world.CenterOn(player);
            }
            );

            container.SetCameraFollowStyle(CameraFollowStyle.CenteredInsideMapPreferTop);
            container.SetCameraZoom((float)2.5);
            container.Run();
        }
    }
}