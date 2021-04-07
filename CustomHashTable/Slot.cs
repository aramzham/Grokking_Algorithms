using System.Collections.Generic;

namespace CustomHashTable
{
    public class Slot
    {
        private readonly LinkedList<int> _linkedList = new LinkedList<int>();

        public Slot()
        {
            
        }

        public void Add(int item)
        {
            _linkedList.AddLast(item);
        }
    }
}