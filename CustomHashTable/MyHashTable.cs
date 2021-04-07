namespace CustomHashTable
{
    public class MyHashTable
    {
        // load factor > 0.7 => resize by twice
        private int[] _baseArray = new int[4]; // we start by 4
        private Slot[] _slots = new Slot[4];
        private int _occupiedSlotsCount;
        private float _loadFactor => (float)_occupiedSlotsCount / _baseArray.Length;
        private const float RESIZE_THRESHOLD = 0.7f;

        public void Add(string key, int value)
        {
            var hash = GetHash(key);
            var index = hash % _baseArray.Length;

            var slot = _slots[index];
            //if(slot is null)
            //    slot = new Slot(hash, value);
            AddToSlot(index, value);
        }

        //public int Get(string key)
        //{
        //    var baseArrayIndex = GetBaseArrayIndex(key);

        //}

        private void AddToSlot(int index, int value)
        {
            var slot = _slots[index];
            slot ??= new Slot();
            slot.Add(value);
        }

        private int GetBaseArrayIndex(string key)
        {
            var hash = GetHash(key);
            return hash % _baseArray.Length;
        }

        private int GetHash(string key)
        {
            return (int)MurmurHash2.Hash(key);
        }

        private void Resize()
        {
            // baseArray.Length x 2 -> next prime number
        }
    }
}