using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            // Testing:

            Test_File_Array_List(seed);
            //Test_Array_List(seed);
            //Test_Quick_Sort(seed);
            //Test_File_Quick_Sort(seed);
            //Test_HashMap(seed);
            //Test_File_HashMap(seed);

            Console.WriteLine("Done!");

            //Stopwatch matavimams!!!

            //Hashmap paieska palei reiksme, grazinti bool
            //kad gaut vidutine reiksme praeit pro visus ir dalint is ju kiekio.
        }

        public static void Test_Quick_Sort(int seed)
        {
            Stopwatch stopwatch = new Stopwatch();
            double ts;
            //TimeSpan ts = new TimeSpan();
            int n = 256000;
            FloatArray arr = new FloatArray(n, seed);
            //Console.WriteLine("ARRAY \n\nFLOAT");
            //arr.Print(n);
            stopwatch.Start();
            QuickSort.QuickSortArray(arr, 0, arr.Length - 1);
            stopwatch.Stop();
            ts = stopwatch.Elapsed.TotalSeconds;
            //Console.WriteLine("\nSORTED");
            Console.WriteLine(ts);
            //arr.Print(n);
            
            Console.WriteLine();

            /*stopwatch.Reset();
            FloatList list = new FloatList(n, seed);
            //Console.WriteLine("LIST \n\nFLOAT");
            //list.Print(n);
            stopwatch.Start();
            QuickSort.QuickSortList(list, 0, list.Length - 1);
            stopwatch.Stop();
            //Console.WriteLine("\nSORTED");
            //list.Print(n);
            ts = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine(ts);
            Console.Beep();*/
        }

        public static void Test_File_Quick_Sort(int seed)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan ts = new TimeSpan();
            int n = 240;
            /*string filename = @"myfloatdataarray.dat";
            FileFloatArray myarr = new FileFloatArray(filename, n, seed);
            //Console.WriteLine("FILE ARRAY \n\nFLOAT");
            //myarr.Print(n);
            stopwatch.Start();
            QuickSort.QuickSortArray(myarr, 0, myarr.Length - 1);
            stopwatch.Stop();
            //Console.WriteLine("\nSORTED");
            //myarr.Print(n);
            ts = stopwatch.Elapsed;
            Console.WriteLine(ts);
            Console.Beep();*/

            //stopwatch.Reset();
            string filename = @"myfloatdatalist.dat";
            FileFloatList mylist = new FileFloatList(filename, n, seed);
            //Console.WriteLine("FILE LIST \n\nFLOAT");
            //mylist.Print(n);
            stopwatch.Start();
            QuickSort.QuickSortList(mylist, 0, mylist.Length - 1);
            stopwatch.Stop();
            //Console.WriteLine("\nSORTED");
            //mylist.Print(n);
            ts = stopwatch.Elapsed;
            Console.WriteLine(ts);
            //DeleteFiles();
            Console.Beep();
        }

        public static void Test_HashMap(int seed)
        {
            int n = 8000000;
            Stopwatch stopwatch = new Stopwatch();
            double ts;
            HashMap<int, string> mymap = new HashMap<int, string>();
            string[] values = new string[n];
            Random rnd = new Random(seed);
            string value;
            int key;
            for (int i = 0; i < n; i++)
            {
                value = Path.GetRandomFileName().Substring(0,8);
                key = Math.Abs(value.GetHashCode());
                mymap.InsertNode(key, value);
                values[i] = value;
            }
            //Console.WriteLine("HASHMAP");
            //mymap.Display();
            //Console.WriteLine("\n\n GET");
            stopwatch.Start();
            for (int i = 0; i < values.Length; i++)
            {
                /*Console.WriteLine(*/mymap.Get(values[i]).ToString();
            }
            stopwatch.Stop();
            ts = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine(ts);
            Console.Beep();
        }

        public static void Test_File_HashMap(int seed)
        {
            Console.WriteLine("NEEDS TO BE IMPLEMENTED!!!");
        }

        public static void Test_Array_List(int seed)
        {
            int n = 400000;
            Stopwatch stopwatch = new Stopwatch();
            double ts;
            /*MyDataArray myarray = new MyDataArray(n, seed);
            //Console.WriteLine("\n ARRAY \n  LONG                FLOAT");
            //myarray.Print(n);
            //Console.WriteLine("SORTED");
            stopwatch.Start();
            myarray = (MyDataArray) MergeSort.Merge_Sort(myarray);
            stopwatch.Stop();
            ts = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine(ts);*/
            //myarray.Print(n);
            MyDataList mylist = new MyDataList(n, seed);
            //Console.WriteLine("\n LIST \n  LONG                FLOAT");
            //mylist.Print(n);
            //Console.WriteLine("SORTED");
            stopwatch.Start();
            mylist = (MyDataList) MergeSort.Merge_Sort(mylist);
            stopwatch.Stop();
            ts = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine(ts);
            //mylist.Print(n);
        }
        public static void Test_File_Array_List(int seed)
        {
            int n = 50;
            Stopwatch stopwatch = new Stopwatch();
            double ts;
            string filename;
            filename = @"mydataarray.dat";
            FileArray myfilearray = new FileArray(filename, n, seed);
            //Console.WriteLine("\n FILE ARRAY \n  LONG                FLOAT");
            //myfilearray.Print(n);
            stopwatch.Start();
            myfilearray = (FileArray)MergeSort.Merge_Sort(myfilearray);
            stopwatch.Stop();
            ts = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine(ts);
            Console.Beep();
            //myfilearray.Print(n);

            /*filename = @"mydatalist.dat";
            FileList myfilelist = new FileList(filename, n, seed);
            //Console.WriteLine("\n FILE LIST \n  LONG                FLOAT");
            //myfilelist.Print(n);
            stopwatch.Start();
            myfilelist = (FileList)MergeSort.Merge_Sort(myfilelist);
            ts = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine(ts);
            Console.Beep();*/
            //myfilelist.Print(n);
            DeleteFiles();
        }

        public static void DeleteFiles()
        {
            foreach(string path in Directory.GetFiles("../../bin/Debug"))
                if (path.StartsWith("../../bin/Debug\\Arr") || path.StartsWith("../../bin/Debug\\List") || path.StartsWith("../../bin/Debug\\FloatList") || path.StartsWith("../../bin/Debug\\FloatArr"))
                    File.Delete(path);
        }        
    }
}
