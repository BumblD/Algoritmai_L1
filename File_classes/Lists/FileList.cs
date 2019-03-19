using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class FileList : DataList
    {
        private string fileDestination;
        int prevNode;
        int currentNode;
        int nextNode;
        public FileList() : base()
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            this.nextNode = -1;
            this.prevNode = -1;
            this.currentNode = -1;
            Random rand = new Random(seed);
            string file = String.Format(@"List" + rand.Next().ToString() + ".dat");
            while (File.Exists(file))
            {
                file = String.Format(@"List" + rand.Next().ToString() + ".dat");
            }
            fileDestination = file;
            using (fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite));
        }
        public FileList(string filename, int n, int seed)
        {
            fileDestination = filename;
            length = n;
            Random rand = new Random(seed);
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                {
                    writer.Write(4);
                    for (int j = 0; j < length; j++)
                    {
                        writer.Write(Pair.RndLong(rand));
                        writer.Write(Pair.RndFloat(rand));
                        writer.Write((j + 1) * 16 + 4);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public FileStream fs { get; set; }
        public override Pair Head()
        {
            using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
            {
                Byte[] data = new Byte[16];
                fs.Seek(0, SeekOrigin.Begin);
                fs.Read(data, 0, 4);
                currentNode = BitConverter.ToInt32(data, 0);
                prevNode = -1;
                fs.Seek(currentNode, SeekOrigin.Begin);
                fs.Read(data, 0, 16);
                Pair result = new Pair(BitConverter.ToInt64(data, 0), BitConverter.ToSingle(data, 8));
                nextNode = BitConverter.ToInt32(data, 12);
                return result;
            }
        }
        public override Pair Next()
        {
            using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
            {
                Byte[] data = new Byte[16];
                fs.Seek(nextNode, SeekOrigin.Begin);
                fs.Read(data, 0, 16);
                prevNode = currentNode;
                currentNode = nextNode;
                long result = BitConverter.ToInt64(data, 0);
                float res = BitConverter.ToSingle(data, 8);
                nextNode = BitConverter.ToInt32(data, 12);
                return new Pair(result, res);
            }
        }
        public override void Swap(Pair a, Pair b)
        {
            Byte[] data;
            fs.Seek(prevNode, SeekOrigin.Begin);
            data = BitConverter.GetBytes(a.item1);
            fs.Write(data, 0, 8);
            data = BitConverter.GetBytes(a.item2);
            fs.Write(data, 0, 4);
            fs.Seek(currentNode, SeekOrigin.Begin);
            data = BitConverter.GetBytes(b.item1);
            fs.Write(data, 0, 8);
            data = BitConverter.GetBytes(b.item2);
            fs.Write(data, 0, 4);
        }
        public override void Add(Pair value)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileDestination, FileMode.Append)))
            {
                if (length > 0)
                {
                    writer.Write(value.item1);
                    writer.Write(value.item2);
                    writer.Write((Length + 1) * 16 + 4);
                    length++;
                }
                else
                {
                    writer.Write(4);
                    writer.Write(value.item1);
                    writer.Write(value.item2);
                    writer.Write((Length + 1) * 16 + 4);
                    length++;
                }
            }
        }
        public override void RemoveFirst()
        {
            this.Head();
            using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
            {
                Byte[] data = new Byte[8];
                fs.Seek(currentNode + 12, SeekOrigin.Begin);
                fs.Read(data, 0, 8);
                fs.Seek(0, SeekOrigin.Begin);
                fs.Write(data, 0, 4);
            }
            length--;
        }
    }
}
