using Game.Actors.Enemy;
using Game.Actors.Wizzard;
using Game.Actors.WorldObjects;
using Game.Items;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Game.Factories
{
    public class ActorFactory : IFactory
    {
        //EnemyAnimation
        private ArcherAnimation  archerAnimation  = new ArcherAnimation();
        private RogueAnimation   rogueAnimation   = new RogueAnimation();
        private ShamanAnimation  shamanAnimation  = new ShamanAnimation();
        private WarriorAnimation warriorAnimation = new WarriorAnimation();

        //PotionAnimation
        private HealPotionAnimation HealPotion = new HealPotionAnimation();

        public IActor Create(string actorType, string actorName, int x, int y)
        {
            IActor actor = null;

            if (actorType == "Player")
            {
                actor = Player.Instance(x, y, 2);
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Door")
            {
                actor = new Door();
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Lever")
            {
                actor = new Lever();
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "TorchLight")
            {
                actor = new TorchLight();
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "MagicBook")
            {
                actor = new MagicBook();
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "MagicStick")
            {
                actor = new MagicStick();
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "EnemyArcher")
            {
                if (actorName == "OrcArcher")
                {
                    actor = new EnemyArcher(archerAnimation.GetOrc()[0], archerAnimation.GetOrc()[1],
                        archerAnimation.GetOrc()[2], 4, 1);
                }
                else if (actorName == "SkeletonArcher")
                {
                    actor = new EnemyArcher(archerAnimation.GetSkeleton()[0], archerAnimation.GetSkeleton()[1],
                        archerAnimation.GetSkeleton()[2], 4, 1);
                }
                else
                {
                    throw new ArgumentException($"Unknown name {actorName}");
                }
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "EnemyRogue")
            {
                if (actorName == "OrcRogue")
                {
                    actor = new EnemyRogue(rogueAnimation.GetOrc()[0], rogueAnimation.GetOrc()[1],
                        rogueAnimation.GetOrc()[2], 6, 1);
                }
                else if (actorName == "SkeletonRogue")
                {
                    actor = new EnemyRogue(rogueAnimation.GetSkeleton()[0], rogueAnimation.GetSkeleton()[1],
                        rogueAnimation.GetSkeleton()[2], 6, 1);
                }
                else
                {
                    throw new ArgumentException($"Unknown name {actorName}");
                }
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "EnemyShaman")
            {
                if (actorName == "OrcShaman")
                {
                    actor = new EnemyShaman(shamanAnimation.GetOrc()[0], shamanAnimation.GetOrc()[1],
                        shamanAnimation.GetOrc()[2], 3, 1);
                }
                else if (actorName == "SkeletonShaman")
                {
                    actor = new EnemyShaman(shamanAnimation.GetSkeleton()[0], shamanAnimation.GetSkeleton()[1],
                        shamanAnimation.GetSkeleton()[2], 3, 1);
                }
                else
                {
                    throw new ArgumentException($"Unknown name {actorName}");
                }
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "EnemyWarrior")
            {
                if (actorName == "OrcWarrior")
                {
                    actor = new EnemyWarrior(warriorAnimation.GetOrc()[0], warriorAnimation.GetOrc()[1],
                        warriorAnimation.GetOrc()[2], 10, 1);
                }
                else if (actorName == "SkeletonWarrior")
                {
                    actor = new EnemyWarrior(warriorAnimation.GetSkeleton()[0], warriorAnimation.GetSkeleton()[1],
                        warriorAnimation.GetSkeleton()[2], 10, 1);
                }
                else
                {
                    throw new ArgumentException($"Unknown name {actorName}");
                }
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "HealPotion")
            {
                if (actorName == "BigHealPotion")
                {
                    actor = new HealPotion(HealPotion.GetBigHealPotion()[0], HealPotion.GetBigHealPotion()[1], 3);
                }
                else if (actorName == "SmallHealPotion")
                {
                    actor = new HealPotion(HealPotion.GetSmallHealPotion()[0], HealPotion.GetSmallHealPotion()[1], 1);
                }
                else
                {
                    throw new ArgumentException($"Unknown name {actorName}");
                }
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else
            {
                throw new ArgumentException($"Unknown type {actorType}");
            }

            return actor;
        }
    }
}
