using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class FloatList : DataFloatList
    {
        public class FloatNode
        {
            public FloatNode nextNode { get; set; }
            public float data { get; set; }
            public FloatNode(float data)
            {
                this.data = data;
            }
        }
        //---------------------------------------------
        FloatNode headNode;
        FloatNode prevNode;
        FloatNode currentNode;
        public FloatList() : base()
        {
            this.headNode = null;
            this.prevNode = null;
            this.currentNode = null;
        }
        public FloatList(int n, int seed)
        {
            length = n;
            Random rand = new Random(seed);
            headNode = new FloatNode(rand.Next());
            currentNode = headNode;
            float MyData;
            for (int i = 1; i < length; i++)
            {
                prevNode = currentNode;
                currentNode.nextNode = new FloatNode(MyData = Pair.RndFloat(rand));
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = null;
        }
        public override float Head()
        {
            currentNode = headNode;
            prevNode = null;
            return currentNode.data;
        }
        public override float Next()
        {
            prevNode = currentNode;
            currentNode = currentNode.nextNode;
            return currentNode.data;
        }
        public override void Swap(float a, float b)
        {
            prevNode.data = a;
            currentNode.data = b;
        }

        public override void Add(float value)
        {
            if (length > 0)
            {
                prevNode = currentNode;
                currentNode.nextNode = new FloatNode(value);
                currentNode = currentNode.nextNode;
                length++;
            }
            else
            {
                headNode = new FloatNode(value);
                currentNode = headNode;
                length++;
            }
        }

        public override void RemoveFirst()
        {
            currentNode = headNode;
            headNode = currentNode.nextNode;
            currentNode = null;
            currentNode = headNode;
            length--;
        }

        public override void Clear()
        {
            while (length != 0)
                this.RemoveFirst();
        }
        public FloatNode GetNodeAt(int position)
        {
            FloatNode mark = headNode;
            int i = 0;
            while (i < position)
            {
                mark = mark.nextNode;
                i++;
            }
            return mark;
        }
    }
}
