using System;
using System.Collections.Generic;

namespace PriorityQueues
{
    class PriorityQueues<T> where T:class,IComparable<T>
    {
        private T[] Pqs;
        private int Size;
        private int Parent(int pos)
        {
            return (pos + 1) / 2 - 1;
        }
        private int Left(int pos)
        {
            return (pos + 1) * 2 - 1;
        }
        private int Right(int pos)
        {
            return (pos + 1) * 2;
        }
        private void Swap(ref T a,ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
        private void MaxHeapify(int pos)
        {
            int l = Left(pos);
            int r = Right(pos);
            int largest = pos;
            if(l<Size&&Pqs[l].CompareTo(Pqs[pos])>0)
            {
                largest = l;
            }
            if(r<Size&&Pqs[r].CompareTo(Pqs[largest])>0)
            {
                largest = r;
            }
            if(largest!=pos)
            {
                Swap(ref Pqs[pos], ref Pqs[largest]);
                MaxHeapify(largest);
            }
        }
        private void BuildMaxHeap()
        {
            for(int i=Size/2;i>=0;i--)
            {
                MaxHeapify(i);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
