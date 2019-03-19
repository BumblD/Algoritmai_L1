using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class FileArray : DataArray
    {
        private string fileDestination;
        public FileArray(int seed) : base()
        {
            Random rnd = new Random(seed);
            string file = String.Format(@"Arr" + rnd.Next().ToString() + ".dat");
            while (File.Exists(file))
            {
                file = String.Format(@"Arr" + rnd.Next().ToString() + ".dat");
            }
            fileDestination = file;
            using (fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite));
        }
        public FileArray(string filename, int n, int seed)
        {
            fileDestination = filename;
            Pair data;
            length = n;
            Random rand = new Random(seed);

            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                {
                    for (int j = 0; j < length; j++)
                    {
                        data = new Pair(Pair.RndLong(rand), Pair.RndFloat(rand));
                        writer.Write(data.item1);
                        writer.Write(data.item2);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }        public FileStream fs { get; set; }
        public override void Add(Pair value)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileDestination, FileMode.Append)))
                {
                    writer.Write(value.item1);
                    writer.Write(value.item2);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            length++;
        }
        public override Pair this[int index]
        {
            get
            {
                using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
                {
                    Byte[] data = new Byte[12];
                    fs.Seek(12 * index, SeekOrigin.Begin);
                    fs.Read(data, 0, 12);
                    Pair result = new Pair(BitConverter.ToInt64(data, 0), BitConverter.ToSingle(data, 8));
                    return result;
                }
            }
            set
            {
                using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
                {
                    byte[] data = new byte[12];
                    BitConverter.GetBytes(value.item1).CopyTo(data, 0);
                    BitConverter.GetBytes(value.item2).CopyTo(data, 8);
                    fs.Seek(12 * index, SeekOrigin.Begin);
                    fs.Write(data, 0, 12);
                }
            }
        }

        public override void Swap(int j, Pair a, Pair b)
        {
            Byte[] data = new Byte[24];
            BitConverter.GetBytes(a.item1).CopyTo(data, 0);
            BitConverter.GetBytes(a.item2).CopyTo(data, 8);
            BitConverter.GetBytes(b.item1).CopyTo(data, 12);
            BitConverter.GetBytes(b.item2).CopyTo(data, 20);
            fs.Seek(12 * (j - 1), SeekOrigin.Begin);
            fs.Write(data, 0, 24);
        }
        public override Pair First()
        {
            using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
            {
                Byte[] data = new Byte[12];
                fs.Seek(0, SeekOrigin.Begin);
                fs.Read(data, 0, 12);
                return new Pair(BitConverter.ToInt64(data, 0), BitConverter.ToSingle(data, 8));
            }
        }
        public override void RemoveFirst()
        {
            for (int i = 0; i < length - 1; i++)
            {
                this[i] = this[i + 1];
            }
            length--;
            if (length == 0)
            {
                File.Delete(fileDestination);
            }
        }
    }
}
