using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public abstract class DataFloatArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract float this[int index] { get; set; }
        public abstract void Swap(int j, float a, float b);
        public abstract void Add(float value);
        public abstract float First();
        public abstract void RemoveFirst();
        public abstract void Clear();
        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.WriteLine(" {0} ", this[i]);
            Console.WriteLine();
        }
    }
}
