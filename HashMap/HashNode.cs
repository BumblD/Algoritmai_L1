using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class HashNode<K, V>
    {
        public V value;
        public K key;

        //Constructor of hashnode  
        public HashNode(K key, V value)
        {
            this.value = value;
            this.key = key;
        }
    }
}
