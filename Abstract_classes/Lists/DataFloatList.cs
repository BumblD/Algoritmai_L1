using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public abstract class DataFloatList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract float Head();
        public abstract float Next();
        public abstract void Swap(float a, float b);
        public abstract void Add(float value);
        public abstract void RemoveFirst();
        public abstract void Clear();
        public void Print(int n)
        {
            Console.WriteLine(" {0} ", Head());
            for (int i = 1; i < n; i++)
                Console.WriteLine(" {0} ", Next());
            Console.WriteLine();
        }
    }
}
