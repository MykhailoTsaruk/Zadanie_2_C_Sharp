using Merlin2d.Game.Items;
using System.Collections;

namespace Game.Items
{
    public class Backpack : IInventory
    {
        private IItem[] items;
        private int capacity;

        public Backpack(int capacity)
        {
            this.items = new IItem[capacity];
            this.capacity = capacity;
        }

        public void AddItem(IItem item)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    return;
                }
            }

            throw new FullInventoryException("The backpack is full!");
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            foreach (IItem item in items)
            {
                if (item != null)
                    yield return item;
                else
                    yield break;
            }
        }

        public IItem GetItem()
        {
            return items[0];
        }

        public void RemoveItem(IItem item)
        {
            int index = Array.IndexOf(items, item);
            if (index != -1)
                this.RemoveItem(index);
        }

        public void RemoveItem(int index)
        {
            // TODO: remove item based on its index
            throw new NotImplementedException();
        }

        public void ShiftLeft()
        {
            // TODO: move all items in the backpack to the left
            throw new NotImplementedException();
        }

        public void ShiftRight()
        {
            // TODO: move all items in the backpack to the right
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
