using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Game.Actors.Functions
{
    public abstract class AbstractActor : IActor
    {
        private string name;
        private int posX;
        private int posY;
        private Animation animation_hold;
        private IWorld world;
        private bool affectedByPhysics;
        private bool toBeRemoved = false;

        public AbstractActor()
        {
            name = "";
        }

        public AbstractActor(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int GetX()
        {
            return posX;
        }

        public int GetY()
        {
            return posY;
        }

        public void SetPosition(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public int GetHeight()
        {
            return animation_hold.GetHeight();
        }

        public int GetWidth()
        {
            return animation_hold.GetWidth();
        }

        public void OnAddedToWorld(IWorld world)
        {
            this.world = world;
        }

        public IWorld GetWorld()
        {
            return world;
        }

        public Animation GetAnimation()
        {
            return animation_hold;
        }

        public void SetAnimation(Animation animation_hold)
        {
            this.animation_hold = animation_hold;
        }

        public void SetPhysics(bool isPhysicsEnabled)
        {
            affectedByPhysics = isPhysicsEnabled;
        }

        public bool IsAffectedByPhysics()
        {
            return affectedByPhysics;
        }

        public bool IntersectsWithActor(IActor other)
        {
            if (posX > other.GetX() + other.GetWidth() || posX + GetWidth() < other.GetX())
                return false;

            if (posY > other.GetY() + other.GetHeight() || posY + GetHeight() < other.GetY())
                return false;

            return true;
        }

        public bool RemovedFromWorld()
        {
            return toBeRemoved;
        }

        public void RemoveFromWorld()
        {
            toBeRemoved = true;
        }

        public abstract void Update();
    }
}
