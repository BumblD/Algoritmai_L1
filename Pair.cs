using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Pair
    {
        public long item1 { get;  }
        public float item2 { get;  }

        public Pair(long item1, float item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }
        public int CompareTo(Pair oth)
        {
            if (item1 > oth.item1)
            {
                return 1;
            }
            if (item1 < oth.item1)
                return -1;
            return item2.CompareTo(oth.item2);
        }
        public override string ToString()
        {
            return string.Format("{0,20} {1,5}\n", item1, item2);
        }

        public static float RndFloat(Random rnd)
        {
            return (float)(float.MaxValue * 2.0 * (rnd.NextDouble() - 0.5));
        }

        public static long RndLong(Random rnd)
        {
            return (long)((rnd.NextDouble() * 2.0 - 1.0) * long.MaxValue);
        }
    }
}
