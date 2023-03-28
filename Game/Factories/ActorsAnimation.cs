using Merlin2d.Game;

namespace Game.Factories
{
    public class ArcherAnimation
    {
        private List<Animation> animationOrc = new List<Animation>();
        private List<Animation> animationSkeleton = new List<Animation>();


        private Animation animationHoldOrcArcher = new Animation("resources/sprites/Enemy/Orc/Archer/Hold.png", 32, 32);
        private Animation animationRunOrcArcher = new Animation("resources/sprites/Enemy/Orc/Archer/Run.png", 32, 32);
        private Animation animationDeathOrcArcher = new Animation("resources/sprites/Enemy/Orc/Archer/Death.png", 32, 32);

        private Animation animationHoldSkeletonArcher = new Animation("resources/sprites/Enemy/Skeleton/Archer/Hold.png", 32, 32);
        private Animation animationRunSkeletonArcher = new Animation("resources/sprites/Enemy/Skeleton/Archer/Run.png", 32, 32);
        private Animation animationDeathSkeletonArcher = new Animation("resources/sprites/Enemy/Skeleton/Archer/Death.png", 32, 48);


        public List<Animation> GetOrc()
        {
            if (animationOrc.Count() == 0)
            {
                animationOrc.Add(animationHoldOrcArcher);
                animationOrc.Add(animationRunOrcArcher);
                animationOrc.Add(animationDeathOrcArcher);
            }

            return animationOrc;
        }

        public List<Animation> GetSkeleton()
        {
            if (animationSkeleton.Count() == 0)
            {
                animationSkeleton.Add(animationHoldSkeletonArcher);
                animationSkeleton.Add(animationRunSkeletonArcher);
                animationSkeleton.Add(animationDeathSkeletonArcher);
            }

            return animationSkeleton;
        }
    }

    public class RogueAnimation
    {
        private List<Animation> animationOrc = new List<Animation>();
        private List<Animation> animationSkeleton = new List<Animation>();


        private Animation animationHoldOrcRogue = new Animation("resources/sprites/Enemy/Orc/Rogue/Hold.png", 32, 32);
        private Animation animationRunOrcRogue = new Animation("resources/sprites/Enemy/Orc/Rogue/Run.png", 32, 32);
        private Animation animationDeathOrcRogue = new Animation("resources/sprites/Enemy/Orc/Rogue/Death.png", 32, 32);

        private Animation animationHoldSkeletonRogue = new Animation("resources/sprites/Enemy/Skeleton/Rogue/Hold.png", 32, 32);
        private Animation animationRunSkeletonRogue = new Animation("resources/sprites/Enemy/Skeleton/Rogue/Run.png", 32, 32);
        private Animation animationDeathSkeletonRogue = new Animation("resources/sprites/Enemy/Skeleton/Rogue/Death.png", 32, 36);


        public List<Animation> GetOrc()
        {
            if (animationOrc.Count() == 0)
            {
                animationOrc.Add(animationHoldOrcRogue);
                animationOrc.Add(animationRunOrcRogue);
                animationOrc.Add(animationDeathOrcRogue);
            }

            return animationOrc;
        }

        public List<Animation> GetSkeleton()
        {
            if (animationSkeleton.Count() == 0)
            {
                animationSkeleton.Add(animationHoldSkeletonRogue);
                animationSkeleton.Add(animationRunSkeletonRogue);
                animationSkeleton.Add(animationDeathSkeletonRogue);
            }

            return animationSkeleton;
        }
    }

    public class ShamanAnimation
    {
        private List<Animation> animationOrc = new List<Animation>();
        private List<Animation> animationSkeleton = new List<Animation>();


        private Animation animationHoldOrcShaman = new Animation("resources/sprites/Enemy/Orc/Shaman/Hold.png", 32, 32);
        private Animation animationRunOrcShaman = new Animation("resources/sprites/Enemy/Orc/Shaman/Run.png", 32, 32);
        private Animation animationDeathOrcShaman = new Animation("resources/sprites/Enemy/Orc/Shaman/Death.png", 32, 32);

        private Animation animationHoldSkeletonShaman = new Animation("resources/sprites/Enemy/Skeleton/Shaman/Hold.png", 32, 32);
        private Animation animationRunSkeletonShaman = new Animation("resources/sprites/Enemy/Skeleton/Shaman/Run.png", 32, 32);
        private Animation animationDeathSkeletonShaman = new Animation("resources/sprites/Enemy/Skeleton/Shaman/Death.png", 32, 56);


        public List<Animation> GetOrc()
        {
            if (animationOrc.Count() == 0)
            {
                animationOrc.Add(animationHoldOrcShaman);
                animationOrc.Add(animationRunOrcShaman);
                animationOrc.Add(animationDeathOrcShaman);
            }

            return animationOrc;
        }

        public List<Animation> GetSkeleton()
        {
            if (animationSkeleton.Count() == 0)
            {
                animationSkeleton.Add(animationHoldSkeletonShaman);
                animationSkeleton.Add(animationRunSkeletonShaman);
                animationSkeleton.Add(animationDeathSkeletonShaman);
            }

            return animationSkeleton;
        }
    }

    public class WarriorAnimation
    {
        private List<Animation> animationOrc = new List<Animation>();
        private List<Animation> animationSkeleton = new List<Animation>();


        private Animation animationHoldOrcWarrior = new Animation("resources/sprites/Enemy/Orc/Warrior/Hold.png", 32, 32);
        private Animation animationRunOrcWarrior = new Animation("resources/sprites/Enemy/Orc/Warrior/Run.png", 32, 32);
        private Animation animationDeathOrcWarrior = new Animation("resources/sprites/Enemy/Orc/Warrior/Death.png", 32, 32);

        private Animation animationHoldSkeletonWarrior = new Animation("resources/sprites/Enemy/Skeleton/Warrior/Hold.png", 32, 32);
        private Animation animationRunSkeletonWarrior = new Animation("resources/sprites/Enemy/Skeleton/Warrior/Run.png", 32, 32);
        private Animation animationDeathSkeletonWarrior = new Animation("resources/sprites/Enemy/Skeleton/Warrior/Death.png", 36, 46);


        public List<Animation> GetOrc()
        {
            if (animationOrc.Count() == 0)
            {
                animationOrc.Add(animationHoldOrcWarrior);
                animationOrc.Add(animationRunOrcWarrior);
                animationOrc.Add(animationDeathOrcWarrior);
            }

            return animationOrc;
        }

        public List<Animation> GetSkeleton()
        {
            if (animationSkeleton.Count() == 0)
            {
                animationSkeleton.Add(animationHoldSkeletonWarrior);
                animationSkeleton.Add(animationRunSkeletonWarrior);
                animationSkeleton.Add(animationDeathSkeletonWarrior);
            }

            return animationSkeleton;
        }
    }

    public class HealPotionAnimation
    {
        private List<Animation> animationBig = new List<Animation>();
        private List<Animation> animationSmall = new List<Animation>();

        private Animation BigHealPotionFull = new Animation("resources/sprites/Potion/BigPotionHeal.png", 10, 14);
        private Animation BigHealPotionEmpty = new Animation("resources/sprites/Potion/BigPotionHealEmpty.png", 10, 14);

        private Animation SmallHealPotionFull = new Animation("resources/sprites/Potion/SmallPotionHeal.png", 8, 13);
        private Animation SmallHealPotionEmpty = new Animation("resources/sprites/Potion/SmallPotionHealEmpty.png", 8, 13);

        public List<Animation> GetBigHealPotion()
        {
            if (animationBig.Count() == 0)
            {
                animationBig.Add(BigHealPotionFull);
                animationBig.Add(BigHealPotionEmpty);
            }
            return animationBig;
        }

        public List<Animation> GetSmallHealPotion()
        {
            if (animationSmall.Count() == 0)
            {
                animationSmall.Add(SmallHealPotionFull);
                animationSmall.Add(SmallHealPotionEmpty);
            }
            return animationSmall;
        }
    }
}
