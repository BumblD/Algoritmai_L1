using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class FileFloatList : DataFloatList
    {
        private string fileDestination;
        int nextNode;
        int prevNode;
        int currentNode;
        public FileFloatList()
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            this.nextNode = -1;
            this.prevNode = -1;
            this.currentNode = -1;
            Random rand = new Random(seed);
            string file = String.Format(@"FloatList" + rand.Next().ToString() + ".dat");
            while (File.Exists(file))
            {
                file = String.Format(@"FloatList" + rand.Next().ToString() + ".dat");
            }
            fileDestination = file;
            using (fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite));
        }
        public FileFloatList(string filename, int n, int seed)
        {
            fileDestination = filename;
            length = n;
            Random rand = new Random(seed);
            float MyData;
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                {
                    writer.Write(4);
                    for (int j = 0; j < length; j++)
                    {
                        MyData = Pair.RndFloat(rand);
                        writer.Write(MyData);
                        writer.Write((j + 1) * 8 + 4);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public FileStream fs { get; set; }

        public override float Head()
        {
            using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
            {
                Byte[] data = new Byte[8];
                fs.Seek(0, SeekOrigin.Begin);
                fs.Read(data, 0, 4);
                currentNode = BitConverter.ToInt32(data, 0);
                prevNode = -1;
                fs.Seek(currentNode, SeekOrigin.Begin);
                fs.Read(data, 0, 8);
                float result = BitConverter.ToSingle(data, 0);
                nextNode = BitConverter.ToInt32(data, 4);
                return result;
            }
        }
        public override float Next()
        {
            using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
            {
                Byte[] data = new Byte[8];
                fs.Seek(nextNode, SeekOrigin.Begin);
                fs.Read(data, 0, 8);
                prevNode = currentNode;
                currentNode = nextNode;
                float result = BitConverter.ToSingle(data, 0);
                nextNode = BitConverter.ToInt32(data, 4);
                return result;
            }
        }
        public override void Swap(float a, float b)
        {
            using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
            {
                Byte[] data;
                fs.Seek(prevNode, SeekOrigin.Begin);
                data = BitConverter.GetBytes(a);
                fs.Write(data, 0, 4);
                fs.Seek(currentNode, SeekOrigin.Begin);
                data = BitConverter.GetBytes(b);
                fs.Write(data, 0, 4);
            }
        }

        public override void Add(float value)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileDestination, FileMode.Append)))
            {
                if (length > 0)
                {
                    writer.Write(value);
                    writer.Write((Length + 1) * 8 + 4);
                    length++;
                }
                else
                {
                    writer.Write(4);
                    writer.Write(value);
                    writer.Write((Length + 1) * 8 + 4);
                    length++;
                }
            }
        }

        public override void RemoveFirst()
        {
            this.Head();
            using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
            {
                Byte[] data = new Byte[4];
                fs.Seek(currentNode + 8, SeekOrigin.Begin);
                fs.Read(data, 0, 4);
                fs.Seek(0, SeekOrigin.Begin);
                fs.Write(data, 0, 4);
            }
            length--;
        }

        public override void Clear()
        {
            this.nextNode = -1;
            this.prevNode = -1;
            this.currentNode = -1;
            FileStream fileStream = File.Open(fileDestination, FileMode.Open);
            fileStream.SetLength(0);
            fileStream.Close();
            length = 0;
        }
        public float GetNodeAt(int position)
        {
            using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
            {
                Byte[] data = new Byte[4];
                fs.Seek(8 * (position) + 4, SeekOrigin.Begin);
                fs.Read(data, 0, 4);
                return BitConverter.ToSingle(data, 0);
            }
        }
        public void SetNodeAt(int position, float value)
        {
            using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
            {
                Byte[] data = new Byte[4];
                fs.Seek(8 * (position) + 4, SeekOrigin.Begin);
                BitConverter.GetBytes(value).CopyTo(data, 0);
                fs.Write(data, 0, 4);
            }
        }
    }
}
