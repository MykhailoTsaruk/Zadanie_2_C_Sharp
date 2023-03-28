namespace Game.Items
{
    public class FullInventoryException : Exception
    {
        public FullInventoryException() : base() { }

        public FullInventoryException(string msg) : base(msg) { }
    }
}
