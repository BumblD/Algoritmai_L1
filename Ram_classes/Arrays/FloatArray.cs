using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class FloatArray : DataFloatArray
    {
        float[] data;
        public FloatArray(int n, int seed)

        {
            data = new float[n];
            length = n;
            Random rand = new Random(seed);
            for (int i = 0; i < length; i++)
            {
                data[i] = Pair.RndFloat(rand);
            }
        }

        public FloatArray(int size)
        {
            data = new float[size];
            length = size;
        }

        public override float this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }

        }
        public override void Swap(int j, float a, float b)

        {
            data[j - 1] = a;
            data[j] = b;

        }

        public override float First()
        {
            return data[0];
        }

        public override void RemoveFirst()
        {
            data = data.Skip(1).ToArray();
            length--;
        }

        public override void Clear()
        {
            data = data.Skip(length - 1).ToArray();
            length = 0;
        }

        public override void Add(float value)
        {
            throw new NotImplementedException();
        }
    }
}
