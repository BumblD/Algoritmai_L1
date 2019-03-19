using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class MergeSort
    {
        public static DataArray Merge_Sort(DataArray unsorted)
        {
            if (unsorted.Length <= 1)
                return unsorted;
            DataArray left;
            DataArray right;
            if (unsorted.GetType() == typeof(MyDataArray))
            {
                left = new MyDataArray(unsorted.Length / 2);
                right = new MyDataArray(unsorted.Length / 2 + 1);
            }
            else
            {
                left = new FileArray(unsorted.Length / 2);
                right = new FileArray(unsorted.Length / 2 + 1);
            }

            int middle = unsorted.Length / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Length; i++)
            {
                right.Add(unsorted[i]);
            }

            left = Merge_Sort(left);
            right = Merge_Sort(right);
            return Merge(left, right);
        }

        private static DataArray Merge(DataArray left, DataArray right)
        {
            DataArray result;
            if (right.GetType() == typeof(MyDataArray))
            {
                result = new MyDataArray(left.Length + right.Length);
            }
            else
            {
                result = new FileArray(left.Length + right.Length);
            }
            while (left.Length > 0 || right.Length > 0)
            {
                if (left.Length > 0 && right.Length > 0)
                {
                    if (left.First().CompareTo(right.First()) == -1)  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.RemoveFirst();      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.RemoveFirst();
                    }
                }
                else if (left.Length > 0)
                {
                    result.Add(left.First());
                    left.RemoveFirst();
                }
                else if (right.Length > 0)
                {
                    result.Add(right.First());

                    right.RemoveFirst();
                }
            }
            return result;
        }

        //
        // Merge sort linked list
        //

        public static DataList Merge_Sort(DataList unsorted)
        {
            if (unsorted.Length <= 1)
                return unsorted;

            DataList left;
            DataList right;

            if (unsorted.GetType() == typeof(MyDataList))
            {
                left = new MyDataList();
                right = new MyDataList();
            }
            else
            {
                left = new FileList();
                right = new FileList();
            }
            Pair data;

            int middle = unsorted.Length / 2;
            data = unsorted.Head();
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {

                left.Add(data);
                data = unsorted.Next();
            }
            for (int i = middle; i < unsorted.Length; i++)
            {
                right.Add(data);
                if (unsorted.Length != left.Length + right.Length) data = unsorted.Next();
            }

            left = Merge_Sort(left);
            right = Merge_Sort(right);
            return Merge(left, right);
        }

        private static DataList Merge(DataList left, DataList right)
        {
            DataList result;

            if (left.GetType() == typeof(MyDataList))
            {
                result = new MyDataList();
            }
            else
            {
                result = new FileList();
            }

            while (left.Length > 0 || right.Length > 0)
            {
                if (left.Length > 0 && right.Length > 0)
                {
                    if (left.Head().CompareTo(right.Head()) == -1)  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.Head());
                        left.RemoveFirst();      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.Head());
                        right.RemoveFirst();
                    }
                }
                else if (left.Length > 0)
                {
                    result.Add(left.Head());
                    left.RemoveFirst();
                }
                else if (right.Length > 0)
                {
                    result.Add(right.Head());

                    right.RemoveFirst();
                }
            }
            return result;
        }        
    }
}
