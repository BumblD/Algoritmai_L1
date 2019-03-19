using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class MyDataList : DataList
    {
        public class MyLinkedListNode
        {
            public MyLinkedListNode nextNode { get; set; }
            public Pair data { get; set; }
            public MyLinkedListNode(Pair data)
            {
                this.data = data;
            }
        }
        MyLinkedListNode headNode;
        MyLinkedListNode prevNode;
        MyLinkedListNode currentNode;

        public MyDataList() : base()
        {
            headNode = null;
            prevNode = null;
            currentNode = null;
        }
        public MyDataList(int n, int seed)
        {
            length = n;
            Random rand = new Random(seed);
            headNode = new MyLinkedListNode(new Pair(rand.Next(100000000, 1000000000), Pair.RndFloat(rand)));
            currentNode = headNode;
            for (int i = 1; i < length; i++)
            {
                prevNode = currentNode;
                currentNode.nextNode = new MyLinkedListNode(new Pair(rand.Next(100000000, 1000000000), Pair.RndFloat(rand)));
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = null;
        }

        public override Pair Head()
        {
            currentNode = headNode;
            prevNode = null;
            return currentNode.data;
        }
        
        public override Pair Next()
        {
            prevNode = currentNode;
            currentNode = currentNode.nextNode;
            return currentNode.data;
        }
        public override void Swap(Pair a, Pair b)
        {
            prevNode.data = a;
            currentNode.data = b;
        }

        public override void Add(Pair value)
        {
            if (length > 0)
            {
                prevNode = currentNode;
                currentNode.nextNode = new MyLinkedListNode(value);
                currentNode = currentNode.nextNode;
                length++;
            }
            else
            {
                headNode = new MyLinkedListNode(value);
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
    }
}
