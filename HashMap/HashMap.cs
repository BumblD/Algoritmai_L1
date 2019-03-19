using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class HashMap<K, V> where V : class
    {
        //hash element array 
        HashNode<int, V>[] arr;
        int capacity;
        //current size 
        int size;
        //dummy node 
        HashNode<int, V> dummy;

        public HashMap()
        {
            //Initial capacity of hash array 
            capacity = 10;
            size = 0;
            arr = new HashNode<int, V>[capacity];

            //Initialise all elements of array as NULL 
            for (int i = 0; i < capacity; i++)
                arr[i] = null;

            //dummy node with value and key -1
            dummy = new HashNode<int, V>(-1, -1 as V);
        }

        public HashMap(int mapSize)
        {
            capacity = mapSize;
            size = 0;
            arr = new HashNode<int, V>[capacity];

            //Initialise all elements of array as NULL 
            for (int i = 0; i < capacity; i++)
                arr[i] = null;

            //dummy node with value and key -1
            dummy = new HashNode<int, V>(-1, -1 as V);
        }

        // This implements hash function to find index 
        // for a key 
        int HashCode(int key)
        {
            int h = key.GetHashCode();
            return h % capacity;
        }
        int HashCodeValue(V value)
        {
            int h = Math.Abs(value.GetHashCode());
            return h % capacity;
        }

        //Function to add key value pair 
        public void InsertNode(int key, V value)
        {
            HashNode<int, V> temp = new HashNode<int, V>(key, value);

            if (size == capacity)
                Rehash();

            // Apply hash function to find index for given key 
            int hashIndex = HashCode(key);

            //find next free space  
            while (arr[hashIndex] != null && !arr[hashIndex].key.Equals(key) && !arr[hashIndex].key.Equals(-1))
            {
                hashIndex++;
                hashIndex %= capacity;
            }

            //if new node to be inserted increase the current size 
            if (arr[hashIndex] == null || arr[hashIndex].key.Equals(-1))
                size++;
            arr[hashIndex] = temp;
        }

        //Function to delete a key value pair 
        public V DeleteNode(int key)
        {
            // Apply hash function to find index for given key 
            int hashIndex = HashCode(key);

            //finding the node with given key 
            while (arr[hashIndex] != null)
            {
                //if node found 
                if (arr[hashIndex].key.Equals(key))
                {
                    HashNode<int, V> temp = arr[hashIndex];

                    //Insert dummy node here for further use 
                    arr[hashIndex] = dummy;

                    // Reduce size 
                    size--;
                    return temp.value;
                }
                hashIndex++;
                hashIndex %= capacity;

            }

            //If not found return null 
            return null;
        }

        //Function to search the value for a given key 
        public bool Get(V value)
        {
            // Apply hash function to find index for given key 
            int hashIndex = HashCodeValue(value);
            int counter = 0;
            //finding the node with given key    
            while (arr[hashIndex] != null)
            {
                //int counter = 0;
                if (counter++ > capacity)  //to avoid infinite loop 
                    return false;
                //if node found return true 
                if (arr[hashIndex].value.Equals(value))
                    return true;
                hashIndex++;
                hashIndex %= capacity;
            }
            //If not found return false 
            return false;
        }

        private void Rehash()
        {
            HashMap<int, V> newMap = new HashMap<int, V>(arr.Length * 2);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != null && !arr[i].key.Equals(-1))
                    newMap.InsertNode(arr[i].key, arr[i].value);
            }
            arr = newMap.arr;
            capacity = newMap.capacity;
        }

        //Return current size  
        public int SizeofMap()
        {
            return size;
        }

        //Return true if size is 0 
        public bool IsEmpty()
        {
            return size == 0;
        }

        //Function to display the stored key value pairs 
        public void Display()
        {
            for (int i = 0; i < capacity; i++)
            {
                if (arr[i] != null && !arr[i].key.Equals(-1))
                    Console.WriteLine("key = " + arr[i].key.ToString() + " value = " + arr[i].value);
            }
        }
    }
}
