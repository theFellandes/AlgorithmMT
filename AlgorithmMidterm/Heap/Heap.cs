using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmMidterm.Heap
{
    public class Heap
    {
        private List<int> heap;
        private int _n;
        private bool _heapified;
        public Heap(List<int> heapArray)
        {
            heap = heapArray;
            _n = heap.Count;
        }
        
        public int GetParent(int index)
        {
            return (index - 1) / 2;
        }

        //bool left is there because it indicates whether we want the left child or the right child
        public int GetChild(int index, bool left)
        {
            return 2 * index + (left ? 1 : 2);
        }

        public int GetSize()
        {
            return _n;
        }

        public int[] ReturnArray()
        {
            int[] temp = new int[_n];
            int index = 0;
            foreach (var num in heap)
            {
                temp[index++] = num;
            }

            return temp;
        }

        public void Insert(int value)
        {
            heap[_n - 1] = value;
            BuildMaxHeap();
        }

        public void HeapIncreaseKey(int index, int key)
        {
            if (key < heap[index])
            {
                throw new Exception("New key is smaller than current key");
            }

            heap[index] = key;
            while (index > 0 && heap[GetParent(index)] < heap[index])
            {
                (heap[index], heap[GetParent(index)]) = (heap[GetParent(index)], heap[index]);
                index = GetParent(index);
            }
        }

        public void MaxHeapInsert(int key)
        {
            heap.Add(key);
            HeapIncreaseKey(_n, key);
        }

        public int Delete(int index)
        {
            //Here we take the index of the value that we are going to delete because if we take the value
            //then we need to do a linear search to find the location of the value.
            if (IsEmpty())
                throw new IndexOutOfRangeException("Heap is empty.");
            int parent = GetParent(index);
            int deletedValue = heap[index];

            //Replacing the deletedValue with the rightmost value which is size-1'th indexed value
            heap[index] = heap[_n - 1];
            BuildMaxHeap();
            _n--;
            return deletedValue;
        }

        // public void MaxHeapify(int index, int lastHeapIndex)
        // {
        //     var left = GetChild(index, true);
        //     var right = GetChild(index, false);
        //     int largest = left <= lastHeapIndex && heap[left] > heap[index] ? left : index;
        //     largest = right <= lastHeapIndex && heap[right] > heap[largest] ? right : largest;
        //     if (largest != index)
        //     {
        //         (heap[index], heap[largest]) = (heap[largest], heap[index]);
        //         MaxHeapify(largest, lastHeapIndex);
        //     }
        // }
        

        public void MaxHeapify(int index, int lastHeapIndex)
        {
            int childToSwap;
        
            while (index <= lastHeapIndex)
            {
                int leftChild = GetChild(index, true);
                int rightChild = GetChild(index, false);
                //this means the node has left child
                if (leftChild <= lastHeapIndex)
                {
                    //doesn't have a rightChild
                    if (rightChild > lastHeapIndex)
                    {
                        childToSwap = leftChild;
                    }
                    //if the rightChild if fails, means it has rightChild
                    else
                    {
                        childToSwap = heap[leftChild] > heap[rightChild] ? leftChild : rightChild;
                    }
                    
                    if (heap[index] < heap[childToSwap])
                    {
                        (heap[index], heap[childToSwap]) = (heap[childToSwap], heap[index]);
                    }
        
                    else
                    {
                        break;
                    }
        
                    index = childToSwap;
                }
                
                else
                {
                    break;
                }
            }
        }
        
        public void BuildMaxHeap()
        {
            var n = _n;
            for (int i = n / 2; i >= 0; i--)
            {
                MaxHeapify(i, n - 1);
            }

            _heapified = true;
        }
        
        public void Heapsort()
        {
            if(!_heapified)
                BuildMaxHeap();
            int lastHeapIndex = _n - 1;
            for (int i = 0; i < lastHeapIndex; i++)
            {
                //lastHeapIndex - i is the location of the lastUnsortedIndex
                (heap[0], heap[lastHeapIndex - i]) = (heap[lastHeapIndex - i], heap[0]);
        
                MaxHeapify(0, lastHeapIndex - i - 1);
            }
        }

        private bool IsEmpty()
        {
            return _n == 0;
        }

        public int HeapMaximum()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException("Heap is empty");
            return heap[0];
        }

        public int PeekAtIndexedValue(int index)
        {
            return heap[index];
        }

        public int HeapExtractMax()
        {
            if (_n < 1)
                throw new Exception("Heap underflow");
            var max = heap[0];
            heap[0] = heap[_n - 1];
            heap.Remove(heap[_n - 1]);
            MaxHeapify(0, _n-1);
            return max;
        }

        public void PrintHeap()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var num in heap)
            {
                stringBuilder.Append(num + ", ");
            }
            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            Console.WriteLine(stringBuilder.ToString());
        }
        
    }
}