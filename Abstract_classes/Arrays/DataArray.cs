using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    abstract class DataArray 
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract Pair this[int index] { get; set; }
        public abstract void Swap(int j, Pair a, Pair b);
        public abstract void Add(Pair value);
        public abstract Pair First();
        public abstract void RemoveFirst();
        public void Print(int n)
        {            
            for (int i = 0; i < n; i++)
                Console.Write(" {0}", this[i]);
            Console.WriteLine();
        }
    }    
}
