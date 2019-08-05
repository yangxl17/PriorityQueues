using System;

namespace PriorityQueues
{
    class PriorityQueues<T> where T:IComparable<T>
    {
        private T[] Pqs;
        private int Size;
        public int GetSize()
        {
            return Size;
        }
        public PriorityQueues(T[] pq)
        {
            Pqs = new T[pq.Length];
            pq.CopyTo(Pqs, 0);
            Size = Pqs.Length;
            BuildMaxHeap();
        }
        //Heap
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
        //PriorityQueues
        public T Heapmaxmuim()
        {
            return Pqs[0];
        }
        public T HeapExtractMax()
        {
            if(Size<1)
            {
                Console.WriteLine("Heap underflow!");
                return default(T);
            }
            else
            {
                T max = Pqs[0];
                Pqs[0] = Pqs[Size - 1];
                Size--;
                MaxHeapify(0);
                return max;
            }
        }
        public void HeapIncreaseKey(int pos,T key)
        {
            if(pos<Size)
            {
                if(Pqs[pos].CompareTo(key)<0)
                {
                    Pqs[pos] = key;
                    int i = pos;
                    while(i>0&&Pqs[Parent(i)].CompareTo(Pqs[i])<0)
                    {
                        Swap(ref Pqs[Parent(i)], ref Pqs[i]);
                        i = Parent(i);
                    }
                }
                else
                {
                    Console.WriteLine("new key is small than current key!");
                }
            }
            else
            {
                Console.WriteLine("index is bigger than size!");
            }
        }
        public void MaxHeapInsert(T key)
        {
            Size++;
            if(Size>Pqs.Length)
            {
                T[] nPqs = new T[2 * Size];
                Pqs.CopyTo(nPqs,0);
                Pqs = nPqs;
            }
            Pqs[Size - 1] = key;
            int i = Size-1;
            while (i > 0 && Pqs[Parent(i)].CompareTo(Pqs[i]) < 0)
            {
                Swap(ref Pqs[Parent(i)], ref Pqs[i]);
                i = Parent(i);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 9, 3, 5, 7, 0, 10, 98 };
            PriorityQueues<int> pq = new PriorityQueues<int>(test);
            pq.HeapIncreaseKey(2, 100);
            pq.MaxHeapInsert(50);
            pq.MaxHeapInsert(6);
            while(pq.GetSize()!=0)
            {
                Console.WriteLine(pq.HeapExtractMax());
            }
        }
    }
}
