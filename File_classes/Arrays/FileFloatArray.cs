using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class FileFloatArray : DataFloatArray
    {
        private string fileDestination;
        public FileFloatArray(int seed)
        {
            Random rand = new Random(seed);
            string file = String.Format(@"FloatArr" + rand.Next().ToString() + ".dat");
            while (File.Exists(file))
            {
                file = String.Format(@"FloatArr" + rand.Next().ToString() + ".dat");
            }
            fileDestination = file;
            using (fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite)) ;
        }
        public FileFloatArray(string filename, int n, int seed)

        {
            fileDestination = filename;
            float data;
            length = n;
            Random rand = new Random(seed);
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                {
                    for (int j = 0; j < length; j++)
                    {
                        data = Pair.RndFloat(rand);
                        writer.Write(data);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        public FileStream fs { get; set; }

        public override void Add(float value)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileDestination, FileMode.Append)))
                {
                    writer.Write(value);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            length++;
        }
        public override float this[int index]
        {
            get
            {
                using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
                {
                    byte[] data = new byte[4];
                    fs.Seek(4 * index, SeekOrigin.Begin);
                    fs.Read(data, 0, 4);
                    float result = BitConverter.ToSingle(data, 0);
                    return result;
                }
            }
            set
            {
                using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
                {
                    byte[] data = new byte[4];
                    BitConverter.GetBytes(value).CopyTo(data, 0);
                    fs.Seek(4 * index, SeekOrigin.Begin);
                    fs.Write(data, 0, 4);
                }
            }
        }
        public override void Swap(int j, float a, float b)
        {
            throw new NotImplementedException();

        }

        public override float First()
        {
            using (fs = new FileStream(fileDestination, FileMode.Open, FileAccess.ReadWrite))
            {
                Byte[] data = new Byte[4];
                fs.Seek(0, SeekOrigin.Begin);
                fs.Read(data, 0, 4);
                return BitConverter.ToSingle(data, 0);
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

        public override void Clear()
        {
            FileStream fileStream = File.Open(fileDestination, FileMode.Open);
            fileStream.SetLength(0);
            fileStream.Close();
            length = 0;
        }
    }
}
