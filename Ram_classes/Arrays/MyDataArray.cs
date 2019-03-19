using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class MyDataArray : DataArray
    {
        Pair[] data;
        public MyDataArray(int n, int seed)
        {
            data = new Pair[n];
            length = n;
            Random rand = new Random(seed);
            for (int i = 0; i < length; i++)
            {
                Pair p = new Pair(rand.Next(100000000, 1000000000), Pair.RndFloat(rand));
                data[i] = p;
            }
        }

        public MyDataArray(int n)
        {
            data = new Pair[n];
            length = 0;
        }

        public override Pair this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        public override void Add(Pair value)
        {
            data[length] = value;
            length++;
        }

        public override void Swap(int j, Pair a, Pair b)
        {
            data[j- 1] = a;
            data[j] = b;
            
        }

        public override Pair First()
        {
            return data[0];
        }

        public override void RemoveFirst()
        {
            data = data.Skip(1).ToArray();
            length--;
        }
    }
}
