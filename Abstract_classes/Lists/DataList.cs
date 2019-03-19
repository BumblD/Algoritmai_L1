using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract Pair Head();
        public abstract Pair Next();
        public abstract void Swap(Pair a, Pair b);
        public abstract void Add(Pair value);
        public abstract void RemoveFirst();
        public void Print(int n)
        {
            Console.Write(" {0:F5} ", Head());
            for(int i = 1; i < n; i++)
                Console.Write("{0:F5} ", Next());
            Console.WriteLine();
        }
    }
}
