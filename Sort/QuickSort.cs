using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class QuickSort
    {
        /*
         QuickSort(A,p,r)
         if p < r
            then q <- Partition(A,p,r)
                QuickSort(A,p,q-1)
                QuickSort(A,q+1,r)

         Partition(A,p,r)
            x <- A[r]
            i <- p-1
            for j <- p to r-1
                do if A[j] <= x
                    then i <- i+1
                        A[i] <-> A[j]
                A[i + 1] <-> A[r]
            return i+1;
        */

        //Quick sort array

        public static void QuickSortArray(DataFloatArray A, int p, int r)
        {
            // p = first element index
            // r = last element index
            int q;
            if (p < r)
            {
                q = PartitionArray(A, p, r);
                QuickSortArray(A, p, q - 1);
                QuickSortArray(A, q + 1, r);
            }
        }

        public static int PartitionArray(DataFloatArray A, int p, int r)
        {
            float tmp;
            float x = A[r]; // pivot point = last element
            int i = p - 1;
            for (int j = p; j <= r - 1; j++)
            {
                if(A[j] < x)
                {
                    i++;
                    tmp = A[j];
                    A[j] = A[i];
                    A[i] = tmp;
                }
            }
            tmp = A[i + 1];
            A[i + 1] = A[r];
            A[r] = tmp;
            return i + 1;
        }

        //
        //Quick sort linked list
        //

        public static void QuickSortList(FloatList A, int p, int r)
        {
            int q;
            if (p < r)
            {
                q = PartitionList(A, p, r);
                QuickSortList(A, p, q - 1);
                QuickSortList(A, q + 1, r);
            }
        }

        public static int PartitionList(FloatList A, int p, int r)
        {
            float tmp;
            float x = A.GetNodeAt(r).data;
            int i = p - 1;
            for (int j = p; j <= r - 1; j++)
            {
                if (A.GetNodeAt(j).data < x)
                {
                    i++;
                    tmp = A.GetNodeAt(j).data;
                    A.GetNodeAt(j).data = A.GetNodeAt(i).data;
                    A.GetNodeAt(i).data = tmp;
                }
            }
            tmp = A.GetNodeAt(i + 1).data;
            A.GetNodeAt(i + 1).data = A.GetNodeAt(r).data;
            A.GetNodeAt(r).data = tmp;
            return i + 1;
        }

        public static void QuickSortList(FileFloatList A, int p, int r)
        {
            int q;
            if (p < r)
            {
                q = PartitionList(A, p, r);
                QuickSortList(A, p, q - 1);
                QuickSortList(A, q + 1, r);
            }

        }

        public static int PartitionList(FileFloatList A, int p, int r)
        {
            float tmp;
            float x = A.GetNodeAt(r);
            int i = p - 1;
            for (int j = p; j <= r - 1; j++)
            {
                if (A.GetNodeAt(j) < x)
                {
                    i++;
                    tmp = A.GetNodeAt(j);
                    A.SetNodeAt(j, A.GetNodeAt(i));
                    A.SetNodeAt(i, tmp);
                }
            }
            tmp = A.GetNodeAt(i + 1);
            A.SetNodeAt(i + 1, A.GetNodeAt(r));
            A.SetNodeAt(r, tmp);
            return i + 1;
        }
    }
}
